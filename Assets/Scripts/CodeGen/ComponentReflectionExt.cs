using System;
using UnityEngine;
using System.Collections.Generic;
public class ComponentReflectionExt {
	private static Dictionary<Type, Func<Component, string, object>> getterDict = new Dictionary<Type, Func<Component, string, object>>();
    private static Dictionary<Type, Action<Component, string, object>> setterDict = new Dictionary<Type, Action<Component, string, object>>();

	public static void Init(){
	}
	public static object FastGetter(Component comp, string property){
		if (getterDict.Count == 0) Init();
		Func<Component, string, object> method;
		if (getterDict.TryGetValue(comp.GetType(), out method))
        {
            return method(comp, property);
        }

		return null;
	}
	public static void FastSetter(Component comp, string property, object value){
		if (setterDict.Count == 0) Init();
		Action<Component, string, object> method;
		if (setterDict.TryGetValue(comp.GetType(), out method))
        {
            method(comp, property, value);
            return;
        }

	}
}
