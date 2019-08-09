
namespace :slua do

  # desc 'make slua.bundle for osx'
  # task :osx do
  #   system "make -C #{luaext_dir} osx"
  #   output = luaext_dir + '/lua51/slua/build/Release/slua.bundle'
  #   system "cp -rf #{output} Assets/Plugins/"
  # end

  # desc 'make libslua.a for ios'
  # task :ios do
  #   system "make -C #{luaext_dir} ios "
  #   system "cp #{luaext_dir}/build/libslua.a Assets/Plugins/iOS/"
  # end

  # desc 'clean slua'
  # task :clean do
  #   system "make -C #{luaext_dir} clean"

  # end

  desc 'copy libs for macosx'
  task :copy_libs do
    system "cp #{luaext_dir}/prebuilt/mac/slua.bundle Assets/Plugins/x86_64/"
    system "echo copy mac libs success"

    ['Assets', 'proj.ios/Libraries'].each do |path|
      system "cp #{luaext_dir}/luajit/prebuilt/ios/libluajit.a #{path}/Plugins/iOS/"
      system "cp #{luaext_dir}/luaext/prebuilt/ios/libluaext.a #{path}/Plugins/iOS"
      system "cp #{luaext_dir}/luaext/prebuilt/ios/libsodium.a #{path}/Plugins/iOS/"
    end
    system "echo copy ios plugin libs success"

    system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libslua.so    Assets/Plugins/Android/libs/armeabi-v7a/"
    system "cp #{luaext_dir}/prebuilt/android/x86/libslua.so            Assets/Plugins/Android/libs/x86/"
    system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libluajit.so  Assets/Plugins/Android/libs/armeabi-v7a/"
    system "cp #{luaext_dir}/prebuilt/android/x86/libluajit.so          Assets/Plugins/Android/libs/x86/"
    system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libsodium.so  Assets/Plugins/Android/libs/armeabi-v7a/"
    system "cp #{luaext_dir}/prebuilt/android/x86/libsodium.so          Assets/Plugins/Android/libs/x86/"
    system "echo copy android plugin libs success"


    [' proj.android/proj_debug', ' proj.android/proj_product'].each do |path|
      system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libslua.so    #{path}/race/src/main/jniLibs/armeabi-v7a/"
      system "cp #{luaext_dir}/prebuilt/android/x86/libslua.so            #{path}/race/src/main/jniLibs/x86/"
      system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libluajit.so  #{path}/race/src/main/jniLibs/armeabi-v7a/"
      system "cp #{luaext_dir}/prebuilt/android/x86/libluajit.so          #{path}/race/src/main/jniLibs/x86/"
      system "cp #{luaext_dir}/prebuilt/android/armeabi-v7a/libsodium.so  #{path}/race/src/main/jniLibs/armeabi-v7a/"
      system "cp #{luaext_dir}/prebuilt/android/x86/libsodium.so          #{path}/race/src/main/jniLibs/x86/"
    end
    
    system "echo copy android proj libs success"
    #to do copy to ios project

    system "echo copy done!"
  end

  #-------------------------------
  desc 'copy all needed files'
  task :copy => [ :copy_libs, :copy_headers, :copy_sources ]


  desc 'copy libluaext from luajit project'
  task :copy_luaext do
    system "cp #{luaext_dir}/luaext/prebuilt/ios/libluaext.a Assets/Plugins/iOS/"
    system "cp #{luaext_dir}/luaext/prebuilt/ios/libluaext.a proj.ios/Libraries/Plugins/iOS"
  end

  desc 'copy header files from luajit project'
  task :copy_headers do
    system "cp #{luaext_dir}/luaext/platform/ios/*.h proj.ios/Classes/"
    system "cp #{luaext_dir}/luajit/include/*.h proj.ios/Classes/"
  end

  desc 'copy source files from luajit project'
  task :copy_sources do
    ['race/src/main/java/'].each do |dir|
      system("mkdir -p proj.android/#{dir}/")
      system "cp -rf #{luaext_dir}/luaext/platform/android/src/* proj.android/#{dir}/"
    end
  end

  desc 'copy source files from kfc to luajit project'
  task :rev_copy_sources do
    system "cp -rf proj.android/proj_skeletons/common/src/com/firevale/lib/* #{luaext_dir}/luaext/platform/android/src/com/firevale/lib/"
  end

end
