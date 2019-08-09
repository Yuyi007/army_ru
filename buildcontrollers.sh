#!/bin/sh
# This scripts will build art assets and submit them to repositories
#
# WARNING: THIS WILL RESET YOUR LOCAL REPOSITORY !!!!!!
#

SVNDIRS="$KOF_ART"
GITDIRS="$KFC"
COMMENT="buildcontrollers.sh commit"

set +e

if [ "$USER" != "jenkins" ]; then
  # needs human confirmation
  read -p "The scripts will reset your repositories, are you sure? " -n 1 -r
  echo
  if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    exit 0
  fi
fi

# for dir in $SVNDIRS; do
#   cd "$dir"
#   #svn status --no-ignore | grep '^[I?]' | cut -c 9- | while IFS= read -r f; do rm -rf "$f"; done
#   svn upgrade
#   svn update
#   svn cleanup
#   svn revert -R .
#   svn up
# done

for dir in $GITDIRS; do
  echo "checkout... $dir"
  cd "$dir"
  git fetch origin
  git checkout -f master
  git reset --hard origin/master
  git checkout master
  git pull
done

######################################################################
# Build art

cd "$KFC"
rake bundle:fix_controllers
######################################################################


# for dir in $SVNDIRS; do
#   cd "$dir"
#   svn update
#   if svn status | grep '^[ADRMX?]' >/dev/null 2>&1; then
#     echo "Seems there are changes in $dir, commiting..."
#     svn status
#     set -f; svn add --force * --auto-props --parents --depth infinity -q
#     if svn status | grep '^[?]' >/dev/null 2>&1; then
#       svn status |grep '\?' |awk '{print $2}'| xargs svn add
#     fi
#     svn commit -m "$COMMENT"
#   else
#     svn revert -R .
#     svn up
#   fi
# done

for dir in $GITDIRS; do
  cd "$dir"
  echo "$dir"
  if ! git status | grep 'working directory clean' >/dev/null 2>&1; then
    echo "Seems there are changes in $dir, commiting..."
    git status
    git add .
    git commit -am "$COMMENT"
    git pull origin master
    git push origin master
  else
    git clean -fd
    git checkout .
  fi
done

CHECKRESULT2=$?
if [ "$CHECKRESULT2" -ne 0 ]; then
  exit 1
fi

echo "Done"
