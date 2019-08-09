# encoding: utf-8

$:.unshift(File.dirname(__FILE__))
require 'tools'

Boot::Tools.config = Boot::Tools::ProjectConfig.new do |cfg|
  cfg.project_name = 'ddz'
  cfg.project_root = File.expand_path(File.dirname(__FILE__))
  cfg.publish_root = File.expand_path(File.join(cfg.project_root, '/publish'))

  cfg.ios_resource_root = File.expand_path(File.join(cfg.project_root, '/Assets/StreamingAssets'))
  cfg.android_resource_root = File.expand_path(File.join(cfg.project_root, '/Assets/StreamingAssets'))
  cfg.osx_resource_root = File.expand_path(File.join(cfg.project_root, '/Assets/StreamingAssets'))

  cfg.server_project_root = ENV['LAS'] || File.expand_path(File.join(cfg.project_root, '/../las'))
  cfg.script_root = File.expand_path(File.join(cfg.project_root, '/../las/client/scripts'))

  cfg.sdcard_script_root = "/sdcard/#{cfg.project_name}/scripts"
  cfg.sdcard_resource_root = "/sdcard/#{cfg.project_name}/resources"

  cfg.art_root = ENV['LART'] || File.expand_path(File.join(cfg.project_root, '/../lart'))
  cfg.art_build_root = File.expand_path(File.join(cfg.art_root, '/build'))
  cfg.art_build_temp = File.expand_path(File.join(cfg.art_root, '/build/temp'))

  cfg.ios_bundle_root = ENV['RS_BUNDLE_IOS'] || File.expand_path(File.join(cfg.art_root, '/AssetBundles/ios'))
  cfg.android_bundle_root = ENV['RS_BUNDLE_ANDROID'] || File.expand_path(File.join(cfg.art_root, '/AssetBundles/android'))
  cfg.osx_bundle_root = File.expand_path(File.join(cfg.art_root, '/AssetBundles/osx'))

  cfg.unity_exec = ENV['UNITY'] || '/Applications/Unity/Unity.app/Contents/MacOS/Unity'
end

########################################################################


# Tasks

import 'rake/common.rake' if File.exists?('rake/common.rake')
Dir.glob('rake/*.rake').each { |file| import file }

task :pack do
  system("cp Assets/StreamingAssets/cl.lc proj.ios/Data/Raw/")
  system("cp Assets/StreamingAssets/cl.lc proj.android/race/assets/")
end

desc 'update art repo'
task :sync do
  Dir.chdir(art_dir) do
    if File.exist?('.git')
      system('git svn rebase')
    else
      system('svn up')
    end
  end
end

desc 'move the UnityExtensions/Unity/GUISystem out of unity app'
task :mv_gui do
  system('mv  /Applications/Unity/Unity.app/Contents/UnityExtensions/Unity/GUISystem ~/')
end

desc 'move the UnityExtensions/Unity/GUISystem back to unity app'
task :restore_gui do
  system('mv ~/GUISystem /Applications/Unity/Unity.app/Contents/UnityExtensions/Unity/')
end

desc 'open zhc project and switch to ios env'
task :open_zhc_ios do
  system("/Applications/Unity/Unity.app/Contents/MacOS/Unity -force-gfx-direct -projectPath $ZHC -buildTarget ios")
end

desc 'open zhc project and switch to android env'
task :open_zhc_android do
  system("/Applications/Unity/Unity.app/Contents/MacOS/Unity -force-gfx-direct -projectPath $ZHC -buildTarget android")
end
