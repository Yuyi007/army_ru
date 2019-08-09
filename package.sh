#!/bin/bash

ROOTDIR=$DU

configuration=$1
LOC=$2


outPutDir="/Users/jenkins/Ipas"
mkdir -p "$outPutDir"
echo $ipaPath

workPath=`pwd`
sdk="iphoneos"
targetName="Unity-iPhone"

USAGE=$3
PROJNAME=$4
APPNAME=$5
VERSION=$6
NUMBER=$7
BUILDMODE=$8
EXPORTOPTS=$9

appPath="$HOME/temp/app/$LOC/$USAGE"
ipaPath="$HOME/temp/ipa/$LOC/$USAGE"

echo "//////////////////////"
echo "configuration:${configuration}"
echo "configuration:${configuration}"
echo "LOC:${LOC}"
echo "USAGE:${USAGE}"
echo "PROJNAME:${PROJNAME}"
echo "VERSION:${VERSION}"
echo "NUMBER:${NUMBER}"
echo "BUILDMODE:${BUILDMODE}"
echo "//////////////////////"

cd "$ROOTDIR/proj.ios/"


exportOpts="../certs/$EXPORTOPTS.plist"
export BUILDMODE=$BUILDMODE

echo "BUILDMODE: $BUILDMODE"
echo "targetName: $targetName"

Locale=zh_CN
echo appPath "$appPath"
rm -rf "$appPath"
mkdir -p "$appPath"

# rake clean
echo "build config.lua"
rake build:$BUILDMODE

echo "copy bundles"
rvm default do rake build:copy_ios_bundles build:gen_meta_ios 

##########################################
# make ipa
rm -rf "$ipaPath"
mkdir -p "$ipaPath"
output="drift-$LOC-$USAGE-$VERSION.$NUMBER"

#Build archive 
echo "xcodebuild archive -project \"$PROJNAME.xcodeproj\" -scheme \"Unity-iPhone\" -configuration \"$configuration\" -archivePath \"${appPath}/$output.xcarchive\""
xcodebuild archive \
-project "$PROJNAME.xcodeproj" \
-scheme "Unity-iPhone" \
-configuration "$configuration" \
-archivePath "${appPath}/$output.xcarchive" \


#Build ipa 
echo "xcodebuild -exportArchive -archivePath \"$appPath/$output.xcarchive\" -exportPath \"$ipaPath\" -exportOptionsPlist \"$exportOpts\""
xcodebuild -exportArchive \
-archivePath "$appPath/$output.xcarchive" \
-exportPath "$ipaPath" \
-exportOptionsPlist "$exportOpts" \

mv "$ipaPath/$PROJNAME.ipa" "$ipaPath/$output.ipa"

MD5=`md5 -q "$ipaPath/$output.ipa"`
echo $MD5 > "$ipaPath/$output.md5.txt"


cd $workPath
echo "generate ipa complete ipaPath $ipaPath"

echo "===================================================="
echo "try copying ipa to remote folder..."
if [ `whoami` == 'jenkins' ]; then
  remote_folder="duwenjie@192.168.104.102:/tmp/ShareFolder/"
  echo "rsync -cv -e \"ssh -p 22\" \"$ipaPath/$output.ipa\" \"$remote_folder\""
  rsync -cv -e "ssh -p 22" "$ipaPath/$output.ipa" "$remote_folder"
  echo "copy success!"
else
  echo "I'm not jenkins, skip copying ipa to remote."
fi


