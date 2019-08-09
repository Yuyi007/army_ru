

using System;
using LBoot;

namespace SLua
{

    /// <summary>
    /// A bridge between UnityEngine.Debug.LogXXX and standalone.LogXXX
    /// </summary>
    internal class Logger
    {
        public static void Log(string msg)
        {
#if !SLUA_STANDALONE
            LogUtil.Debug(msg);
#else
            Console.WriteLine(msg);
#endif 
        }
        public static void LogError(string msg)
        {
#if !SLUA_STANDALONE
            LogUtil.Error(msg);
#else
            Console.WriteLine(msg);
#endif
        }

		public static void LogWarning(string msg)
		{
#if !SLUA_STANDALONE
			LogUtil.Warn(msg);
#else
            Console.WriteLine(msg);
#endif
		}
    }


}