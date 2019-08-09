// LuaDLLExt.cs
// Extending LuaInterface.LuaDLL for use with LuaBridge.cs
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LuaInterface
{
  public partial class LuaDLL
  {
    //////////////////////////
    // lua related

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_socket_core(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_mime_core(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_hash_sha2(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_hash_md5(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_hash_xxhash(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_cjson(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_pack(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lfs(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_ahocorasick(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_zlib(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_cmsgpack(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lxyssl(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lsqlite3(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_xt(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lz4(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lz4hc(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_utf8(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_fixmath(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lfractor(IntPtr L);

	// [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
	// public static extern int luaopen_lfixedpt(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_marshal(IntPtr L);

//    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
//    public static extern int luaopen_sodium(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_nacl(IntPtr L);

	[DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaopen_lpeg(IntPtr L);

	[DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaopen_struct(IntPtr L);

	[DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaopen_profiler(IntPtr L);

	[DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaopen_mtwist(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lkcp(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_lutil(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_lrace(IntPtr L);

     [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
        public static extern int luaopen_lmessenger(IntPtr L);

        //////////////////////////
        // lua load buffer/file related

        // load deflated buffer
        [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lz_loadbuffer_deflated(IntPtr L, byte [] buf, int size, string name);

    // load arc4 encrypted and deflated buffer
    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lz_loadbuffer_arc4(IntPtr L, byte [] buf, int size, byte [] key, int keyl, string name);

    // load aes encrypted and deflated buffer
    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lz_loadbuffer_aes(IntPtr L, byte [] buf, int size, byte [] key, int keyl, byte [] iv, int ivl, string name);

    ///////////////////////////////////////
    // C functions -- memory pool

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lua_init_mpool_alloc(int min2, int max2);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr lua_newstate_with_mpool();

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lua_set_mpool_alloc(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lua_unset_mpool_alloc(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int lua_destroy_mpool_alloc();

    ///////////////////////////////////////
    // C functions -- crypto

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte [] arc4_encrypt_easy(byte [] data, int offset, int size, byte [] key, int keyl);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte [] arc4_decrypt_easy(byte [] data, int offset, int size, byte [] key, int keyl);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte [] aes_256_cbc_encrypt_easy(byte [] outbuf, byte [] data, int offset, int size, byte [] key, int keyl, byte [] iv, int ivl);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern byte [] aes_256_cbc_decrypt_easy(byte [] outbuf, byte [] data, int offset, int size, byte [] key, int keyl, byte [] iv, int ivl);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int crypto_secretbox_easy(byte [] cipher, byte [] msg, long msg_len, byte [] nonce, byte [] key);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int crypto_secretbox_open_easy(byte [] msg, byte [] cipher, long cipher_len, byte [] nonce, byte [] key);

    /////////////////////////////////////////
    // Lua provided functions 

    [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_ffi(IntPtr L);

	[DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
	public static extern int luaopen_bit(IntPtr L);

    //////////////////////////
    // platform specific

#if !UNITY_EDITOR && !UNITY_STANDALONE_OSX
    [DllImport(LUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_jit(IntPtr L);
#endif

#if UNITY_EDITOR
#elif UNITY_IPHONE
    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_luaoc(IntPtr L);
#elif UNITY_ANDROID
    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int luaopen_luaj(IntPtr L);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int CCLuaJavaBridge_retainLuaFunctionById(int functionId);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int CCLuaJavaBridge_releaseLuaFunctionById(int functionId);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int CCLuaJavaBridge_callLuaFunctionById(int functionId, string param);

    [DllImport(SLUADLL, CallingConvention = CallingConvention.Cdecl)]
    public static extern int CCLuaJavaBridge_callLuaGlobalFunction(string functionName, string param);
#endif

    // platform specific end
    //////////////////////////

    public static void open_luaext(IntPtr luaState)
    {
        luaopen_socket_core(luaState);
        luaopen_mime_core(luaState);
        luaopen_hash_sha2(luaState);
        luaopen_hash_md5(luaState);
        luaopen_hash_xxhash(luaState);
        luaopen_cjson(luaState);
        luaopen_pack(luaState);
        luaopen_lfs(luaState);
        luaopen_ahocorasick(luaState);
        luaopen_zlib(luaState);
        luaopen_cmsgpack(luaState);
        luaopen_lxyssl(luaState);
        luaopen_lsqlite3(luaState);
        luaopen_xt(luaState);
        luaopen_lz4(luaState);
        luaopen_lz4hc(luaState);
        luaopen_utf8(luaState);
        luaopen_fixmath(luaState);
        luaopen_lfractor(luaState);
        luaopen_marshal(luaState);
        luaopen_nacl(luaState);
        luaopen_ffi(luaState);
		luaopen_lpeg(luaState);
		luaopen_struct(luaState);
		luaopen_profiler(luaState);
		luaopen_bit(luaState);
        luaopen_mtwist(luaState);
        luaopen_lkcp(luaState);
        luaopen_lutil(luaState);
        luaopen_lrace(luaState);
        luaopen_lmessenger(luaState);

#if !UNITY_EDITOR && !UNITY_STANDALONE_OSX
        luaopen_jit(luaState);
#endif

#if UNITY_EDITOR
#elif UNITY_IPHONE
        luaopen_luaoc(luaState);
#elif UNITY_ANDROID
        luaopen_luaj(luaState);
#endif

    }

    public static int luaL_dofile(IntPtr luaState, string chunk)
    {
      int result = LuaDLL.luaL_loadfile(luaState, chunk);
      if (result != 0)
        return result;

      return LuaDLL.lua_pcall(luaState, 0, -1, 0);
    }

    public static int lua_dofile(IntPtr luaState, string chunk)
    {
        return LuaDLL.luaL_dofile(luaState, chunk);
    }
  }
}