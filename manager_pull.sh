#!/bin/sh
# Provide an easy pull command for managers (i.e. non developers)

cd ~/workspace/kfc
git checkout -f master && ./cleanup_assets.sh && git reset origin/master --hard && git pull

echo '---------------------------------------------------------'

if [ $? == 0 ]; then
  echo '- 拉取kfc成功!'
else
  echo '- 拉取kfc失败！！！！！！！！'
fi

echo '---------------------------------------------------------'

cd ~/workspace/kfs \
  && git checkout -f master \
  && git clean -df game-config* \
  && git reset origin/master --hard \
  && git pull \
  && mkdir -p _build/dev/lib/tzdata/priv/release_ets

echo '---------------------------------------------------------'

if [ $? == 0 ]; then
  echo '- 拉取kfs成功!'
else
  echo '- 拉取kfs失败！！！！！！！！'
fi

echo '---------------------------------------------------------'
