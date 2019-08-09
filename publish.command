#!/bin/sh

set +e
cd $KFC
rvm default do rake publish:$USER[ios,android]
rvm default do rake "publish:$USER"_apply

echo "Done"