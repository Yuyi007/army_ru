
package com.yousi.lib;

import java.nio.ByteBuffer;
import java.security.MessageDigest;

import com.yousi.lib.XXHash;

public class XXHashMessageDigest extends MessageDigest implements Cloneable {

  private int seed;
  private long state;
  
  public XXHashMessageDigest() {
	  super("XXHash");
	  this.seed = 0;
	  this.state = 0;
  }
  
  public XXHashMessageDigest(int seed) {
    super("XXHash");
    this.seed = seed;
  }

  public void engineUpdate(byte b) {
    throw new RuntimeException("engineUpdate(b) not implemented");
  }

  public void engineUpdate(byte b[], int offset, int length) {
	if (this.state == 0) {
		throw new RuntimeException("engineUpdate(b[]) not inited");
	} else {
		XXHash.XXH32_update(this.state, b, offset, length);
	}
  }

  public void engineReset() {
	if (this.state == 0) {
		this.state = XXHash.XXH32_init(this.seed);
	}
  }

  public byte[] engineDigest() {
    int hash = XXHash.XXH32_digest(this.state);
    byte b[] = ByteBuffer.allocate(4).putInt(hash).array();
    this.state = 0;
    return b;
  }
}