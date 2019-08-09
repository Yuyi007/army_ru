//
// Yieldable.cs
//
// Author:
//       duwenjie
//

//
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using System.Threading;
using UnityThreading;

namespace LBoot
{
    /// <summary>
    /// Yieldable. Invoke a heavy function in a separate thread, and its completion can be
    /// checked in the caller coroutine.  
    /// </summary>
    public class Yieldable : IEnumerator
    {
  
        private Task<object> task { get; set; }

        public object data { get { return task.Result; } }

        /// <summary>
        /// Initializes Yieldable with a Func<object> action
        /// the action will be invoked in a separate thread, so
        /// refrain from calling any Unity api in the action
        /// </summary>
        public Yieldable(Func<object> action)
        {
            task = action.RunAsync();
        }

        public bool MoveNext()
        {
            return !task.HasEnded;
        }

        public void Reset()
        {
        }

        object IEnumerator.Current
        {
            get
            {
                return task.Result;
            }
        }

    }
}

