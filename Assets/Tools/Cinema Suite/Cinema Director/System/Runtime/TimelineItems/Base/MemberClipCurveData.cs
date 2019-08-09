
// #define PROFILE_FILE

using CinemaSuite.Common;
using System;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace CinemaDirector
{
    [System.Serializable]
    public class MemberClipCurveData
    {
        public string Type;
        public string PropertyName;
        public bool IsProperty = true;
        public PropertyTypeInfo PropertyType = PropertyTypeInfo.None;

        public AnimationCurve Curve1 = new AnimationCurve();
        public AnimationCurve Curve2 = new AnimationCurve();
        public AnimationCurve Curve3 = new AnimationCurve();
        public AnimationCurve Curve4 = new AnimationCurve();

        public bool isInteger
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Int;
            }
        }

        public bool isDouble
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Double;
            }
        }

        public bool isFloat
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Float;
            }
        }

        public bool isLong
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Long;
            }
        }


        public bool isVector3
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Vector3;
            }
        }

        public bool isVector2
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Vector2;
            }
        }

        public bool isVector4
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Vector4;
            }
        }

        public bool isQuaternion
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Quaternion;
            }
        }

        public bool isColor
        {
            get
            {
                return PropertyType == PropertyTypeInfo.Color;
            }
        }



        //private object cachedProperty;

        public AnimationCurve GetCurve(int i)
        {
            if (i == 1)
                return Curve2;
            else if (i == 2)
                return Curve3;
            else if (i == 3)
                return Curve4;
            else
                return Curve1;
        }

        public void SetCurve(int i, AnimationCurve newCurve)
        {
            if (i == 1)
            {
                Curve2 = newCurve;
            }
            else if (i == 2)
            {
                Curve3 = newCurve;
            }
            else if (i == 3)
            {
                Curve4 = newCurve;
            }
            else
            {
                Curve1 = newCurve;
            }
        }

        public void Initialize(GameObject Actor)
        {
        }

        internal void Reset(GameObject Actor)
        {
        }

        internal object getCurrentValue(Component component)
        {
#if PROFILE_FILE
            Profiler.BeginSample("MemberClipCurveData.getCurrentValue");
#endif // PROFILE_FILE
            if (component == null || this.PropertyName == string.Empty)
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return null;
            }
            object value = null;

            if (ReflectionHelper.UseCodeGen)
            {
                value = ComponentReflectionExt.FastGetter(component, this.PropertyName);
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return value;
            }


            Type type = component.GetType();
            if (this.IsProperty)
            {
                PropertyInfo propertyInfo = ReflectionHelper.GetProperty(type, this.PropertyName);
#if !UNITY_IOS
                value = propertyInfo.GetValue(component, null);
#else
                value = propertyInfo.GetGetMethod().Invoke(component, null);
#endif
            }
            else
            {
                FieldInfo fieldInfo = ReflectionHelper.GetField(type, this.PropertyName);
                value = fieldInfo.GetValue(component);
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return value;
        }
    }
}