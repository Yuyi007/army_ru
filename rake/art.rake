# encoding: utf-8
# art.rake
# require "fastimage"

class BuildArt
  class << self
    def art_dir
      Boot::Tools.config.art_root
    end

    def streaming_dir
      Boot::Tools.config.osx_resource_root
    end

    def content_protection
      '239563134a24b40b0c6e67ccd83ad589'
    end

    def unity_dir
      puts ">>>>unity_dir:#{Boot::Tools.config.project_root}"
      Boot::Tools.config.project_root + '/Assets/images'
    end

    def image_mask_dir
      Boot::Tools.config.project_root + '/Assets/images_mask'
    end

    def image_dir
      Boot::Tools.config.project_root + '/Assets/images'
    end

    def build_sheets_opt(sheetOpts)
      sheetOpts.each do |sheetOpt|
        sheetOpt.sheets.each do |sheet|
          BuildArt.build_sheets([sheet], sheetOpt.opt)
        end
      end
    end

    def build_sheets(sheets, options = {})
      packer = Boot::Tools::TexturePacker.new

      sheets.each do |v|
        puts "check v:#{v}"
        folder = v[:folder]
        name = v[:name]
        alpha = !v[:jpg]

        if folder.is_a? Array
          image_folder = folder.map { |f| "#{art_dir}/#{f}" }.join(' ')
        else
          image_folder = "#{art_dir}/#{folder}"
          alpha = ! (v[:jpg] || folder['jpg'])
        end

        options ||= {}
        opts = options.merge v

        alpha = false if options[:jpg]
        alpha = options[:alpha] if !options[:alpha].nil?

        opts_ccb = { opt: 'RGBA8888' }.merge opts
        opts_unity = { opt: alpha ? 'RGBA4444' : 'RGB565',
                       dither: alpha ? 'fs-alpha' : 'none-nn',
                       format: 'unity', texture_format: 'png', ext: '.txt', force_square: true, max_width: 4096, max_height: 2048 }.merge(opts).merge(opts[:unity] || {})

        if !alpha then
          opts_unity[:force_square] = true
          opts_unity[:shape_padding] = 0
          opts_unity[:extrude] = 0
        end

        opts_sheet = opts_unity.merge ({ format: 'unity-texture2d', ext: '.tpsheet' })
        name = "#{name}{n1}" if opts_unity[:multipack]

        if opts_unity[:tpsheet]
          packer.create_spritesheet(image_folder, "#{unity_dir}/#{name}", "#{unity_dir}/#{name}.png", opts_sheet)
        else
          packer.create_spritesheet(image_folder, "#{unity_dir}/#{name}", "#{unity_dir}/#{name}.png", opts_unity)
        end
      end
    end
  end
end

