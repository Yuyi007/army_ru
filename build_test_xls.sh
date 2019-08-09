#!/bin/sh

set +e

cd ~/workspace/kof_art/AssetBundles
svn cleanup

cd ~/workspace/kof_art/AssetBundles
svn up

cd ~/workspace/kfs
rake design_config

CHECKRESULT=$?
if [ "$CHECKRESULT" -ne 0 ]; then
  exit 1
fi

cd ~/workspace/kfc
rake publish:$USER[ios,editor]
rake "publish:$USER"_apply

echo "Done"
