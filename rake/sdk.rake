KFS_ROOT = "#{ENV['KFS']}"
KFC_ROOT = "#{ENV['KFC']}"
SDK_ROOT = 'proj.android/proj_skeletons'
KFS_SDK_ROOT = "#{KFS_ROOT}/client/scripts/game/sdk"
FV_SDK_ROOT = "#{KFS_ROOT}/../fvsdks"

def init_sdk(sdk_name)
  puts "gen sdk: #{sdk_name}"
  puts 'init sdk basic environment param:'
  puts "ENV[KFS]:#{KFS_ROOT}"
  puts "ENV[KFC]:#{KFC_ROOT}"
  puts "FV_SDK_ROOT: #{FV_SDK_ROOT}"
  # ROOT_PATH="$workPath/proj.android/proj_skeletons"
  # SDK_PATH="$workPath/proj.android/proj_skeletons/$SDK_NAME"
  sdk_path = "#{SDK_ROOT}/#{sdk_name}"
  kfs_sdk_path = "#{KFS_SDK_ROOT}/#{sdk_name}"
  puts "init kfc sdk path:#{sdk_path}"
  # system "rm -rf #{sdk_path}"
  # 建立sdk目录
  system "mkdir -p #{sdk_path}/app #{sdk_path}/libs #{sdk_path}/src/com/firevale/kfc/"

  # 拷贝build.gradle模版
  unless File.exist?("#{sdk_path}/app/build.gradle")
    system "cp -f #{SDK_ROOT}/fv/app/build.gradle #{sdk_path}/app/"
  end


  # copy FVSDKKOF
  unless File.exist?("#{sdk_path}/src/com/firevale/kfc/FVSDKKOF.java")
    system "cp -f #{SDK_ROOT}/fv/src/com/firevale/kfc/FVSDKKOF.java #{sdk_path}/src/com/firevale/kfc/"
  end

  # 拷贝AndroidManifest模版
  unless File.exist?("#{sdk_path}/AndroidManifest.xml")
    system "cp -f #{SDK_ROOT}/fv/AndroidManifest.xml #{sdk_path}/"
    data = IO.read("#{sdk_path}/AndroidManifest.xml")
    data = data.gsub("\"com.firevale.kfc\"", "\"com.firevale.kfc.#{sdk_name}\"")
    # data = data.gsub("#Template_quest_condition", "require \"#{handler_path_name}\"\n#Template_quest_condition")
    File.open("#{sdk_path}/AndroidManifest.xml", 'w+') do |f|
      f.write(data)
    end
  end

  puts "init kfs sdk path: #{kfs_sdk_path}"
  # system "rm -rf #{kfs_sdk_path}"
  # system "cp -rf #{KFS_SDK_ROOT}/firevale #{KFS_SDK_ROOT}/#{sdk_name}/"

  # system "mv #{kfs_sdk_path}/SDKFirevale.lua #{kfs_sdk_path}/SDK#{sdk_name}.lua"
  # system "mv #{kfs_sdk_path}/LoginViewFirevale.lua #{kfs_sdk_path}/LoginView#{sdk_name}.lua"

  if File.exist?("#{FV_SDK_ROOT}")
    puts "FV_SDK_ROOT:#{FV_SDK_ROOT} exist,\n git pull"
    # 更新fvsdks项目到最新
    system "cd #{FV_SDK_ROOT}\n git pull"
  else
    puts "FV_SDK_ROOT:#{FV_SDK_ROOT} not exist"
    # 如果还没有下载fvsdks项目，要从gitpub clone：
    system "git clone https://gitpub.firevale.com/platform/fvsdks.git #{FV_SDK_ROOT}"
   end

  # copy relevant libs
  spec_sdk_name = sdk_name
  if sdk_name == "qihoo"
    spec_sdk_name = "360"
  end

  system("cp -f #{FV_SDK_ROOT}/android/#{spec_sdk_name}/Sample/app/libs/*.aar #{sdk_path}/libs/")


  data = IO.read('apk.yml')
  unless data.include?("#{sdk_name}:")
    data = data.gsub('#template_apk', "
#{sdk_name}:
  name: 中国惊奇先生
  scheme: prod
  skeleton: '#{sdk_name}'
  package: com.firevale.kfc.#{sdk_name}
  versionCode: 1
  versionName: '1.0'
  sdk: #{sdk_name}
  location: cn
  base_skeleton: fv
  #template_apk")
    # data = data.gsub("#Template_quest_condition", "require \"#{handler_path_name}\"\n#Template_quest_condition")
    File.open('apk.yml', 'w+') do |f|
      f.write(data)
    end
  end
end

namespace :sdk do
  desc 'Gen basic sdk files'
  task :init, [:sdk] do |t, args|
    sdk_name = args[:sdk]
    init_sdk(sdk_name)
  end
end
