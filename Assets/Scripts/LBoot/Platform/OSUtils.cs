
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using SLua;
using System.Threading;
using System.Collections;
using LuaInterface;

namespace LBoot
{

    [CustomLuaClassAttribute]        
    public class OSUtils 
    {

        public static float GetBatteryLevel()
        {

#if UNITY_ANDROID && !UNITY_EDITOR

            if (Application.platform == RuntimePlatform.Android)
            {
                try
                {
                    using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                    {
                        if (null != unityPlayer)
                        {
                            using (AndroidJavaObject currActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                            {
                                if (null != currActivity)
                                {
                                    using (AndroidJavaObject intentFilter = new AndroidJavaObject("android.content.IntentFilter", new object[]{ "android.intent.action.BATTERY_CHANGED" }))
                                    {
                                        using (AndroidJavaObject batteryIntent = currActivity.Call<AndroidJavaObject>("registerReceiver", new object[]{null,intentFilter}))
                                        {
                                            int level = batteryIntent.Call<int>("getIntExtra", new object[]{"level",-1});
                                            int scale = batteryIntent.Call<int>("getIntExtra", new object[]{"scale",-1});

                                            // Error checking that probably isn't needed but I added just in case.
                                            if (level == -1 || scale == -1)
                                            {
                                                return 50f;
                                            }
                                            return ((float)level / (float)scale) * 100.0f; 
                                        }
                                    
                                    }
                                }
                            }
                        }
                    }
                } catch (System.Exception ex)
                {
                
                }
            }

            return 100;
#else
            return 0;
#endif
        }

    }

}