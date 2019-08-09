#!/bin/sh

# util to change the line ending from dos to unix
find ./ -type f -name *.cs | xargs dos2unix
find ./ -type f -name *.lua | xargs dos2unix
