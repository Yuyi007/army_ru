using System;

namespace LBoot
{
    [SLua.CustomLuaClass]
    public static class TimeUtil
    {
        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static double Now()
        {
            return (DateTime.UtcNow - epoch).TotalSeconds;
        }
    }
}

