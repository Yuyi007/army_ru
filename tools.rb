# encoding: utf-8
# tools.rb
#
# 客户端集成工具集:
#
# ProjectConfig: 项目配置
# ResourcePublisher: 资源发布辅助类
# ResourceUpdater: 资源更新辅助类
# ResourceSync: 监测资源改变并同步
# FileWatchDaemon: 监测文件改变Daemon
# AndroidDeviceDaemon: 监测Android设备状态Daemon
# TexturePacker: TexturePacker包装类
# GlyphDesigner: GlyphDesigner包装类
# GmApi: GM API辅助类
# SoundUtil: 声音辅助类
#

require 'rubygems'
require 'daemons'
require 'singleton'
require 'fileutils'
require 'digest'
require 'json'
require 'uri'
require 'cgi'
require 'net/http'

module Boot end

module Boot::Tools

  class SheetOption
    attr_accessor :sheets
    attr_accessor :opt

    def initialize
      @sheets = []
      @opt = {}
      yield(@sheets, @opt) if block_given?
    end

  end


  ########################################################################
  # 项目配置

  class ProjectConfig

    attr_accessor :project_name, :project_root
    attr_accessor :files_ccbgen_root, :files_shared_root, :files_ios_root, :files_android_root
    attr_accessor :publish_root
    attr_accessor :server_project_root, :script_root
    attr_accessor :client_project_root
    attr_accessor :ios_resource_root, :android_resource_root, :osx_resource_root
    attr_accessor :ios_bundle_root, :android_bundle_root, :osx_bundle_root
    attr_accessor :sdcard_script_root, :sdcard_resource_root

    attr_accessor :art_root, :art_build_root, :art_build_temp

    attr_accessor :ccb_root, :ccb_project_file
    attr_accessor :unity_exec

    def initialize
      yield self if block_given?
    end

  end

  class << self

    attr_accessor :config

  end

  ########################################################################
  # 发布资源到cdn

  class ResourcePublisher

    def apply_last_publish_client_version base, options = {}
      publish_dir = options[:publish_dir] || ''
      dir = File.join(Boot::Tools.config.publish_root,
        '/', publish_dir)

      platforms = {
        :editor => "#{dir}/editor/version.tmp",
        :ios => "#{dir}/ios/version.tmp",
        :android => "#{dir}/android/version.tmp"
      }
      platforms.dup.each do |platform, filename|
        platforms[platform] = File.open(filename).read.strip rescue nil
      end

      hasfail = false
      platforms.each do |platform, version|
        if version and version.length > 0
          url = "http://#{base}/api/client_version?platform=#{platform}&version=#{version}"
          puts "set version to #{version} for #{platform}"
          if not Boot::Tools::GmApi.new.call_uri(url, options)
            puts "set version for platform #{platform} failed !!!"
            hasfail = true
          end
        else
          puts "no version found for #{platform}"
        end
      end

      ! hasfail
    end

    def publish_all options = {}
      publish :ios, options
      publish :android, options
    end

    def publish platform, options = {}
      platform = platform.to_s
      raise 'invalid platform' if platform !~ /android|ios|editor/

      ver = options[:ver] || Time.now.to_i.to_s
      version = "#{platform}-#{ver}"

      publish_dir = options[:publish_dir] || ''
      publish_dir = File.expand_path(File.join(Boot::Tools.config.publish_root,
        '/', publish_dir, '/', platform))

      if platform == 'editor'
        resource_dir = Boot::Tools.config.osx_resource_root + '/'
        bundle_dir = Boot::Tools.config.osx_bundle_root + '/'
      elsif platform == 'ios'
        resource_dir = Boot::Tools.config.ios_resource_root + '/'
        bundle_dir = Boot::Tools.config.ios_bundle_root + '/'
      elsif platform == 'android'
        resource_dir = Boot::Tools.config.android_resource_root + '/'
        bundle_dir = Boot::Tools.config.android_bundle_root + '/'
      else
        raise "invalid platform #{platform} !!!"
      end

      operation_folder = File.join(Boot::Tools.config.project_root, '/operation')

      puts "operation_folder=#{operation_folder}"

      excludes = ([ '' ] + (options[:excludes] || [])).uniq.map{|x| if x != '' then "'#{x}'" else x end }.join(' --exclude ')
      includes = ([ '' ] + (options[:includes] || [])).uniq.map{|x| if x != '' then "'#{x}'" else x end }.join(' --include ')

      # puts "options #{options}"

      tencent_cdn    = options[:tencent_cdn]
      ks_cdn         = options[:ks_cdn]
      custom_options = options[:custom_options]
      ssh            = !! options[:ssh]
      local          = !! options[:local]
      url            = options[:url]
      rsync_user     = options[:rsync_user] || 'jenkins'
      rsync_host     = options[:rsync_host]
      rsync_dst      = options[:rsync_dst]
      rsync_module   = options[:rsync_module]
      game_config_scheme = options[:game_config_scheme]

      if !local
        rsync_endpoint = rsync_module || "#{rsync_user}@#{rsync_host}:#{rsync_dst}"
      else
        rsync_endpoint = rsync_module || rsync_dst
      end

      # puts "rsync_endpoint = #{rsync_endpoint}"

      rsync_pass     = options[:rsync_pass]
      rsync_passfile = options[:rsync_passfile]

      FileUtils.mkdir_p publish_dir

      old_version = nil
      version_file = File.join(publish_dir, 'version.tmp')
      all_versions_file = File.join(publish_dir, 'all_versions.tmp')

      if File.exist?(version_file)
        old_version = IO.read(version_file)
      end

      if File.exist?(all_versions_file)
        all_versions = IO.read(all_versions_file)
      end

      commands = %Q{
        rm #{publish_dir}/*.db
        find #{publish_dir}/*.gz | xargs rm -f
        rsync -rav --delete-after --delete-excluded #{includes} #{excludes} --exclude '*.mp4' '#{resource_dir}' '#{publish_dir}'
        rsync -rav --delete-after --delete-excluded #{includes} #{excludes} --exclude '*.db' --exclude '*.json' '#{bundle_dir}' '#{publish_dir}/bundles/'
        cp -rvf #{bundle_dir}*.db #{publish_dir}/
        cp -rvf #{bundle_dir}sprites.json #{publish_dir}/
        cp -rvf #{bundle_dir}bundles_*.json #{publish_dir}/
        }

      # puts commands
      system(commands)

      if game_config_scheme
        scheme_folder = "#{operation_folder}/#{game_config_scheme}"
        if File.exist?(scheme_folder)
          system("cp -fv #{scheme_folder}/*.db #{publish_dir}/")
        end
      end

      if all_versions then
        File.open(all_versions_file, "w+") { |f| f.puts(all_versions) }
      end

      puts "publishing #{publish_dir}..."

      puts "generate meta..."
      generate_meta(platform, publish_dir, :human => true, :gen_version => true, :publishing => true)

      rsync_vars = "RSYNC_PASSWORD='#{rsync_pass}'" if rsync_pass
      rsync_params = "-acv --delete-after --delete-excluded #{includes} #{excludes}"
      rsync_params += " --password-file=#{rsync_passfile}" if rsync_passfile

      if tencent_cdn
        appid = custom_options['appid']
        secret_id = custom_options['secret_id']
        secret_key = custom_options['secret_key']
        bucket = custom_options['bucket']
        region = custom_options['region']
        system(%Q{
          cd #{Boot::Tools.config.project_root}
          bin/tencent_cdn_deploy.rb #{appid} #{secret_id} #{secret_key} #{bucket} #{region} #{publish_dir}/ #{version} #{url}
          })
      elsif ks_cdn
        app_key = custom_options['app_key']
        secret_key = custom_options['secret_key']
        bucket = custom_options['bucket']
        remote_dir = custom_options['bucket_dir'] + "/" + version
        system(%Q{
          cd #{Boot::Tools.config.project_root}
          bin/kscdn_deploy.py #{app_key} #{secret_key} #{bucket} #{publish_dir} #{remote_dir} #{url}
          })
      elsif ssh
        if local
          cmd =  %Q{
            #{rsync_vars} rsync #{rsync_params} '#{publish_dir}/' '#{rsync_endpoint}/temp-#{platform}/' &&
            cp -rf #{rsync_dst}/temp-#{platform} #{rsync_dst}/#{version}
            }
          system(cmd)
        else
          puts "ssh to #{rsync_endpoint}"
          cmd = %Q{
            ssh #{rsync_user}@#{rsync_host} "mkdir -p #{rsync_dst}" &&
            #{rsync_vars} rsync #{rsync_params} '#{publish_dir}/' '#{rsync_endpoint}/temp-#{platform}/' &&
            ssh #{rsync_user}@#{rsync_host} "cp -rf #{rsync_dst}/temp-#{platform} #{rsync_dst}/#{version}"
            }
            puts "rsync cmd:#{cmd}"
          system(cmd)
        end

        # delete old version folder
        if old_version
          puts "deleting old version #{rsync_dst}/#{old_version}"
          if !local
            system(%Q{ssh #{rsync_user}@#{rsync_host} "rm -rf #{rsync_dst}/#{old_version}"})
          else
            system(%Q{rm -rf #{rsync_dst}/#{old_version}})
          end
        end
      else
        puts "rsync to #{rsync_endpoint}"
        system(%Q{
          #{rsync_vars} rsync #{rsync_params} '#{publish_dir}/' '#{rsync_endpoint}/#{version}/'
          })
      end

      File.open(version_file, "w+") { |f| f.write(version) }
      File.open(all_versions_file, "a+") { |f| f.puts(version) }

      meta_file = "#{url}/#{version}/meta.json"
      system "curl #{meta_file} &> /dev/null"
      puts "publish success: meta=#{meta_file}"
      puts "publish success: version=#{version}"
    end

    def generate_meta platform, directory, options = {}
      Dir.chdir(directory)

      human = !! options[:human]
      gen_version = !! options[:gen_version]
      publishing = !! options[:publishing]
      hasher = options[:hasher] || 'xxhash'
      seed = options[:seed] || '1984'

      _hasher = case hasher
      when 'xxhash'; lambda { |content| require 'xxhash'; XXhash.xxh32(content, seed.to_i).to_s }
      else lambda { |content| Digest::MD5.hexdigest(content) }
      end

      # require_relative 'file_tagger'
      # _file_tagger = Boot::Tools::FileTagger.new

      # hash files
      files = {}
      total_size = 0
      total_compressed_size = 0

      Dir.glob("**/*").each do |f|
        if File.file?(f) and
          f != 'config.json' and f != 'meta.json' and
          f != 'VERSION' and f != 'version.tmp' and f != 'all_versions.tmp' and
          f != 'meta.gz' and f != 'config.lua' and f != 'debug.lua' and
          f !~ /data\d*\.zip/ and f !~ /bin\// then
          puts "generate_meta: #{f}..."
          data = File.read(f)
          size = data.length
          total_size += size
          compress = (platform == 'android' and publishing and size > 8192)
          if compress then
            compressed_size = 0
            File.open("#{f}.gz", "wb+") do |out|
              compressed = Zlib::Deflate.deflate(data)
              compressed_size = compressed.length
              out.write(compressed)
              File.delete(f)
            end
            total_compressed_size += compressed_size
            files[f] = {
              'size' => compressed_size,
              'raw_size' => size,
              'compress' => 'gz',
            }
          else
            files[f] = {
              'size' => size,
            }
            compressed_file = "#{f}.gz"
            File.delete(compressed_file) if File.exist?(compressed_file)
          end
          files[f]['hash'] = _hasher.call(data)
          # files[f]['tags'] = _file_tagger.tags(f)
        end
      end

      puts "generate_meta: total size=#{total_size} compressed size=#{total_compressed_size} ratio=#{total_compressed_size / (total_size + 0.0)}"

      # write meta info
      res = { 'files' => files, 'seed' => seed, 'hasher' => hasher }
      if human then
        meta_json = JSON.pretty_generate(res).to_s
      else
        meta_json = JSON.generate(res).to_s
      end

      File.open("meta.json", "w+") do |f|
        f.write(meta_json)
      end

      File.open("meta.gz", "wb+") do |f|
        f.write(Zlib::Deflate.deflate(meta_json))
      end if publishing

      # update version tag
      File.open("VERSION", "w") do |f|
        part1 = files['cl.lc']['hash']
        configHash = '' #files['config.json']['hash']
        stringHash = '' #files['strings.json']['hash']
        assetsHash = '' #files['ASSETS_VER']['hash']
        part2 = Digest::MD5.hexdigest("#{configHash} #{stringHash} #{assetsHash}")
        f.write("#{part1}.#{part2}")
      end if gen_version
    end

  private

  end

  ########################################################################
  # 拷贝资源到各发行folder

  class ResourceUpdater

    include Singleton

    def update
      update_ios && update_android
    end

    def update_ios
      res = system(%Q{
        rsync -ra --exclude '*.pvr.ccz' #{Boot::Tools.config.files_ccbgen_root}/ #{Boot::Tools.config.ios_resource_root}/files/ &&
        rsync -ra #{Boot::Tools.config.files_shared_root}/ #{Boot::Tools.config.ios_resource_root}/files/ &&
        rsync -ra #{Boot::Tools.config.files_ios_root}/ #{Boot::Tools.config.ios_resource_root}/files/
      })
      puts "update_ios success=#{res}"
      res
    end

    def update_android
      res = system(%Q{
        rsync -ra --exclude '*.pvr.ccz' #{Boot::Tools.config.files_ccbgen_root}/ #{Boot::Tools.config.android_resource_root}/files/ &&
        rsync -ra #{Boot::Tools.config.files_shared_root}/ #{Boot::Tools.config.android_resource_root}/files/ &&
        rsync -ra #{Boot::Tools.config.files_android_root}/ #{Boot::Tools.config.android_resource_root}/files/
      })
      puts "update_android success=#{res}"
      res
    end

    def sync_android
      res = system(%Q{
        bin/adb_sync.py #{Boot::Tools.config.script_root}/ #{Boot::Tools.config.sdcard_script_root}/ &&
        bin/adb_sync.py #{Boot::Tools.config.android_resource_root}/ #{Boot::Tools.config.sdcard_resource_root}/
        bin/adb_sync.py #{Boot::Tools.config.android_bundle_root}/ #{Boot::Tools.config.sdcard_resource_root}/bundles/
      })
      puts "sync_android success=#{res}"
      res
    end

    def push_android
      res = system(%Q{
        adb shell mkdir -p #{Boot::Tools.config.sdcard_script_root} #{Boot::Tools.config.sdcard_resource_root}/bundles/
        adb push #{Boot::Tools.config.script_root}/* #{Boot::Tools.config.sdcard_script_root}/ &&
        adb push #{Boot::Tools.config.android_resource_root}/* #{Boot::Tools.config.sdcard_resource_root}/
        adb push #{Boot::Tools.config.android_bundle_root}/* #{Boot::Tools.config.sdcard_resource_root}/bundles/
      })
      puts "push_android success=#{res}"
      res
    end

    def push_android_lua file = nil
      if file
        file = "#{file}.lua"
        res = system(%Q{
          adb push #{Boot::Tools.config.script_root}/#{file} #{Boot::Tools.config.sdcard_script_root}/#{file}
        })
      else
        res = system(%Q{
          adb push #{Boot::Tools.config.script_root}/* #{Boot::Tools.config.sdcard_script_root}/
        })
      end
      puts "push_android_lua success=#{res}"
      res
    end

    def push_android_file src, dst
      system "adb push #{src} #{dst}"
    end

  end

  ########################################################################
  # 监测资源改变并同步的类

  class ResourceSync

    attr_accessor :updater, :device_daemon, :file_daemon, :sound_util
    attr_accessor :device_attached

    include Singleton

    def initialize
      self.updater = ResourceUpdater.instance
      self.device_daemon = AndroidDeviceWatchDaemon.new
      self.device_attached = self.device_daemon.is_device_attached?
      self.file_daemon = FileWatchDaemon.new
      self.sound_util = SoundUtil.new :sound_root => Boot::Tools.config.project_root + '/sounds', :cooldown => 3
    end

    def watch
      Dir.chdir(Boot::Tools.config.project_root)

      add_watch_device
      add_watch_resources
      add_watch_lua

      device_daemon.restart
      file_daemon.restart
    end

    def watch_lua
      Dir.chdir(Boot::Tools.config.project_root)

      add_watch_device
      add_watch_lua

      device_daemon.restart
      file_daemon.restart
    end

    def add_watch_device
      # 监测安卓手机连接并拷贝资源
      device_daemon.add_callback do |attached|
        self.device_attached = attached
        if attached
          res = updater.push_android
          sound_util.play_file (res ? 'crrect_answer1.mp3' : 'blip2.mp3')
          res
        else
          false
        end
      end
    end

    def add_watch_resources
      # 监测ccb publish的变化并拷贝资源
      # file_daemon.add_watch "#{Boot::Tools.config.files_ccbgen_root}/fileLookup.plist" do |name|
      #   res = updater.update
      #   sound_util.play_file (res ? 'crrect_answer3.mp3' : 'blip2.mp3')
      #   res
      # end

      # 监测安卓资源变化并与调试手机同步
      file_daemon.add_watch([
        "#{Boot::Tools.config.android_resource_root}/**/*",
        "#{Boot::Tools.config.android_bundle_root}/**/*",
        ]) do |name|
        if self.device_attached
          if name =~ /\.(lua|json|ccbi|fnt|plist|png|ccz|dat|wav|mp3|mp4|ab)/
            file = name.slice(name.index(Boot::Tools.config.android_resource_root) +
              Boot::Tools.config.android_resource_root.length, name.length) rescue
              name.slice(name.index(Boot::Tools.config.android_bundle_root) +
              Boot::Tools.config.android_bundle_root.length, name.length)
            res = updater.push_android_file(name, "#{Boot::Tools.config.sdcard_resource_root}/bundles/#{file}")
            sound_util.play_file (res ? 'button03a.mp3' : 'blip2.mp3')
            res
          else
            false
          end
        else
          false
        end
      end
    end

    def add_watch_lua
      # 监测Lua脚本变化并与调试手机同步
      file_daemon.add_watch "#{Boot::Tools.config.script_root}/**/*.lua" do |name|
        if self.device_attached
          file = name.slice(name.index(Boot::Tools.config.script_root) +
            Boot::Tools.config.script_root.length, name.length)
          res = updater.push_android_file(name, "#{Boot::Tools.config.sdcard_script_root}/#{file}")
          sound_util.play_file (res ? 'button03b.mp3' : 'blip2.mp3')
          res
        else
          false
        end
      end
    end

    def unwatch
      device_daemon.stop
      file_daemon.stop
    end

  end

  ########################################################################
  # 监测文件改变的daemon

  class FileWatchDaemon

    attr_accessor :app_name, :patterns

    def initialize
      self.app_name = "#{Boot::Tools.config.project_name}_file_watch"
      self.patterns = {}
    end

    def add_watch patternOrPatterns, &blk
      if patternOrPatterns.is_a?(String)
        patterns[patternOrPatterns] = blk
      elsif patternOrPatterns.is_a?(Array)
        patternOrPatterns.each do |pat|
          add_watch(pat, &blk)
        end
      else
        raise "add_watch: invalid parameter #{patternOrPatterns}"
      end
    end

    def restart; control_watch 'restart'; end
    def stop; control_watch 'stop'; end

  private

    def control_watch cmd
      Daemons.run_proc(app_name, :ARGV => [cmd], :log_output => true) do
        puts "#{app_name} daemon started"
        mtable = {}
        files = scanfiles()
        update(mtable, files, false)

        loop do
          Kernel.sleep 1.5
          files = scanfiles()
          update(mtable, files, true)
        end
      end
    end

    def scanfiles
      files = {}
      patterns.each { |pat, _| files[pat] = Dir.glob(pat) }
      files
    end

    def update(mtable, files, reload)
      files.each do |pat, matches|
        matches.each do |name|
          t = Kernel.test(?M, name)
          if reload and t.to_i > mtable[name].to_i
            puts "$$ changed: #{name}"
            begin
              callback = patterns[pat]
              if callback
                res = callback.call name
                puts "$$ callback failed on #{name}" unless res
              end
            rescue Exception => e
              puts "$$ callback on #{name} failed: #{e.message}"
            end
          end
          mtable[name] = t
        end
      end
    end

  end

  ########################################################################
  # 监测Android设备连接情况的daemon

  class AndroidDeviceWatchDaemon

    attr_accessor :app_name, :callbacks

    def initialize
      self.app_name = "#{Boot::Tools.config.project_name}_device_watch"
      self.callbacks = []
    end

    def is_device_attached?
      system('adb devices -l | grep usb > /dev/null')
    end

    def add_callback &blk
      callbacks << blk
    end

    def restart; control_watch 'restart'; end
    def stop; control_watch 'stop'; end

  private

    def control_watch cmd
      Daemons.run_proc(app_name, :ARGV => [cmd], :log_output => true) do
        last_attached = is_device_attached?
        puts "#{app_name} daemon started attached=#{last_attached}"
        loop do
          Kernel.sleep 1.5
          attached = is_device_attached?
          if attached != last_attached
            puts(attached ? "$$ android device is attached" :
              "$$ android device is unplugged")
            callbacks.each { |blk| blk.call(attached) }
          end
          last_attached = attached
        end
      end
    end

  end

  ########################################################################
  # TexturePacker工具类

  class TexturePacker

    attr_accessor :default_options

    def initialize default_options = {}
      self.default_options = default_options
    end

    # 从一系列小图创建整张大图纹理
    def create_spritesheet(image_folder, plist, sheet, options = {})
      call_texture_packer(image_folder, plist, sheet, options)
    end

    # 转换一张图的纹理格式和图像格式
    def convert_format(src_image, dst_image, options = {})
      src_image_basename = File.basename(src_image)
      temp_plist = Boot::Tools.config.art_build_temp + "/plist/#{src_image_basename}.plist"
      call_texture_packer(src_image, temp_plist, dst_image, options)
    end

  private

    # For TexturePacker parameters, see TexturePacker --help output
    def call_texture_packer(image_folder, plist, sheet, options = {})
      options = default_options.merge options

      texture_format = options[:texture_format] || 'pvr2ccz'
      opt = options[:opt] || 'RGBA8888'
      premultiply_alpha = !! options[:premultiply_alpha]
      format = options[:format] || 'cocos2d'
      dpi = options[:dpi] || 72
      scale = options[:scale] || 1
      scale_mode = options[:scale_mode] || 'Smooth'
      dither = options[:dither] || 'none-nn'
      ext = options[:ext] || '.plist'

      algorithm = options[:algorithm] || 'MaxRects'
      size_constraints = options[:size_constraints] || 'POT'
      maxrects_heuristics = options[:maxrects_heuristics] || 'Best'
      force_word_aligned = !! options[:force_word_aligned]
      pack_mode = options[:pack_mode] || 'Best'
      shape_padding = options[:shape_padding] || 0
      border_padding = options[:border_padding] || 0
      extrude = options[:extrude] || 0
      multipack = !! options[:multipack]
      max_width = options[:max_width] || 2048
      max_height = options[:max_height] || 2048
      force_square = !! options[:force_square]
      trim_mode = options[:trim_mode] || 'CropKeepPos'
      trim_threshold = options[:trim_threshold] || 1

      replace = options[:replace] || false
      content_protection = options[:content_protection] || false
      enable_rotation = !! options[:enable_rotation]

      cmd = %Q{
        TexturePacker \
        --scale #{scale} \
        --scale-mode #{scale_mode} \
        --opt #{opt} \
        --algorithm #{algorithm} \
        --size-constraints #{size_constraints} \
        --maxrects-heuristics #{maxrects_heuristics} \
        #{force_word_aligned ? '--force-word-aligned' : ''} \
        --pack-mode #{pack_mode} \
        #{multipack ? '--multipack' : ''} \
        --texture-format #{texture_format} \
        #{premultiply_alpha ? '--premultiply-alpha' : ''} \
        --dpi #{dpi} \
        #{force_square ? '--force-squared' : ''} \
        --shape-padding #{shape_padding} \
        --border-padding #{border_padding} \
        --extrude #{extrude} \
        --format #{format} \
        --data #{plist}#{ext} \
        --sheet #{sheet} \
        --max-width #{max_width} \
        --max-height #{max_height} \
        #{replace ? '--replace ' + replace : ''} \
        #{content_protection ? '--content-protection ' + content_protection : ''} \
        --dither-#{dither} \
        #{enable_rotation ? '--enable-rotation' : '--disable-rotation'} \
        #{image_folder} \
        --trim-threshold #{trim_threshold} \
        --trim-mode #{trim_mode} \
        }
      puts "cmd:#{cmd}"
      system(cmd)
    end

  end

  ########################################################################
  # GlyphDesigner工具类

  class GlyphDesigner

    def initialize default_options = {}
      self.default_options = default_options
    end

  private

    # For GDCL parameters, see GDCL --help output
    def call_glyph_designer(project_file, output_file, options = {})
      options = default_options.merge options

      font_size = options[:font_size] || 24
      relative_size = options[:relative_size] || 1.0
      format = options[:format] || 'PlainText-fnt'
      ol = !! options[:outline]
      su = !! options[:substitute]

      system(%Q{
        GDCL \
        #{project_file} \
        #{output_file} \
        -fs #{font_size} \
        -rfs #{relative_size} \
        -fo #{format} \
        #{ol ? '-ol' : ''} \
        #{su ? '-su' : ''}
      })
    end

  end

  ########################################################################
  # GmApi 辅助类

  class GmApi

    def call_uri uri, options = {}
      uri = URI.parse(uri) unless uri.is_a? URI
      max_retry = options[:max_retry] || 3
      retry_interval = options[:retry_interval] || 1.0
      retries = 0

      while retries <= max_retry do
        puts "call_uri retries=#{retries} #{uri}"
        begin
          Net::HTTP.start(uri.host, uri.port) do |http|
            sign = sign_query(uri.query)
            query = "#{uri.path}?#{uri.query}&sign=#{sign}"
            while retries <= max_retry do
              puts "call_uri retries=#{retries}"
              res = http.request_post query, ''
              if res.code.to_i == 200
                result = JSON.parse(res.body)
                if result['success'] then
                  return true
                else
                  puts "failed code=200 body=#{res.body}"
                end
              else
                puts "failed code=#{res.code} body=#{res.body}"
              end
              retries += 1
              sleep retry_interval
            end
            puts "max retry reached"
            return false
          end
        rescue Exception => e
          puts "HTTP.start failed: #{e.message}"
        end
        retries += 1
        sleep retry_interval
      end

      puts 'max retry reached'
      return false
    end

  private

    def sign_query query
      str = ''
      params = CGI::parse(query)
      params.sort.each do |k, arr|
        k = k.to_s
        v = if arr and arr.length then arr[0] else '' end
        if k != 'sign' and v and v.length > 0
          str << URI.decode(v) << '#'
        end
      end
      str << 'a3ce6f7a541cda538f68b7eed7334043'
      Digest::MD5.hexdigest(str.encode('UTF-8'))
    end

  end

  ########################################################################
  # SoundUtil: 声音辅助类

  class SoundUtil

    if RUBY_PLATFORM =~ /darwin/
      OS = :MAC
    else
      OS = :UNKNOWN
    end

    attr_reader :last_play_time, :options

    def initialize options = {}
      @last_play_time = Time.now.to_i
      @options = options
      @options[:cooldown] ||= 1
      @options[:sound_root] ||= '.'
    end

    def play_file file
      if options[:cooldown] and options[:cooldown] > 0
        now = Time.now.to_i
        return if now - last_play_time < options[:cooldown]
        last_last_play_time = now
      end

      case OS
      when :MAC
        system("afplay #{options[:sound_root]}/#{file}")
      else
        raise "play_file: Your OS is not supported!"
      end
    end

  end

end