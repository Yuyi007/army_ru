
def ios_asset_root
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/proj.ios/Data/Raw'))
end

def operation_config_root
  File.expand_path(File.join(Boot::Tools.config.project_root,
    'operation'))
end

def android_debug_asset_root
  android_asset_root('proj_debug')
end

def android_product_asset_root
  android_asset_root('proj_product')
end

def android_asset_root(proj_name)
  File.expand_path(File.join(Boot::Tools.config.project_root,
    "/proj.android/#{proj_name}/race/src/main/assets"))
end

def android_skeleton_root()
  File.expand_path(File.join(Boot::Tools.config.project_root,
    "/proj.android/proj_skeletons/"))
end

def stream_root
  File.expand_path(File.join(Boot::Tools.config.project_root,
    '/Assets/StreamingAssets/'))
end


def copy_lua
  [ android_product_asset_root, ios_asset_root ].each do |dir|
    system("mkdir -p #{dir}")
    FileUtils.copy_file(lua_path, dir + '/cl.lc')
  end

  [ android_product_asset_root ].each do |dir|
    FileUtils.copy_file(stream_root + '/debug.lua', dir + '/debug.lua')
  end
end

def copy_config_lua
  if not File.exists?(config_lua_path)
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'debug'"
      f.puts "MODE = 'development'"
    end
  end

  [ android_debug_asset_root, android_product_asset_root, ios_asset_root ].each do |dir|
    system("mkdir -p #{dir}")
    FileUtils.copy_file(config_lua_path, dir + '/config.lua')
  end
end

def copy_config
  [ android_product_asset_root, ios_asset_root ].each do |dir|
    system("mkdir -p #{dir}")
    system("rm -f #{dir}/*.json #{dir}/*.db")

    system("cp -f #{stream_root}/bundles_*.json #{dir}/")
    system("cp -f #{stream_root}/sprites.json #{dir}/")

    system("cp -f #{stream_root}/*.db #{dir}/")

    game_config_scheme = ENV['RS_CONFIG_SCHEME']

    if game_config_scheme && game_config_scheme != 'default'
      system("cp -fv #{operation_config_root}/#{game_config_scheme}/*.db #{dir}/")
    end
  end
end

def copy_streaming_assets
  copy_lua
  copy_config_lua
  copy_config
end

def rsync_bundles
  "rsync -acv --delete-after --delete-excluded #{exclude_files} --exclude '*.db' --exclude '*.json' "
end

def copy_ios_bundles
  puts "ios_bundle_root=#{ios_bundle_root}"
  # system("cd #{ios_bundle_root} && svn up")

  copy_streaming_assets
  cmd = "#{rsync_bundles} #{ios_bundle_root}/ #{ios_asset_root}/bundles/"
  system(cmd)
  copy_bundle_specific_configs(ios_bundle_root, ios_asset_root)
  gen_meta_ios
end

def copy_bundle_specific_configs(bundle_root, asset_folder)
  system("mkdir -p #{asset_folder}")
  system("cp -fv #{bundle_root}/*.db #{asset_folder}/")
  system("cp -fv #{bundle_root}/bundles_*.json #{asset_folder}/")
  system("cp -fv #{bundle_root}/sprites.json #{asset_folder}/")
end

def copy_android_bundles(scheme)
  # system("cd #{android_bundle_root} && svn up")
  copy_streaming_assets
  if scheme == 'debug' then
    system("mkdir -p #{android_debug_asset_root}/bundles/")
    system("#{rsync_bundles} #{android_bundle_root}/ #{android_debug_asset_root}/bundles/")
    copy_bundle_specific_configs(android_bundle_root, android_debug_asset_root)
    gen_meta_android(android_debug_asset_root)
  elsif scheme == 'product' then
    system("mkdir -p #{android_product_asset_root}/bundles/")
    system("#{rsync_bundles} #{android_bundle_root}/ #{android_product_asset_root}/bundles/")
    copy_bundle_specific_configs(android_bundle_root, android_product_asset_root)
    gen_meta_android(android_product_asset_root)
  end
end

