#!/bin/sh
# Provide an easy restart command for managers (i.e. non developers)

cd ~/workspace/kfs

echo '---------------------------------------------------------'
echo '- 关闭服务器中......'

# kill old servers
ps aux | egrep '[b]eam|[r]uby' | awk '{print $2}' | xargs kill

echo '---------------------------------------------------------'
if [ $? == 0 ]; then
  echo '- 关闭服务器成功!'
else
  echo '- 关闭服务器失败！！！！！！！！'
fi

echo '---------------------------------------------------------'
echo '- 启动数据库中......'

./redis-cluster/start-all.sh

echo '---------------------------------------------------------'
echo '- 编译服务器中......'

# compile mix
bin/mix_helper.sh check_deps 2>&1 >/dev/null

mix do egg.config_to_json config/config.${USER}.exs

# FIXME somehow it still compiles when start server
# bin/mix_helper.sh compile 2>&1 >/dev/null
mix clean

echo '---------------------------------------------------------'
if [ $? == 0 ]; then
  echo '- 编译服务器成功!'
else
  echo '- 编译服务器失败！！！！！！！！'
fi

echo '---------------------------------------------------------'
echo '- 启动服务器中......'

# start new servers
rm -f gate.log data.log checker.log gm.log
rake run:gate_no_shell 2>&1 > gate.log &
rake s 2>&1 > data.log &
rake checker 2>&1 > checker.log &
rake gm 2>&1 > gm.log &

# wait for servers to start
sleep 6

echo '---------------------------------------------------------'
echo '- 服务器列表如下:'
ps aux | egrep '[b]eam|[r]uby'

echo '---------------------------------------------------------'
if ls -l gate.log data.log checker.log gm.log 2>&1 >/dev/null; then
  echo '- 启动服务器成功!'
  echo '- 现在请注意看log！'
  tail -f gate.log data.log checker.log gm.log
else
  echo '- 启动服务器失败！！！！！！！！'
fi

