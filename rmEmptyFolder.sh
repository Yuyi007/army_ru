#! /usr/bin/env sh

#rm DS_Store files first
find Assets -type f -name .DS_Store -exec rm {} \;

while [ -n "$(find ./Assets -type d -empty)" ]
do
        echo "Found empty directories... removing...";
        find ./Assets -type d -empty -exec rm -rf {}.meta \;
        find ./Assets -type d -empty -exec rm -rf {} \; &> /dev/null
done

echo "Clean.";