//
// AppLifecycleBehaviour.cs
//
// Author:
//       duwenjie
//

//
// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace LBoot
{
    public class AppLifecycleBehaviour : MonoBehaviour
    {
        public bool paused = false;
        public bool focused = false;

        public void Awake()
        {
            // LogUtil.Debug("== App awake: ");
            LBootApp.Instance = this as LBootApp;

            if (LBootApp.ALWAYS_AWAKE)
            {
                Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
            }

            if (this.gameObject.name != LBootApp.GAME_OBJECT_NAME)
            {
                throw new Exception("The binding game object must be named " + LBootApp.GAME_OBJECT_NAME);
            }

            DontDestroyOnLoad(this.gameObject);

#if UNITY_EDITOR
            gameObject.AddComponent<EditorAppBehaviour>();
#endif
        }

        public void Start()
        {
            LogUtil.Debug("== App start: ");

            AppLifecycle.BootstrapApp(this.gameObject);

        }

        // public void OnLevelWasLoaded(int levelId)
        // {
        //     LogUtil.Debug("== Level Loaded: " + Application.loadedLevelName);
        // }

        public void OnDestroy()
        {
            LBootApp.Instance = null;
            LogUtil.Debug("== App destroy: ");
        }

        public void OnApplicationFocus(bool focusStatus)
        {
            // LogUtil.Debug("== App focused: " + focusStatus);
            focused = focusStatus;
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            LogUtil.Debug("== App paused: " + pauseStatus);
            paused = pauseStatus;

            if (paused)
            {
                AppLifecycle.PauseApp();
            }
            else
            {
                AppLifecycle.ResumeApp();
            }
        }

        public void OnApplicationQuit()
        {
            LogUtil.Debug("== App quit: ");

            AppLifecycle.ShutdownApp();
        }

        public void ReceivedMemoryWarning(string message)
        {
            LogUtil.Debug("== App ReceivedMemoryWarning: " + message);

            AppLifecycle.ReceivedMemoryWarning();
        }

#if UNITY_ANDROID && ! UNITY_EDITOR
        public void OnGUI()
        {
            var e = Event.current;
            switch (e.type)
            {
                case EventType.KeyUp:
                    switch (e.keyCode)
                    {
                        case KeyCode.Menu:
                            LBootApp.luaBridge.Call("onKeyDown", "menu");
                            e.Use();
                            break;
                        case KeyCode.Escape:
                            LBootApp.luaBridge.Call("onKeyDown", "back");
                            e.Use();
                            break;
                    }
                    break;
            }
        }
#endif
    }
}
