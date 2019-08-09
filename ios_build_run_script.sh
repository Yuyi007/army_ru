#!/usr/bin/env sh
# run script before building ios
#

cd `dirname $0`

[ -f ~/.bash_profile ] && source ~/.bash_profile
[ -f ~/.zshrc ] && source ~/.zshrc

BUILD=Debug

if [ ! -z "$BUILDMODE" ]; then
  BUILD=$BUILDMODE
fi

echo "ios_build_run_script build $BUILD"

rvm default do rake build:copy_ios_bundles build:gen_meta_ios build:$BUILD
exit 0;