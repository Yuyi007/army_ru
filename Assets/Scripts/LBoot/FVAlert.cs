using System;
using SLua;
using UnityEngine;

namespace LBoot
{
    [SLua.CustomLuaClass]
    public static class FVAlert
    {
        private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

#if UNITY_ANDROID && !UNITY_EDITOR
        private static string fullClassName = "net.agasper.unitynotification.UnityNotificationManager";
#endif


        public static void Init()
        {
#if UNITY_IOS
            UnityEngine.iOS.NotificationServices.RegisterForNotifications(
                UnityEngine.iOS.NotificationType.Alert |
                UnityEngine.iOS.NotificationType.Badge |
                UnityEngine.iOS.NotificationType.Sound);
#endif
        }

        [SLua.DoNotToLua]
        public static DateTime UTCSecondstoLocalTime(long utcTimeSecs)
        {
            var date = epoch.AddSeconds(utcTimeSecs);
            var localDate = date.ToLocalTime();
            return localDate;
        }

        public static void ScheduleAlert(string body, string action, long fireTime)
        {
            var localDate = UTCSecondstoLocalTime(fireTime);

#if UNITY_IOS
            UnityEngine.iOS.LocalNotification notif = new UnityEngine.iOS.LocalNotification();
            notif.alertBody = body;
            notif.alertAction = action;
            notif.fireDate = localDate;
            notif.repeatInterval = UnityEngine.iOS.CalendarUnit.Day;
            Debug.Log(string.Format("ScheduleAlert date={0} body={1} action={2} interval={3}", localDate.ToString(), body, action, notif.repeatInterval.ToString()));
            UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
#endif
        }

        public static void ClearAlerts()
        {
#if UNITY_IOS
            UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
#endif
        }

        public static void SendRepeatingNotification(string message, string title, long fireTime, int id)
        {
            bool sound = true;
            bool vibrate = true;
            bool lights = true;
            string bigIcon = "";
            Color32 bgColor = Color.black;

            var fireDate = UTCSecondstoLocalTime(fireTime);

            if (fireDate <= DateTime.Now)
            {
                fireDate = fireDate.AddSeconds(60 * 60 * 24);
            }

            long delay = (long)(fireDate - DateTime.Now).TotalSeconds;
            long rep = 60 * 60 * 24;

#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
            if (pluginClass != null)
            {
			pluginClass.CallStatic("SetRepeatingNotification", id, delay * 1000L, title, message, message, rep * 1000L, sound ? 1 : 0, vibrate ? 1 : 0, lights ? 1 : 0, bigIcon, "notify_icon_small", bgColor.r * 65536 + bgColor.g * 256 + bgColor.b, Application.identifier);
            }
#endif
        }

        public static void CancelNotification(int id)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJavaClass pluginClass = new AndroidJavaClass(fullClassName);
            if (pluginClass != null) {
            pluginClass.CallStatic("CancelNotification", id);
            }
#endif
        }

    }
}

