require 'yaml'

namespace :apk do
  APK_CONFIG = YAML.load(IO.read('apk.yml'))

  def apk_config
    @apk_config ||= APK_CONFIG
  end

  def get_apk_config(name)
    cfg = apk_config[name]
  end

  def get_apk_args(name)

    cfg = get_apk_config(name)

    if cfg['base_skeleton'].to_s.empty?
      cfg['base_skeleton'] = cfg['skeleton']
    end

    [
      cfg['scheme'] || 'dev',
      cfg['skeleton'],
      cfg['usage'] || 'default',
      cfg['package'],
      cfg['versionCode'],
      cfg['versionName'],
      name,
      cfg['name'] || 'rc',
      cfg['sdk'] || 'standard',
      cfg['location'] || 'cn',
      cfg['signing'] || 'default',
      cfg['base_skeleton']
    ].join(' ')

  end


  def get_apk_debug_args(name, type = 'debug')

    cfg = get_apk_config(name).clone

    if cfg['base_skeleton'].to_s.empty?
      cfg['base_skeleton'] = cfg['skeleton']
    end

    package_name = cfg['package']
    if not cfg['fix_package']
      package_name = "#{package_name}_#{type}"
    end

    [
      'dev',
      cfg['skeleton'],
      cfg['usage'] || 'default',
      package_name,
      cfg['versionCode'],
      cfg['versionName'],
      "#{name}_#{type}",
      "#{name}_#{type}_race",
      cfg['sdk'] || 'standard',
      cfg['location'] || 'cn',
      cfg['signing'] || 'default',
      cfg['base_skeleton']
    ].join(' ')

  end


  APK_CONFIG.each do |name, _|
    cfg = get_apk_config(name)
    desc "build #{cfg['scheme']} #{name} apk"
    task name do
      system("$LAU/package_apk.sh #{get_apk_args(name)}")
    end
  end

  task :fix_gradle do
    files = FileList["#{unity_dir}/proj.android/**/*build.gradle"]
    files.each do |file|
      puts file
      content = IO.read(file)
      content.gsub!(/versionCode \d+/, '')
      content.gsub!(/versionName .+/, '')
      IO.write(file, content)
    end
  end

  task :fix_dataeye do
    files = FileList["#{unity_dir}/proj.android/**/*AndroidManifest.xml"]
    dataeye = YAML.load(IO.read("#{unity_dir}/dataeye.yml"))
    dataeye = dataeye['dataeye']

    files.each do |file|
      content = IO.read(file)
      sdk = File.dirname(file)
      sdk = File.basename(sdk)
      next unless dataeye[sdk]
      puts sdk
      content.gsub!('C8ADE039921448B063399E59A128BA920', dataeye[sdk])
      IO.write(file, content)
    end
  end
end