def copy_android_sdks()
  sdk_root = "#{fvsdk_root}/android"
  skeleton_root = android_skeleton_root()

  system("cp -f #{sdk_root}/firevale/Sample/app/libs/*.aar #{skeleton_root}/firevale/libs/")
  system("cp -f #{sdk_root}/360/Sample/app/libs/*.aar #{skeleton_root}/360/libs/")
  system("cp -f #{sdk_root}/xiaomi/Sample/app/libs/*.aar #{skeleton_root}/xiaomi/libs/")
  system("cp -f #{sdk_root}/yyb/Sample/app/libs/*.aar #{skeleton_root}/yyb/libs/")
  system("cp -f #{sdk_root}/huawei/Sample/app/libs/*.aar #{skeleton_root}/huawei/libs/")
  system("cp -f #{sdk_root}/oppo/Sample/app/libs/*.aar #{skeleton_root}/oppo/libs/")
  system("cp -f #{sdk_root}/vivo/Sample/app/libs/*.aar #{skeleton_root}/vivo/libs/")
  system("cp -f #{sdk_root}/uc/Sample/app/libs/*.aar #{skeleton_root}/uc/libs/")
  system("cp -f #{sdk_root}/coolpad/Sample/app/libs/*.aar #{skeleton_root}/coolpad/libs/")
  system("cp -f #{sdk_root}/lenovo/Sample/app/libs/*.aar #{skeleton_root}/lenovo/libs/")
  system("cp -f #{sdk_root}/meizu/Sample/app/libs/*.aar #{skeleton_root}/meizu/libs/")
  system("cp -f #{sdk_root}/baidu/Sample/app/libs/*.aar #{skeleton_root}/baidu/libs/")
  system("cp -f #{sdk_root}/amigo/Sample/app/libs/*.aar #{skeleton_root}/amigo/libs/")
  system("cp -f #{sdk_root}/samsung/Sample/app/libs/*.aar #{skeleton_root}/samsung/libs/")
  system("cp -f #{sdk_root}/bluestack/Sample/app/libs/*.aar #{skeleton_root}/bluestack/libs/")
  system("cp -f #{sdk_root}/4399/Sample/app/libs/*.aar #{skeleton_root}/4399/libs/")
  system("cp -f #{sdk_root}/downjoy/Sample/app/libs/*.aar #{skeleton_root}/downjoy/libs/")
  system("cp -f #{sdk_root}/ewan/Sample/app/libs/*.aar #{skeleton_root}/ewan/libs/")
  system("cp -f #{sdk_root}/douyu/Sample/app/libs/*.aar #{skeleton_root}/douyu/libs/")
end

def copy_android_icons
  sdk_root = "#{fvsdk_root}/android"
  app_icon_root = "#{ENV['ART']}/app_icons/android"
  skeleton_root = android_skeleton_root()

  system("cp -frv #{app_icon_root}/firevale/res #{skeleton_root}/common/")
  system("cp -frv #{app_icon_root}/360/res #{skeleton_root}/360/")
  system("cp -frv #{app_icon_root}/baidu/res #{skeleton_root}/baidu/")
  system("cp -frv #{app_icon_root}/uc/res #{skeleton_root}/uc/")
  system("cp -frv #{app_icon_root}/lenovo/res #{skeleton_root}/lenovo/")
  system("cp -frv #{app_icon_root}/yyb/res #{skeleton_root}/yyb/")
  system("cp -frv #{app_icon_root}/4399/res #{skeleton_root}/4399/")
  system("cp -frv #{app_icon_root}/downjoy/res #{skeleton_root}/downjoy/")
  system("cp -frv #{app_icon_root}/bluestack/res #{skeleton_root}/bluestack/")
  system("cp -frv #{app_icon_root}/vivo/res #{skeleton_root}/vivo/")
  system("cp -frv #{app_icon_root}/douyu/res #{skeleton_root}/douyu/")
end

