#!/bin/bash

set -e

RC_ROOT=$LAU
PROJ_ROOT=$RC_ROOT/proj.android

echo "rc_root = $RC_ROOT"
echo "proj_root = $PROJ_ROOT"

if [ $# -lt 10 ]; then
  echo "Usage: $0 scheme skeleton usage package versionCode versionName configName apkName sdk location signing"
  exit 1
fi

scheme=$1
skeleton=$2
usage=$3
package=$4
versionCode=$5
versionName=$6
configName=$7
apkName=$8
sdk=$9
location=${10}
signing=${11}
base_skeleton=${12}

echo "===================================================="
echo "scheme=$scheme"
echo "skeleton=$skeleton"
echo "usage=$usage"
echo "package=$package"
echo "versionCode=$versionCode"
echo "versionName=$versionName"
echo "configName=$configName"
echo "apkName=$apkName"
echo "sdk=$sdk"
echo "location=$location"
echo "signing=$signing"
echo "base_skeleton=$base_skeleton"


proj_folder="$PROJ_ROOT/proj_${scheme}/ddz"
as_proj_folder="$PROJ_ROOT/proj_${scheme}_as"
common_skeleton_folder="$PROJ_ROOT/proj_skeletons/common"
skeleton_folder="$PROJ_ROOT/proj_skeletons/$skeleton"
base_skeleton_folder="$PROJ_ROOT/proj_skeletons/$base_skeleton"

if [ "$skeleton" == "debug" ] || [[ "$configName" == *"_debug" ]]; then
  use_sdcard_resource=true
else
  use_sdcard_resource=false
fi

echo "===================================================="
echo "exporting Unity project..."

echo "Exporting Unity project is a TODO, you can export manually."

echo "===================================================="
echo "proj_folder=$proj_folder"
echo "common_skeleton_folder=$common_skeleton_folder"
echo "base_skeleton_folder=$base_skeleton_folder"
echo "skeleton_folder=$skeleton_folder"
echo "copying skeleton project..."

echo "===================================================="
echo "clean up project folder..."

if [ "$PURGE" == "true" ]; then
  echo "purge assets..."
  rm -rf $proj_folder/src/main/assets/*
else
  echo "skip purging assets..."
fi

# rm -rf $proj_folder/src/main/res/*

echo "===================================================="
echo "fix 64bit libs..."

rm -rf "$proj_folder/libs/arm64-v8a"
rm -rf "$proj_folder/libs/arm64"


# echo "rm src $proj_folder/src/com/yousi/rc/*"

# echo "===================================================="
# echo "generate R.java..."

# generate R.java
# AAPT=`find $ADK_ROOT/build-tools/ -name 'aapt' | tail -n 1`
# $AAPT package -f -m \
#   -S $common_skeleton_folder/res/ \
#   -J $common_skeleton_folder/src/ \
#   -M $common_skeleton_folder/AndroidManifest.xml \
#   -I $ADK_ROOT/platforms/android-21/android.jar
# rm -rf $proj_folder/src/com/*

echo "===================================================="
echo "copy project skeleton..."

# copy skeleton project
cp -rf $common_skeleton_folder/* $proj_folder/src/main/
cp -rf $base_skeleton_folder/* $proj_folder/src/main/
cp -rf $skeleton_folder/* $proj_folder/src/main/

# if [ "$package" == "com.yousi.race" ]; then
#   echo "delete R.java because R.class will be generated"
#   rm -f $proj_folder/src/com/yousi/race/R.java
# fi

echo "===================================================="
echo "sync asset bundles..."

rm -f $proj_folder/src/main/assets/meta.json
rm -f $proj_folder/src/main/assets/meta.gz

# copy assets
if [ "$use_sdcard_resource" == "true" ]; then
  echo "$configName build do not need bundles, deleting..."
  rm -rf $proj_folder/src/main/assets/bundles/*
  rm -rf $proj_folder/src/main/assets/data.zip
else
  echo "sync bundles from art folder..."
  rake build:copy_android_bundles["$scheme"]
fi

echo "===================================================="
echo "modifying config.lua..."

# manipulate config.lua
config_lua="$proj_folder/src/main/assets/config.lua"
echo "" > $config_lua

echo "USAGE = '$usage'" > $config_lua

if [ "$scheme" == "product" ]; then
  echo "MODE = 'production'" >> $config_lua
else
  echo "MODE = 'development'" >> $config_lua
fi

if [ "$use_sdcard_resource" == "true" ]; then
  echo "SCRIPT = 'debug'" >> $config_lua
else
  echo "SCRIPT = 'compiled'" >> $config_lua
fi

if [ "$sdk" != "" ]; then
  echo "SDK = '$sdk'" >> $config_lua
fi

if [ "$location" != "" ]; then
  echo "LOCATION = '$location'" >> $config_lua
fi

echo "DISPLAY_VERSION = 'v${versionName}.${versionCode}'" >> $config_lua

echo "===================================================="
echo "modifying strings.xml..."

# manipulate strings.xml
strings_xml="$proj_folder/src/main/res/values/strings.xml"
ruby <<_EOF_
xml = IO.read("$strings_xml")
xml.gsub!(/ddz/, "$apkName")
IO.write("$strings_xml", xml)
puts "Write $strings_xml success!"
_EOF_

echo "===================================================="
echo "modifying AndroidManifest.xml..."

# manipulate AndroidManifest.xml
manifest_xml="$proj_folder/src/main/AndroidManifest.xml"

if [ "$scheme" == "product" ]; then
  debuggable="false"
else
  debuggable="true"
fi


ruby <<_EOF_
xml = IO.read("$manifest_xml")
xml.gsub!(/package="[\w\.]+\w"/, "package=\"$package\"")
xml.gsub!(/android:versionCode="\d+"/, "android:versionCode=\"$versionCode\"")
xml.gsub!(/android:versionName="[\d\.]+\d"/, "android:versionName=\"$versionName\"")
xml.gsub!(/android:debuggable="\w+"/, "")
IO.write("$manifest_xml", xml)
puts "Write $manifest_xml success!"
_EOF_

echo "===================================================="
echo "make android studio project..."

as_app_folder="$as_proj_folder/ddz"
rm -rf "$as_app_folder/"
mkdir -p "$as_app_folder/"
cp -rf "$proj_folder/" "$as_app_folder/"
# mkdir -p "$as_app_folder/src/main/jniLibs"
# mkdir -p "$as_app_folder/src/main/java/src"

# rsync -acv --delete "$proj_folder/libs" "$as_app_folder/"
# rsync -acv --delete "$proj_folder/res" "$as_app_folder/src/main/"
# rsync -acv --delete "$proj_folder/assets" "$as_app_folder/src/main/"
# rsync -acv --delete "$proj_folder/src" "$as_app_folder/src/main/java/"

# cp -f "$proj_folder/AndroidManifest.xml" "$as_app_folder/src/main/AndroidManifest.xml"
# cp -f "$proj_folder/race/build.gradle" "$as_app_folder/"
# cp -f "$proj_folder/build.gradle" "$as_proj_folder/"
# cp -f "$proj_folder/settings.gradle" "$as_proj_folder/"
# cp -f "$proj_folder/gradle.properties" "$as_proj_folder/"
echo "clean build folder:$as_app_folder/build/"
rm -rf "$as_app_folder/build/"
echo "===================================================="
echo "modifying build.gradle..."

build_gradle="$as_app_folder/build.gradle"
if [ "$signing" == "null" ]; then
  sed -i -e "s/signingConfigs\.release/null/g" $build_gradle
elif [ "$signing" == "v1" ]; then
  sed -i -e "s/v2SigningEnabled true/v2SigningEnabled false/g" $build_gradle
fi
rm -f "$build_gradle-e"

echo "===================================================="
echo "do APK packaging..."

apk_folder="$RC_ROOT/proj.android/apks"
apk_file="$apk_folder/ddz_${configName}_$versionName.$versionCode.apk"

if [ "$scheme" == "product" ]; then
  build_type="release"
else
  build_type="debug"
fi

echo "build_type=$build_type"
echo "apk_file=$apk_file"

rm -rf "$apk_folder"
mkdir -p "$apk_folder"

git checkout .

gradle_build()
{
  # as use gradle wrapper so this is deprecated
  # if ! which gradle >/dev/null 2>&1; then
  #   echo 'installing gradle...'
  #   brew install gradle
  # fi
  if [ "$build_type" == "debug" ]; then
    dstFolder="debug"
  else
    dstFolder="release"
  fi

  if [ "$signing" == "null" ]; then
    temp_apk_file="ddz-$build_type-unsigned.apk"
  else
    temp_apk_file="ddz-$build_type.apk"
  fi
  gradle_apk_file="$as_app_folder/build/outputs/apk/$dstFolder/$temp_apk_file"

  echo "gradle_apk_file=$gradle_apk_file"

  # remove build cache to avoid get cached assets
  if [ -d "$as_app_folder/build/intermediates/" ]; then
    rm -rf "$as_app_folder/build/intermediates/"
  fi

  # do ant packaging
  cd "$as_app_folder"
  if [ "$build_type" == "debug" ]; then
    gradle assembleDebug
  else
    gradle assembleRelease
  fi

  CHECKRESULT=$?
  mv "$gradle_apk_file" "$apk_file"
}

gradle_build

if [ "$CHECKRESULT" -ne 0 ]; then
  exit 1
fi

echo "===================================================="
echo "try copying APK to remote folder..."

# if [ `whoami` == 'jenkins' ]; then
  remote_folder="/Users/linjianfu/Downloads/Temp/"
  echo "rsync -cv -e \"ssh -p 22\" \"$apk_file\" \"$remote_folder\""
  rsync -cv -e "ssh -p 22" "$apk_file" "$remote_folder"
  echo "copy success!"
# else
#   echo "I'm not jenkins, skip copying apk to remote."
# fi

echo "===================================================="
echo "try installing APK..."

# install apk
if which adb >/dev/null 2>&1; then
  if adb devices -l | grep usb: >/dev/null 2>&1; then
    adb install -r "$apk_file"
  else
    echo "no android device connected"
  fi
else
  echo "no adb command found, skip installing apk."
fi
