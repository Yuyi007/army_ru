# encoding: utf-8
# publish.rake

require 'yaml'

namespace :publish do
  CDN_CONFIG = YAML.load(IO.read('cdn.yml'))
  def config
    @config ||= OpenStruct.new(CDN_CONFIG)
  end

  def all_platforms
    %w(editor ios android)
  end

  def excludes
    [
      'debug.lua',
      'config.lua',
      'version.tmp',
      '.DS_Store',
      'all_versions.tmp',
      '*.json',
      '*.manifest',
      '*.meta',
    ]
  end

  def includes
    [
      'bundles_*.json',
      'sprites.json',
    ]
  end

  def deploy_with_tencent_cdn(platform, opt)
    Boot::Tools::ResourcePublisher.new.publish(platform,
     tencent_cdn: true,
     url: opt['url'],
     custom_options: opt,
     publish_dir: opt['publish_dir'] || opt['name'],
     game_config_scheme: opt['game_config_scheme'],
     excludes: excludes,
     includes: includes)
  end

  def clean_tencent_cdn(opt)
    res = system("bin/tencent_cdn_clean.rb #{opt['appid']} #{opt['secret_id']} #{opt['secret_key']} #{opt['bucket']}")
    if not res then
      puts "clean_tencent_cdn failed!"
    end
  end

  def deploy_with_ks_cdn(platform, opt)
    Boot::Tools::ResourcePublisher.new.publish(platform,
     ks_cdn: true,
     url: opt['url'],
     custom_options: opt,
     publish_dir: opt['publish_dir'] || opt['name'],
     game_config_scheme: opt['game_config_scheme'],
     excludes: excludes,
     includes: includes)
  end

  def clean_ks_cdn(platform, opt)
    ak = opt['app_key']
    sk = opt['secret_key']
    bucket = opt['bucket']
    publish_dir = File.expand_path(File.join(Boot::Tools.config.publish_root,
      (opt['publish_dir'] || opt['name']), platform))
    remote_dir = opt['bucket_dir']
    res = system("bin/kscdn_deploy.py #{ak} #{sk} #{bucket} #{publish_dir} #{remote_dir} clean")
    if not res then
      puts "clean_ks_cdn failed!"
    end
  end

  def deploy_with_ssh(platform, opt)
    Boot::Tools::ResourcePublisher.new.publish(platform,
     ssh: true,
     url: opt['url'],
     rsync_host: opt['host'],
     rsync_dst: opt['dst'],
     local: opt['local'],
     publish_dir: opt['publish_dir'] || opt['name'],
     game_config_scheme: opt['game_config_scheme'],
     excludes: excludes,
     includes: includes)
  end

  def deploy_with_rsync(platform, opt)
    Boot::Tools::ResourcePublisher.new.publish(platform,
      url: opt['url'],
      rsync_module: opt['rsync_module'],
      rsync_pass: opt['rsync_pass'],
      publish_dir: opt['publish_dir'] || opt['name'],
      game_config_scheme: opt['game_config_scheme'],
      excludes: excludes,
      includes: includes)
  end

  task :bundle do
    system 'bin/bash bundle install --local &>/dev/null'
  end

  CDN_CONFIG.keys.each do |name|
    desc "deploy cdn #{name}"
    task name => :bundle do |_, args|
      o = config.send(name)
      platforms = all_platforms

      platforms = args.extras if args.extras.length > 0

      platforms.each do |platform|
        if o['tencent_cdn']
          deploy_with_tencent_cdn platform, o
        elsif o['ks_cdn']
          deploy_with_ks_cdn platform, o
        elsif o['ssh']
          deploy_with_ssh platform, o
        else
          deploy_with_rsync platform, o
        end
      end
    end

    if config.send(name)['tencent_cdn']
      desc "clean tencent cdn #{name}"
      task "#{name}_clean" do |_, args|
        o = config.send(name)
        clean_tencent_cdn o
      end
    end

    if config.send(name)['ks_cdn']
      desc "clean ks cdn #{name}"
      task "#{name}_clean" do |_, args|
        platforms = all_platforms

        platforms = args.extras if args.extras.length > 0

        o = config.send(name)
        platforms.each do |platform|
          clean_ks_cdn platform, o
        end
      end
    end

    desc "deploy test cdn #{name}"
    task "#{name}_test" => :bundle do |_, args|
      platforms = all_platforms

      platforms = args.extras if args.extras.length > 0

      o = config.send(name).merge(name: "#{name}test")
      platforms.each do |platform|
        deploy_with_rsync platform, o
      end
    end

    desc "apply cdn #{name}"
    task "#{name}_apply" => :bundle do |_t, _args|
      o = config.send(name).merge(name: "#{name}")
      success = Boot::Tools::ResourcePublisher.new.apply_last_publish_client_version(
        o['gm'],
        publish_dir: o['publish_dir'] || o['name'],
        max_retry: 30)
      raise "apply cdn #{name} failed!" if not success
    end

    desc "apply test cdn #{name}"
    task "#{name}_test_apply" => :bundle do |_t, _args|
      o = config.send(name).merge(name: "#{name}test")
      success = Boot::Tools::ResourcePublisher.new.apply_last_publish_client_version(
        o['gm_test'],
        publish_dir: o['publish_dir'] || o['name'],
        max_retry: 30)
      raise "apply test cdn #{name} failed!" if not success
    end
  end
end