def zip_bundles(root)
  # keep some bundles in jar and zip all others
  system("cd #{root} && rm -f data*.zip && rm -rf bundles_keep")
  system("cd #{root} && mv bundles bundles_keep && mkdir -p bundles")

  bundles_zip = {}
  zip_size = 0
  zip_index = 0
  zip_file = "data#{zip_index}.zip"

  Dir.chdir("#{root}/bundles_keep/")
  Dir.glob("**/*") do |item|
    next if item == '.' or item == '..'
    next if File.directory?(item)

    size = File.stat(item).size
    bundles_zip[zip_file] = bundles_zip[zip_file] || {}
    bundles_zip[zip_file][item] = size

    zip_size += size
    if zip_size > 160 * 1024 * 1024 then
      zip_size = 0
      zip_index += 1
      zip_file = "data#{zip_index}.zip"
    end
  end

  bundles_zip.each do |zip_file, bundle_files|
    bundle_files.each do |file, _|
      dirname = File.dirname(file)
      system("cd #{root} && mkdir -p bundles/#{dirname} && mv bundles_keep/#{file} bundles/#{file}")
    end
    puts "creating data file #{zip_file}..."
    # zip bundles
    system("cd #{root} && rm -f #{zip_file} && zip -rX #{zip_file} bundles/")
    system("cd #{root} && rm -rf bundles && mkdir -p bundles/")
  end

  system("cd #{root} && rm -rf bundles && mv bundles_keep bundles")

  # write zip info
  File.open("#{root}/data.json", 'w+') do |f|
    f.write(JSON.pretty_generate(bundles_zip).to_s)
  end
end

def gen_meta_ios
  Boot::Tools::ResourcePublisher.new.generate_meta('ios', "#{ios_asset_root}", human: true)
end

def gen_meta_android root
  Boot::Tools::ResourcePublisher.new.generate_meta('android', root, human: true)
end

namespace :build do
  desc 'Set to Debug development package'
  task :debug do
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'debug'"
      f.puts "MODE = 'development'"
    end
    copy_config_lua
  end

  desc 'Set to test compiled package'
  task :test do
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'compiled'"
      f.puts "MODE = 'production'"
      f.puts "USAGE = 'test'"
      f.puts 'INSPECT = 0'
    end
    copy_config_lua
  end

  desc 'Set to demo compiled package'
  task :demo do
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'compiled'"
      f.puts "MODE = 'production'"
      f.puts "USAGE = 'demo'"
      f.puts 'INSPECT = 0'
    end
    copy_config_lua
  end



  desc 'Set to Device development package'
  task :device_sdk do
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'compiled'"
      f.puts "MODE = 'development'"
      f.puts "LOCATION = 'cn'"
      f.puts "PLATFORM = 'ios'"
      f.puts "SDK = 'yousi'"
    end
    copy_config_lua
  end

  desc 'Set to Device review package'
  task :review do
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'compiled'"
      f.puts "MODE = 'production'"
      f.puts "USAGE = 'review'"
      f.puts 'INSPECT = 0'
    end
    copy_config_lua
  end

  desc 'Set to review sdk package'
  task :review_sdk do
    puts "build rake:review_sdk"
    File.open(config_lua_path, 'w+') do |f|
      f.puts "SCRIPT = 'compiled'"
      f.puts "MODE = 'production'"
      f.puts "USAGE = 'review'"
      f.puts "LOCATION = 'cn'"
      f.puts "SDK = 'yousi'"
      f.puts 'INSPECT = 0'
    end
    copy_config_lua
  end

  desc 'Copy needed streaming assets'
  task :copy_streaming_assets do
    copy_streaming_assets
  end

  desc 'Copy all platforms bundle files'
  task copy_bundles: [:copy_ios_bundles, :copy_android_bundles] do
  end

  def exclude_files
    excludes.map {|x| "--exclude '#{x}'"}.join(' ')
  end

  desc 'Copy ios bundle files to project asset folder'
  task :copy_ios_bundles do
    copy_ios_bundles
  end

  desc 'Copy android bundle files to project asset folder'
  task :copy_android_bundles, :scheme do |_t, args|
    copy_android_bundles(args.scheme)
  end

  desc 'Copy android sdk files to project folder'
  task :copy_android_sdks do
    copy_android_sdks()
  end

  desc 'Copy android res files to project folder'
  task :copy_android_icons do
    copy_android_icons
  end

  desc 'Copy all assets needed'
  task copy_all: [:copy_bundles] do
  end

  desc 'generate ios meta'
  task gen_meta_ios: [:copy_ios_bundles] do
    gen_meta_ios
  end

  desc 'generate android meta'
  task gen_meta_android: [:copy_android_bundles] do
    gen_meta_android
  end
end
