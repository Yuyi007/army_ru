#!/bin/sh
# This scripts will build art assets and submit them to repositories
#
# WARNING: THIS WILL RESET YOUR LOCAL REPOSITORY !!!!!!
#

GITDIRS="$KFC"
COMMENT="buildcutscenes.sh commit"

set +e

if [ "$USER" != "jenkins" ]; then
  # needs human confirmation
  read -p "The scripts will reset your repositories, are you sure? " -n 1 -r
  echo
  if [[ ! $REPLY =~ ^[Yy]$ ]]; then
    exit 0
  fi
fi

for dir in $GITDIRS; do
  echo "checkout... $dir"
  cd "$dir"
  git clean -fd
  git checkout -f master
  git fetch origin master:refs/remotes/origin/master
  git reset origin/master --hard
done


######################################################################
# Build prefab

rake bundle:cutscenes

CHECKRESULT=$?
if [ "$CHECKRESULT" -ne 0 ]; then
  exit 1
fi

######################################################################

for dir in $GITDIRS; do
  cd "$dir"
  echo "$dir"
  if ! git status | grep 'working directory clean' >/dev/null 2>&1; then
    echo "Seems there are changes in $dir, commiting..."
    git status
    git checkout -- *.anim
    git checkout -- *.mat
    git checkout -- Assets/Model/
    git add .
    git commit -am "$COMMENT"
    git pull origin master
    git push origin master

    CHECKRESULT2=$?
    if [ "$CHECKRESULT2" -ne 0 ]; then
      git pull origin master
      git push origin master
    fi
  else
    git clean -fd
    git checkout .
  fi
done

CHECKRESULT3=$?
if [ "$CHECKRESULT3" -ne 0 ]; then
  exit 1
fi

echo "Done"
