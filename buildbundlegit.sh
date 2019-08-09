#!/bin/sh
# This scripts will build art assets and submit them to repositories
#
# WARNING: THIS WILL RESET YOUR LOCAL REPOSITORY !!!!!!
#

GITDIRS="$KFC $KOF_ART"
COMMENT="buildbundle.sh commit"
BRANCH=master

if [ ! -z "$2" ]; then
  BRANCH=$2
fi

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
  git checkout -f $BRANCH
  git fetch origin
  git clean -fd
  git reset --hard origin/$BRANCH
  git checkout $BRANCH
done


######################################################################
# Build art

cd "$KFC"
if [ ! -z "$1" ]; then
  rake bundle:$1
else
  rake bundle:all
fi

CHECKRESULT=$?
if [ "$CHECKRESULT" -ne 0 ]; then
  exit 1
fi

######################################################################

cd "$KFC"
git checkout -- *.mat

for dir in $GITDIRS; do
  cd "$dir"
  echo "$dir"
  if ! git status | grep 'working directory clean' >/dev/null 2>&1; then
    echo "Seems there are changes in $dir, commiting..."
    git status
    git add .
    git commit -am "$COMMENT"
    git pull origin $BRANCH
    git push origin $BRANCH
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
