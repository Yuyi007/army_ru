
// #define PROFILE_FILE

using System;
using System.Collections.Generic;
using UnityEngine;

namespace CinemaDirector
{
    /// <summary>
    /// Curve Clip Items tie Actor component data to animation curves, so that they can be controlled
    /// by curves over time.
    /// </summary>
    ///

    public abstract class CinemaClipCurve : TimelineAction
    {
        // The curve data
        [SerializeField]
        private List<MemberClipCurveData> curveData = new List<MemberClipCurveData>();

        /// <summary>
        /// Return the Curve Clip data.
        /// </summary>
        public List<MemberClipCurveData> CurveData
        {
            get { return curveData; }
        }

        protected virtual void initializeClipCurves(MemberClipCurveData data, Component component)
        {
        }

        public void AddClipCurveData(Component component, string name, bool isProperty, Type type)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaClipCurve.AddClipCurveData");
#endif // PROFILE_FILE
            MemberClipCurveData data = new MemberClipCurveData();
            data.Type = component.GetType().Name;
            data.PropertyName = name;
            data.IsProperty = isProperty;
            data.PropertyType = UnityPropertyTypeInfo.GetMappedType(type);
            initializeClipCurves(data, component);
            curveData.Add(data);
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        protected Vector3 evaluateVector3(MemberClipCurveData memberData, float time)
        {
            Vector3 v3;
            v3.x = memberData.Curve1.Evaluate(time);
            v3.y = memberData.Curve2.Evaluate(time);
            v3.z = memberData.Curve3.Evaluate(time);
            return v3;
        }

        protected Vector2 evaluateVector2(MemberClipCurveData memberData, float time)
        {
            Vector2 v;
            v.x = memberData.Curve1.Evaluate(time);
            v.y = memberData.Curve2.Evaluate(time);
            return v;
        }

        protected Vector4 evaluateVector4(MemberClipCurveData memberData, float time)
        {
            Vector4 v;
            v.x = memberData.Curve1.Evaluate(time);
            v.y = memberData.Curve2.Evaluate(time);
            v.z = memberData.Curve3.Evaluate(time);
            v.w = memberData.Curve4.Evaluate(time);
            return v;
        }

        protected Quaternion evaluateQuaternion(MemberClipCurveData memberData, float time)
        {
            Quaternion v;
            v.x = memberData.Curve1.Evaluate(time);
            v.y = memberData.Curve2.Evaluate(time);
            v.z = memberData.Curve3.Evaluate(time);
            v.w = memberData.Curve4.Evaluate(time);
            return v;
        }


        protected Color evaluateColor(MemberClipCurveData memberData, float time)
        {
            Color v;
            v.r = memberData.Curve1.Evaluate(time);
            v.g = memberData.Curve2.Evaluate(time);
            v.b = memberData.Curve3.Evaluate(time);
            v.a = memberData.Curve4.Evaluate(time);
            return v;
        }

        protected double evaluateNumbber(MemberClipCurveData memberData, float time)
        {
            double v = memberData.Curve1.Evaluate(time);
            return v;
        }

        protected object evaluate(MemberClipCurveData memberData, float time)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaClipCurve.evaluate");
#endif // PROFILE_FILE

            object value = null;

