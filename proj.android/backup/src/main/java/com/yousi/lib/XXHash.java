
package com.yousi.lib;

public class XXHash
{
  public static native int init();
  public static native int XXH32(byte[] input, int offset, int len, int seed);
  public static native long XXH32_init(int seed);
  public static native void XXH32_update(long state, byte[] input, int offset, int len);
  public static native int XXH32_digest(long state);
}
