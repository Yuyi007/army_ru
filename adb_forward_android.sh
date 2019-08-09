#!/bin/sh

if [ "$#" -ne 1 ]; then
  echo "usage: $0 kfc_firevale_debug|kfc_firevale_device|kfc|..."
  exit 1
fi

package="com.firevale.$1"
adb forward tcp:54999 localabstract:Unity-${package}

echo "forwarded from ${package}"
