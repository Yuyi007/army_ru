package com.yousi.lib;

import java.security.Provider;

public class XXHashProvider extends Provider {

  private static final long serialVersionUID = 1217882992205944606L;

  public XXHashProvider() {
    super("XXHash", 0.1, "XXHash Security Provider v0.1");
    put("MessageDigest.XXHash", "com.yousi.lib.XXHashMessageDigest");
    put("NativeImplementation", "true");
  }

}