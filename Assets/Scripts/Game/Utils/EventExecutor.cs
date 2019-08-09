using UnityEngine;
using System;
using System.Collections;
using System.Reflection; 
using UnityEngine.EventSystems;
using SLua;

namespace Game{
	public class EventExecutor<T>  where T : IEventSystemHandler
	{
		private ExecuteEvents.EventFunction<T> _getFunctor(string funType){
			Type t = typeof(UnityEngine.EventSystems.ExecuteEvents);
			PropertyInfo p = t.GetProperty(funType);
			if (p != null) {
				MethodInfo getter = p.GetGetMethod();
				return getter.Invoke(null, null) as ExecuteEvents.EventFunction<T>;
			}

			return null;
		}

		public bool Execute(GameObject go, BaseEventData evtData, string funType)
		{
			ExecuteEvents.EventFunction<T> functor = _getFunctor (funType);
			return ExecuteEvents.Execute<T>(go, evtData, functor);
		}

		public GameObject ExecuteHierarchy(GameObject go, BaseEventData evtData, string funType)
		{
			ExecuteEvents.EventFunction<T> functor = _getFunctor (funType);
			return ExecuteEvents.ExecuteHierarchy<T> (go, evtData, functor as ExecuteEvents.EventFunction<T>);
		}

		public GameObject GetEventHandler(GameObject go) 
		{
			return ExecuteEvents.GetEventHandler<T> (go);
		}

		public bool CanHandleEvent(GameObject go) 
		{
			return ExecuteEvents.CanHandleEvent<T>(go);
		}
	}
}
