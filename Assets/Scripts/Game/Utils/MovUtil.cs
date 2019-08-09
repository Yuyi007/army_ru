using UnityEngine;
using System.Collections;
using SLua;
using LBoot;

namespace Game
{
    [CustomLuaClassAttribute]
    public class MovUtil
    {

        // 视频播放时触摸屏幕视频关闭
        static public void playMovName(string movName)
        {
            LogUtil.Debug("movName =====---------------------" + movName);
            #if UNITY_IOS || UNITY_ANDROID
            Handheld.PlayFullScreenMovie(movName, Color.black, FullScreenMovieControlMode.CancelOnInput);  //"test.mp4"
            #endif
        }

        //  视频播放时弹出IOS高级控件，控制视频暂停播放 全屏等等。
        static public void playMovNameWithControl(string movName)
        {
            #if UNITY_IOS || UNITY_ANDROID
            Handheld.PlayFullScreenMovie(movName, Color.black, FullScreenMovieControlMode.Full);
            #endif
        }

        //  视频播放时无法停止，当其播放完一次后自动关闭
        static public void playMovNameNonInteractive(string movName)
        {
            #if UNITY_IOS || UNITY_ANDROID
            Handheld.PlayFullScreenMovie(movName, Color.black, FullScreenMovieControlMode.Hidden);
            #endif
        }
        // 视频播放时弹出IOS高级控件，可控制播放进度。
        static public void playMovNameNormal(string movName)
        {
            #if UNITY_IOS || UNITY_ANDROID
            Handheld.PlayFullScreenMovie(movName, Color.black, FullScreenMovieControlMode.Minimal);
            #endif
        }
    }

}