            switch (memberData.PropertyType)
            {
                case PropertyTypeInfo.Color:
                    Color c;
                    c.r = memberData.Curve1.Evaluate(time);
                    c.g = memberData.Curve2.Evaluate(time);
                    c.b = memberData.Curve3.Evaluate(time);
                    c.a = memberData.Curve4.Evaluate(time);
                    value = c;
                    break;

                case PropertyTypeInfo.Double:
                case PropertyTypeInfo.Float:
                case PropertyTypeInfo.Int:
                case PropertyTypeInfo.Long:
                    value = memberData.Curve1.Evaluate(time);
                    break;

                case PropertyTypeInfo.Quaternion:
                    Quaternion q;
                    q.x = memberData.Curve1.Evaluate(time);
                    q.y = memberData.Curve2.Evaluate(time);
                    q.z = memberData.Curve3.Evaluate(time);
                    q.w = memberData.Curve4.Evaluate(time);
                    value = q;
                    break;

                case PropertyTypeInfo.Vector2:
                    Vector2 v2;
                    v2.x = memberData.Curve1.Evaluate(time);
                    v2.y = memberData.Curve2.Evaluate(time);
                    value = v2;
                    break;

                case PropertyTypeInfo.Vector3:
                    Vector3 v3;
                    v3.x = memberData.Curve1.Evaluate(time);
                    v3.y = memberData.Curve2.Evaluate(time);
                    v3.z = memberData.Curve3.Evaluate(time);
                    value = v3;
                    break;

                case PropertyTypeInfo.Vector4:
                    Vector4 v4;
                    v4.x = memberData.Curve1.Evaluate(time);
                    v4.y = memberData.Curve2.Evaluate(time);
                    v4.z = memberData.Curve3.Evaluate(time);
                    v4.w = memberData.Curve4.Evaluate(time);
                    value = v4;
                    break;
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return value;
        }

        private void updateKeyframeTime(float oldTime, float newTime)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaClipCurve.updateKeyframeTime");
#endif // PROFILE_FILE
            var list = curveData;
            var count = list.Count;
            for (var x = 0; x < count; x++)
            {
                var data = list[x];
                int curveCount = UnityPropertyTypeInfo.GetCurveCount(data.PropertyType);
                for (int i = 0; i < curveCount; i++)
                {
                    AnimationCurve animationCurve = data.GetCurve(i);
                    var length = animationCurve.length;
                    for (int j = 0; j < length; j++)
                    {
                        Keyframe kf = animationCurve.keys[j];

                        if (Mathf.Abs(kf.time - oldTime) < 0.00001)
                        {
                            Keyframe newKeyframe = new Keyframe(newTime, kf.value, kf.inTangent, kf.outTangent);
                            newKeyframe.tangentMode = kf.tangentMode;
                            AnimationCurveHelper.MoveKey(animationCurve, j, newKeyframe);
                        }
                    }
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public void TranslateCurves(float amount)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaClipCurve.TranslateCurves");
#endif // PROFILE_FILE
            base.Firetime += amount;
            var list = curveData;
            var count = list.Count;
            for (var x = 0; x < count; x++)
            {
                var data = list[x];
                int curveCount = UnityPropertyTypeInfo.GetCurveCount(data.PropertyType);
                for (int i = 0; i < curveCount; i++)
                {
                    AnimationCurve animationCurve = data.GetCurve(i);
                    if (amount > 0)
                    {
                        for (int j = animationCurve.length - 1; j >= 0; j--)
                        {
                            Keyframe kf = animationCurve.keys[j];
                            Keyframe newKeyframe = new Keyframe(kf.time + amount, kf.value, kf.inTangent, kf.outTangent);
                            newKeyframe.tangentMode = kf.tangentMode;
                            AnimationCurveHelper.MoveKey(animationCurve, j, newKeyframe);
                        }
                    }
                    else
                    {
                        var length = animationCurve.length;
                        for (int j = 0; j < length; j++)
                        {
                            Keyframe kf = animationCurve.keys[j];
                            Keyframe newKeyframe = new Keyframe(kf.time + amount, kf.value, kf.inTangent, kf.outTangent);
                            newKeyframe.tangentMode = kf.tangentMode;
                            AnimationCurveHelper.MoveKey(animationCurve, j, newKeyframe);
                        }
                    }
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public void AlterFiretime(float firetime, float duration)
        {
            updateKeyframeTime(base.Firetime, firetime);
            base.Firetime = firetime;

            //updateKeyframeTime(base.Firetime + base.Duration, base.Firetime + duration);
            base.Duration = duration;
        }

        public void AlterDuration(float duration)
        {
            updateKeyframeTime(base.Firetime + base.Duration, base.Firetime + duration);
            base.Duration = duration;
        }
    }
}