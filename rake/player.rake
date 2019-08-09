
def build_ios_player_prod
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget ios -batchmode -quit -executeMethod Packager.BuildIOSPlayerProduction -logFile ")
end

def build_ios_player_dev
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget ios -batchmode -quit -executeMethod Packager.BuildIOSPlayer -logFile ")
end

def build_android_player_prod
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget android -batchmode -quit -executeMethod Packager.BuildAndroidPlayerProduction -logFile ")
end

def build_android_player_dev
  system("#{Boot::Tools.config.unity_exec} -projectPath #{unity_dir} -buildTarget android -batchmode -quit -executeMethod Packager.BuildAndroidPlayer -logFile ")
end

def copy_android_player(scheme)
  remote_root = '/Volumes/Disk/jenkins/jobs/workspace/kfc_package_apk/proj.android'
  local_root = "#{unity_dir}/proj.android/"
  proj_root = "proj_#{scheme}"
  system("rsync -avc --include='assets' --include='assets/bin' --include='assets/bin/*' --exclude='assets/*' jenkins@aqing.firevale.com:#{remote_root}/#{proj_root}/kfc/ #{local_root}/#{proj_root}/kfc/")
end

def upload_android_player_pro(scheme)
  remote_root = '/Volumes/Disk/jenkins/kfc_android_player_pro/proj.android'
  local_root = "#{unity_dir}/proj.android/"
  proj_root = "proj_#{scheme}"
  system("rsync -avc --include='assets' --include='assets/bin' --include='assets/bin/*' --exclude='assets/*' #{local_root}/#{proj_root}/kfc/ jenkins@aqing.firevale.com:#{remote_root}/#{proj_root}/kfc/")
end

namespace :player do
  desc 'build ios production player'
  task :ios_prod do
    build_ios_player_prod
  end

  desc 'build ios dev player'
  task :ios_dev do
    build_ios_player_dev
  end

  desc 'build android production player'
  task :android_prod do
    build_android_player_prod
  end

  desc 'build android dev player'
  task :android_dev do
    build_android_player_dev
  end

  desc 'copy remote android dev build to local'
  task :copy_remote_android_dev do
    copy_android_player(:dev)
  end

  desc 'copy remote android prod build to local'
  task :copy_remote_android_prod do
    copy_android_player(:prod)
  end

  # uploads the pro version of built player
  # should only be called by evepoe or leiting
  # task :upload_android_pro_prod do
  #   upload_android_player_pro(:prod)
  # end

  # # uploads the pro version of built player
  # # should only be called by evepoe or leiting
  # task :upload_android_pro_dev do
  #   upload_android_player_pro(:dev)
  # end



end
