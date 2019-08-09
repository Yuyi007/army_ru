#!/bin/sh

set +e
rake publish:$USER[ios,editor]
rake "publish:$USER"_apply

echo "Done"