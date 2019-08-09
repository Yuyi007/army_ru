#!/bin/sh
# This scripts will build art assets and submit them to repositories
#
# WARNING: THIS WILL RESET YOUR LOCAL REPOSITORY !!!!!!
#

GITDIRS=("$LAU" "$LART")
COMMENT="buildart.sh commit"
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


for dir in ${GITDIRS[*]}; do
  echo "checkout... $dir"
  cd "$dir"
  git clean -fd
  git checkout -f $BRANCH
  git fetch origin
  git reset origin/$BRANCH --hard
done

######################################################################
# Build art

cd "$LAU"
if [ ! -z "$1" ]; then
  rake art:$1
else
  rake art:build
fi

CHECKRESULT=$?
if [ "$CHECKRESULT" -ne 0 ]; then
  exit 1
fi

######################################################################


for dir in ${GITDIRS[*]}; do
  cd "$dir"
  echo "$dir"
  if ! git status | grep 'working directory clean' >/dev/null 2>&1; then
    echo "Seems there are changes in $dir, commiting..."
    git status
    git add .
    git commit -am "$COMMENT"
    git pull origin $BRANCH
    git push origin $BRANCH

    CHECKRESULT2=$?
    if [ "$CHECKRESULT2" -ne 0 ]; then
      git pull
      git push origin $BRANCH
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
