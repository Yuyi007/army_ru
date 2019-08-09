#!/bin/sh
 find Assets/Model/ -name *.png | xargs -n 1 bash -c 'convert "$0" "${0%.*}.tga"; rm "$0"'