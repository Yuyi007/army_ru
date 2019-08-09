#!/bin/sh
# Removing Unity Library folder for a clean (probably faster) reimport
# Also, switch platform before launching Unity, to save a unnecessary switch thereafter
#

if [ $# -lt 1 ]; then
  echo "Usage: $0 platform"
  echo "platforms can be win64, osx, ios, android, web, etc."
  exit 0
fi

cd `dirname $0`

PLATFORM=$1
UNITY_FOLDER=Unity
PID=`ps aux | grep -e '[U]nity.app/Contents/MacOS/Unity' | awk '{print $2}'`

if [ "$PID" != "" ]; then
  echo "Killing current Unity Process..."
  kill $PID
  sleep 3
fi

echo 'Killing all PVRTexTool...'
killall PVRTexTool

set -e

echo "Cleaning Library folder..."
rm -rf "Library/"

echo "Starting Unity and reimport..."
/Applications/"$UNITY_FOLDER"/Unity.app/Contents/MacOS/Unity -projectPath . -buildTarget $PLATFORM
