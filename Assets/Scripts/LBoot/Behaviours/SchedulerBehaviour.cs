//
// Scheduler.cs
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
using SLua;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;

namespace LBoot
{
    public class LuaAction : IComparable<LuaAction>
    {
        public float interval { get; set; }

        public float time { get; set; }

        public int repeat { get; set; }

        public int id { get; set; }

        public bool paused { get; set; }

        public bool stopped { get; set; }

        public float startTime { get; set; }

        public Action<int> func { get; set; }

        public int CompareTo(LuaAction other)
        {
            return this.id.CompareTo(other.id);
        }

        public LuaAction()
        {
        }
    }

    public class SchedulerBehaviour : MonoBehaviour
    {
        private List<LuaAction> list = new List<LuaAction>();
        private List<LuaAction> listNextFrame = new List<LuaAction>();
        private bool stopAll = false;

        void FixedUpdate()
        {
            if (stopAll)
            {
                list.Clear();
                listNextFrame.Clear();
                stopAll = false;
                return;
            }

            var deltaTime = Time.fixedDeltaTime;

            list.AddRange(listNextFrame);
            listNextFrame.Clear();
            var count = list.Count;
            for (int i = 0; i < count; ++i)
            {
                var x = list[i];
                if (x.interval <= x.time - x.startTime && x.repeat != 0 && !x.paused && !x.stopped)
                {
                    x.func(x.id);
                    x.startTime = x.time;
                    if (x.repeat > 0)
                    {
                        x.repeat -= 1;
                    }
                }
                x.time += deltaTime;
            }

            list.RemoveAll(x => x.stopped || x.repeat == 0);
        }

        public int Schedule(float interval, int repeat, Action<int> func, bool isPaused)
        {
            if (repeat == 0)
            {
                repeat = 1;
            }

            if (interval < 0)
            {
                interval = 0;
            }

            var action = new LuaAction
            {
                interval = interval,
                repeat = repeat,
                func = func,
                time = 0,
                startTime = 0,
                paused = isPaused
            };

            if (listNextFrame.Count > 0)
            {
                var last = listNextFrame[listNextFrame.Count - 1];
                if (last != null)
                {
                    action.id = last.id + 1;
                }
            }
            else if (list.Count > 0)
            {
                var last = list[list.Count - 1];
                if (last != null)
                {
                    action.id = last.id + 1;
                }
            }

            // Need to make sure at least 1 frame is delayed. 
            // Add the action to the list of next frame instead. 
            listNextFrame.Add(action);
            return action.id;
        }

        public void Unschedule(int id)
        {
            var index = list.BinarySearch(new LuaAction { id = id });
            if (index >= 0)
            {
                var action = list[index];
                action.stopped = true;
            }
            else
            {
                index = listNextFrame.BinarySearch(new LuaAction { id = id });
                if (index >= 0)
                {
                    var action = listNextFrame[index];
                    action.stopped = true;
                }
            }
        }

        public void UnscheduleAll()
        {
            stopAll = true;
        }
    }
}
