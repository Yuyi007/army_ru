
namespace :resource do

  desc '开启调试daemon自动同步资源'
  task :watch do
    Boot::Tools::ResourceSync.instance.watch
    system 'tail -f *.output'
  end

  desc '开启调试daemon自动同步Lua脚本'
  task :watch_lua do
    Boot::Tools::ResourceSync.instance.watch_lua
    system 'tail -f *.output'
  end

  desc '关闭调试daemon'
  task :unwatch do
    Boot::Tools::ResourceSync.instance.unwatch
  end

  desc '同步android资源到已连接的android手机'
  task :sync do
    system("cd #{art_root}/AssetBundles p")
    Boot::Tools::ResourceUpdater.instance.sync_android
  end

  desc '拷贝所有android资源到已连接的android手机'
  task :push do
    system("cd #{art_root}/AssetBundles ")
    Boot::Tools::ResourceUpdater.instance.push_android
  end

  desc '拷贝所有lua脚本到已连接的android手机'
  task :push_lua, [:file] do |_t, args|
    file = args[:file]
    Boot::Tools::ResourceUpdater.instance.push_android_lua file
  end

end