namespace :art do
  def create_sheetOpt(&blk)
    Boot::Tools::SheetOption.new(&blk)
  end

  desc 'Open art folder'
  task :open do
    system("open #{Boot::Tools.config.art_root}")
  end

  desc 'Build all art resources into unity project'
  task build: [:build_ui] do
  end

  desc 'Build ui resources'
  task :build_ui do 
    Dir.chdir BuildArt.art_dir + '/ui' do
      opt = { shape_padding: 1, extrude: 1, tpsheet: true }
      sheetOpts = Dir.glob('*').inject([]) do |res, name|
        next res unless File.directory? name
        puts "build_ui name = #{name}"

        sheetOpt = create_sheetOpt
        sheetOpt.sheets << { folder: 'ui/' + name, name: "ui/#{name}" }

        sheetOpt.opt = case name
          when /^9symbol/
            opt.merge(enable_rotation: false, extrude: 0, opt: 'RGBA8888', dither: 'none-nn')
          when /^bgs/
            opt.merge(max_width: 2048, alpha: false, opt: 'RGB888', dither: 'none-nn', enable_rotation: false)
          when /^pic/
            opt.merge(max_height: 2048, max_width: 2048, opt: 'RGBA8888', dither: 'none-nn', enable_rotation: false, force_square: true)
          when /^icon/
            opt.merge(max_height: 1024, max_width: 1024, trim_mode: 'None', force_square: true, multipack: true)
          else
            opt.merge({})
          end
        res << sheetOpt
      end
      BuildArt.build_sheets_opt(sheetOpts)
    end

    #generate sprite asset
    puts "Building sprite asset"
    system("#{Boot::Tools.config.unity_exec} -projectPath #{Boot::Tools.config.project_root + '/Assets/images'} -batchmode -quit -executeMethod LBootEditor.AssetHelper.CreateSpriteAssets -logFile ")
  end

  # desc 'Build所有美术资源'
  # task build: [:build_ui, :build_ui_anim, :build_icons, :build_bg, :build_news, :build_map, :split_alpha] do
  # end

  # desc 'Build界面资源'
  # task :build_ui do
  #   Dir.chdir BuildArt.art_dir + '/png' do
  #     opt = { shape_padding: 1, extrude: 1, tpsheet: true }

  #     sheetOpts = Dir.glob('*').inject([]) do |res, name|
  #       next res unless File.directory? name
  #       puts "name = #{name}"

  #       sheetOpt = create_sheetOpt
  #       sheetOpt.sheets << { folder: 'png/' + name, name: "ui/#{name}" }

  #       sheetOpt.opt = case name
  #                      when '9symbol'
  #                        opt.merge(enable_rotation: false, extrude: 0, opt: 'RGBA8888', dither: 'none-nn')
  #                      when 'loading_bg'
  #                        opt.merge(jpg: true, max_height: 2048, max_width: 2048)
  #                      when 'login'
  #                        opt.merge(force_square: true)
  #                      when 'main', 'zhandou'
  #                        opt.merge(force_square: true, max_height: 1024, max_width: 1024)
  #                      when 'event', 'AD'
  #                        opt.merge(force_square: true)
  #                      when 'symbol', 'symbol2'
  #                        opt.merge(max_height: 2048, max_width: 2048, opt: 'RGBA8888', dither: 'none-nn', enable_rotation: false, force_square: true)
  #                      when /comic/
  #                        sheetOpt.sheets.first[:name] = "comics/#{name}"
  #                        name['png'] ? opt : opt.merge(jpg: true)
  #                      when 'creation'
  #                        opt.merge(force_square: false)
  #                      else
  #                        opt.merge({})
  #                     end

  #       res << sheetOpt
  #     end

  #     BuildArt.build_sheets_opt(sheetOpts)
  #   end
  # end

  # desc 'Build图标'
  # task :build_icons do
  #   Dir.chdir BuildArt.art_dir + '/icons' do
  #     sheetOpts = Dir.glob('*').inject([]) do |res, name|
  #       next res unless File.directory? name
  #       # next res unless name == 'life_guide' || name ==  'gve_cam_small' || name == 'gve_cam_big'
  #       # next res unless name == 'wushuhall'
  #       # next res unless name == 'garment_event'

  #       sheetOpt = create_sheetOpt
  #       sheetOpt.sheets << { folder: 'icons/' + name, name: 'icons/' + name }
  #       sheetOpt.opt = { shape_padding: 0, extrude: 0, tpsheet: true}
  #       case name
  #       when /^(skill|item|equip|garment)$/, /^(equip|item|garment)_(a|b|c|d|e|s)$/,
  #         'food', 'chapters_review', 'practic_counterpart', 'leader_counterpart', 'life_guide', 'gve_cam_small', 'gve_cam_big'
  #         sheetOpt.sheets.each do |o|
  #           o[:name] = "icons/#{name}/#{name}{n}"
  #         end

  #         sheetOpt.opt[:max_width] = 1024
  #         sheetOpt.opt[:max_height] = 1024
  #         sheetOpt.opt[:multipack] = true
  #         sheetOpt.opt[:jpg] = true
  #         sheetOpt.opt[:opt] = 'RGB888'
  #         sheetOpt.opt[:dither] = 'none-nn'
  #       when /^event/
  #         sheetOpt.opt[:jpg] = true
  #       when 'empty'
  #         sheetOpt.opt[:jpg] = true
  #       when 'classicon_preview'
  #         sheetOpt.opt[:jpg] = true
  #       when 'fac_ftuepic'
  #         sheetOpt.opt[:jpg] = true
  #       when /^(head_pot|npc|chenghao)$/
  #         sheetOpt.sheets.each do |o|
  #           o[:name] = "icons/#{name}/#{name}{n}"
  #         end
  #         sheetOpt.opt[:force_square] = true
  #         sheetOpt.opt[:trim_mode] = 'None'
  #         sheetOpt.opt[:max_width] = 1024
  #         sheetOpt.opt[:max_height] = 1024
  #         sheetOpt.opt[:multipack] = true
  #         sheetOpt.opt[:jpg] = false
  #       when 'preview', 'coach', 'guild', 'wushuhall', 'mobileapp', 'power_up'
  #         sheetOpt.sheets.each do |o|
  #           o[:name] = "icons/#{name}/#{name}{n}"
  #         end
  #         sheetOpt.opt[:force_square] = true
  #         sheetOpt.opt[:trim_mode] = 'None'
  #         sheetOpt.opt[:max_width] = 512
  #         sheetOpt.opt[:max_height] = 512
  #         sheetOpt.opt[:multipack] = true
  #         sheetOpt.opt[:jpg] = false
  #       when 'garment_event'
  #         sheetOpt.sheets.each do |o|
  #           o[:name] = "icons/#{name}/#{name}{n}"
  #         end
  #         sheetOpt.opt[:force_square] = true
  #         sheetOpt.opt[:max_width] = 1024
  #         sheetOpt.opt[:max_height] = 1024
  #         sheetOpt.opt[:multipack] = true
  #         sheetOpt.opt[:jpg] = false
  #       when 'sns'
  #         sheetOpt.sheets.each do |o|
  #           o[:name] = "icons/#{name}/#{name}{n}"
  #         end
  #         sheetOpt.opt[:multipack] = true
  #         sheetOpt.opt[:scale] = 0.8
  #         sheetOpt.opt[:max_width] = 512
  #         sheetOpt.opt[:max_height] = 512
  #         sheetOpt.opt[:force_square] = true
  #         sheetOpt.opt[:trim_threshold] = 2
  #       when 'common', 'activity', 'technology'
  #         sheetOpt.opt[:force_square] = true
  #       when 'campaigns'
  #         sheetOpt.opt[:force_square] = false
  #       when 'zhuanjing'
  #         sheetOpt.opt[:force_square] = true
  #       when 'doober'
  #         sheetOpt.opt[:force_square] = true
  #         sheetOpt.opt[:trim_mode] = 'None'
  #       else
  #         sheetOpt.opt[:force_square] = false
  #         sheetOpt.opt[:jpg] = false
  #       end

  #       res << sheetOpt
  #     end
  #     BuildArt.build_sheets_opt(sheetOpts)
  #   end
  # end

  # def size(file)
  #   # res = FastImage.size(file) #{}`identify "#{file}"`
  #   res = `identify "#{file}"`
  #   # puts ">>> file:#{file} res:#{res}"
  #   # [res[0], res[1]]
  #   size = res.split(' ')[2]
  #   width, height = size.split('x').map(&:to_i)
  #   [width, height]
  # end

  # def clamped_scale(file, max)
  #   width, height = size(file)
  #   long = [width, height].max
  #   scale = max.to_f / long
  #   scale = 1 if scale > 1
  #   scale
  # end

  # def clamped_scale_with_size(file, max)
  #   width, height = size(file)
  #   long = [width, height].max
  #   scale = max.to_f / long
  #   scale = 1 if scale > 1
  #   [scale, width, height]
  # end

  # desc 'Build界面动画'
  # task :build_ui_anim do
  #   Dir.chdir BuildArt.art_dir do
  #     BuildArt.build_sheets(Dir.glob('uianim/*').map do |name|
  #       opt = { folder: name, name: name }
  #       if name['eff_indiana'] || (name['eff_button'] && !name['eff_button001']) || name['vr_add']
  #         opt[:scale] = 0.5
  #       end
  #       opt
  #     end, unity: { tpsheet: true, trim_mode: 'None' })
  #   end
  # end

  # desc 'Build背景图'
  # task :build_bg do
  #   Dir.chdir BuildArt.art_dir do
  #     Dir.glob('bg/*').each do |name|
  #       scale = clamped_scale(name, 1024)
  #       BuildArt.build_sheets([{ folder: name, name: 'bgs/' + File.basename(name, '.*') }],
  #                             unity: { tpsheet: true, scale: scale, max_width: 1024, max_height: 1024 })
  #     end
  #   end
  # end

  # task :fix_shadow do
  #   alpha = false
  #   opts_unity = {opt: 'RGBA8888',
  #                  dither: 'none-nn',
  #                  texture_format: 'png', format: 'unity-texture2d', ext: '.tpsheet', force_square: true, max_width: 2048, max_height: 2048, scale: 0.3}
  #   packer =  Boot::Tools::TexturePacker.new

  #   Dir.chdir(Boot::Tools.config.project_root) do
  #     packer.create_spritesheet('Assets/images/others/feet_shadow.png', "Assets/images/others/others", "Assets/images/others/others.png", opts_unity)
  #   end
  # end

  # desc 'Build map'
  # task :build_map do
  #   Dir.chdir BuildArt.art_dir do
  #     data = {}
  #     puts "dir.pwd:#{Dir.pwd}"
  #     Dir.glob('map/*').each do |name|
  #       puts "sub map name:#{name}"
  #       max = 1024
  #       scale, width, height = clamped_scale_with_size(name, max)
  #       # scale, width, height = clamped_scale_with_size("#{Dir.pwd}/#{name}", max)
  #       sprite_name = File.basename(name, '.*')
  #       o = {
  #         sprite: sprite_name,
  #         width: width,
  #         height: height
  #       }
  #       data[o[:sprite]] = o
  #     end

  #     BuildArt.build_sheets([{ folder: 'map', name: 'map/maps{n}' }],
  #                           jpg: true, unity: { tpsheet: true, scale: 0.8, max_width: 2048, max_height: 2048, multipack: true })

  #     puts "final map data:#{data}"
  #     IO.write(BuildArt.streaming_dir + '/' + 'map.json', JSON.pretty_generate(data))
  #   end
  # end

  # desc 'Build news图'
  # task :build_news do
  #   Dir.chdir BuildArt.art_dir do
  #     BuildArt.build_sheets([{ folder: 'news', name: 'news/news{n}' }],
  #                           jpg: true, unity: { tpsheet: true, scale: 0.69, max_width: 512, max_height: 512, jpg: true, multipack: true })
  #   end
  # end

  # SPLIT_MASKS = [
  #   'ui/login',
  #   'ui/main',
  #   'ui/zhandou',
  #   'ui/symbol',
  #   'ui/symbol2',
  #   'ui/AD',
  #   'icons/mobileapp',
  #   'icons/activity',
  #   'icons/technology',
  #   'ui/event',
  #   'icons/zhuanjing'
  # ]

  # SPLIT_DIR = [
  #   'icons/head_pot/',
  #   'icons/npc/',
  #   'icons/chenghao/',
  #   'icons/guild/',
  #   'icons/sns/',
  #   'icons/preview/',
  #   'icons/coach/',
  #   'icons/wushuhall/',
  #   'icons/mobileapp/',
  #   'icons/power_up/',
  #   'icons/garment_event/',
  # ]

  # def split_alpha(path, out_path)
  #   dir = File.dirname(out_path)
  #   system("mkdir -p #{dir}")
  #   res = `identify -format '%[channels]' #{path}`


  #   if res == 'srgb' || res == 'rgb' || res == 'gray'
  #     puts "#{path} has no alpha channel (format=#{res}), skipping."
  #   else
  #     puts "#{path} is #{res}. spliting alpha"
  #     system("convert #{path} -channel Alpha -separate #{out_path}")
  #     system("convert #{path} -channel Alpha -threshold 100%% +channel #{path}")
  #     system("convert #{path} -alpha off #{path}")
  #   end
  # end

  # task :split_alpha do

  #   SPLIT_MASKS.each do |file|
  #     path = BuildArt.image_dir + "/#{file}.png"
  #     next unless File.exists?(path)
  #     out_path = BuildArt.image_mask_dir + "/#{file}_mask.png"
  #     split_alpha(path, out_path)
  #   end

  #   SPLIT_DIR.each do |dir|
  #     files = FileList[BuildArt.image_dir + "/#{dir}/*.png"]
  #     files.each do |path|
  #       file = File.basename(path, '.png')
  #       out_path = BuildArt.image_mask_dir + "/#{dir}/#{file}_mask.png"
  #       split_alpha(path, out_path)
  #     end
  #   end
  # end
end
