
// #define PROFILE_FILE

using CinemaDirector.Helpers;
using CinemaSuite.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace CinemaDirector
{
    [Serializable, CutsceneItemAttribute("Curve Clip", "Actor Curve Clip", CutsceneItemGenre.CurveClipItem)]
    public class CinemaActorClipCurve : CinemaClipCurve, IRevertable
    {
        // Options for reverting in editor.
        [SerializeField]
        private RevertMode editorRevertMode = RevertMode.Revert;

        [NonSerialized]
        private object[] tempObjectArr = new object[] { null };

        private Dictionary<int, Dictionary<string, Component>> _compDict = null;

        private Dictionary<int, Dictionary<string, Component>> compDict
        {
            get
            {
                if (_compDict == null)
                {
                    _compDict = new Dictionary<int, Dictionary<string, Component>>();
                }
                return _compDict;

            }
        }

        // Options for reverting during runtime.
        [SerializeField]
        private RevertMode runtimeRevertMode = RevertMode.Revert;

        private CurveTrack _curveTrack = null;

        public GameObject Actor
        {
            get
            {
                GameObject actor = null;

                if (_curveTrack == null)
                {
                    var parent = transform.parent;
                    if (parent != null)
                        _curveTrack = parent.GetComponent<CurveTrack>();
                }
                if (_curveTrack != null)
                {
                    var actorTransform = _curveTrack.Actor;
                    if (actorTransform != null)
                        actor = actorTransform.gameObject;
                }

                return actor;
            }
        }

        public Transform ActorTransform
        {
            get
            {
                Transform actor = null;

                if (_curveTrack == null)
                {
                    var parent = transform.parent;
                    if (parent != null)
                        _curveTrack = parent.GetComponent<CurveTrack>();
                }

                if (_curveTrack != null)
                {
                    actor = _curveTrack.Actor;
                }

                return actor;
            }
        }

        protected override void initializeClipCurves(MemberClipCurveData data, Component component)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaActorClipCurve.initializeClipCurves");
#endif // PROFILE_FILE
            object value = GetCurrentValue(component, data.PropertyName, data.IsProperty);
            PropertyTypeInfo typeInfo = data.PropertyType;
            float startTime = Firetime;
            float endTime = Firetime + Duration;

            if (typeInfo == PropertyTypeInfo.Int || typeInfo == PropertyTypeInfo.Long || typeInfo == PropertyTypeInfo.Float || typeInfo == PropertyTypeInfo.Double)
            {
                float x = (float)value;
                data.Curve1 = AnimationCurve.Linear(startTime, x, endTime, x);
            }
            else if (typeInfo == PropertyTypeInfo.Vector2)
            {
                Vector2 vec2 = (Vector2)value;
                data.Curve1 = AnimationCurve.Linear(startTime, vec2.x, endTime, vec2.x);
                data.Curve2 = AnimationCurve.Linear(startTime, vec2.y, endTime, vec2.y);
            }
            else if (typeInfo == PropertyTypeInfo.Vector3)
            {
                Vector3 vec3 = (Vector3)value;
                data.Curve1 = AnimationCurve.Linear(startTime, vec3.x, endTime, vec3.x);
                data.Curve2 = AnimationCurve.Linear(startTime, vec3.y, endTime, vec3.y);
                data.Curve3 = AnimationCurve.Linear(startTime, vec3.z, endTime, vec3.z);
            }
            else if (typeInfo == PropertyTypeInfo.Vector4)
            {
                Vector4 vec4 = (Vector4)value;
                data.Curve1 = AnimationCurve.Linear(startTime, vec4.x, endTime, vec4.x);
                data.Curve2 = AnimationCurve.Linear(startTime, vec4.y, endTime, vec4.y);
                data.Curve3 = AnimationCurve.Linear(startTime, vec4.z, endTime, vec4.z);
                data.Curve4 = AnimationCurve.Linear(startTime, vec4.w, endTime, vec4.w);
            }
            else if (typeInfo == PropertyTypeInfo.Quaternion)
            {
                Quaternion quaternion = (Quaternion)value;
                data.Curve1 = AnimationCurve.Linear(startTime, quaternion.x, endTime, quaternion.x);
                data.Curve2 = AnimationCurve.Linear(startTime, quaternion.y, endTime, quaternion.y);
                data.Curve3 = AnimationCurve.Linear(startTime, quaternion.z, endTime, quaternion.z);
                data.Curve4 = AnimationCurve.Linear(startTime, quaternion.w, endTime, quaternion.w);
            }
            else if (typeInfo == PropertyTypeInfo.Color)
            {
                Color color = (Color)value;
                data.Curve1 = AnimationCurve.Linear(startTime, color.r, endTime, color.r);
                data.Curve2 = AnimationCurve.Linear(startTime, color.g, endTime, color.g);
                data.Curve3 = AnimationCurve.Linear(startTime, color.b, endTime, color.b);
                data.Curve4 = AnimationCurve.Linear(startTime, color.a, endTime, color.a);
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        public object GetCurrentValue(Component component, string propertyName, bool isProperty)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaActorClipCurve.GetCurrentValue");
#endif // PROFILE_FILE
            if (component == null || propertyName == string.Empty)
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return null;
            }

            object value = null;

            if (ReflectionHelper.UseCodeGen)
            {
                value = ComponentReflectionExt.FastGetter(component, propertyName);
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return value;
            }

            Type type = component.GetType();
            if (isProperty)
            {
                PropertyInfo propertyInfo = ReflectionHelper.GetProperty(type, propertyName);
                value = propertyInfo.GetValue(component, null);
            }
            else
            {
                FieldInfo fieldInfo = ReflectionHelper.GetField(type, propertyName);
                value = fieldInfo.GetValue(component);
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return value;
        }

        public override void Initialize()
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaActorClipCurve.Initialize");
#endif // PROFILE_FILE

            var list = CurveData;
            var length = list.Count;
            var actor = Actor;
            for (var i = 0; i < length; i++)
            {
                var memberData = list[i];
                memberData.Initialize(actor);
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        private Component GetActorComponent(string type, Transform actor = null)
        {
            Dictionary<string, Component> dict = null;
            Component component = null;

            if (actor == null)
                actor = ActorTransform;

            int id = actor.GetInstanceID();
            if (compDict.TryGetValue(id, out dict))
            {
                dict.TryGetValue(type, out component);
            }
            else
            {
                dict = new Dictionary<string, Component>();
                compDict[id] = dict;
            }
            if (component == null)
            {
                component = actor.GetComponent(type);
                dict[type] = component;
            }
            return component;
        }

        /// <summary>
        /// Cache the initial state of the curve clip manipulated values.
        /// </summary>
        /// <returns>The Info necessary to revert this event.</returns>
        public RevertInfo[] CacheState()
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaActorClipCurve.CacheState");
#endif // PROFILE_FILE
            List<RevertInfo> reverts = new List<RevertInfo>();
            if (Actor != null)
            {
                var list = CurveData;
                var length = list.Count;
                for (var i = 0; i < length; i++)
                {
                    var memberData = list[i];

                    var component = GetActorComponent(memberData.Type);

                    if (component != null)
                    {
                        RevertInfo info = new RevertInfo(this, component,
                                              memberData.PropertyName, memberData.getCurrentValue(component));

                        reverts.Add(info);
                    }
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
            return reverts.ToArray();
        }

        /// <summary>
        /// Sample the curve clip at the given time.
        /// </summary>
        /// <param name="time">The time to evaulate for.</param>
        public void SampleTime(float time)
        {
#if PROFILE_FILE
            Profiler.BeginSample("CinemaActorClipCurve.SampleTime");
#endif // PROFILE_FILE
            var actor = ActorTransform;
            if (actor == null)
            {
#if PROFILE_FILE
                Profiler.EndSample();
#endif // PROFILE_FILE
                return;
            }
            if (Firetime <= time && time <= Firetime + Duration)
            {
                var list = CurveData;
                var length = list.Count;
                for (var i = 0; i < length; i++)
                {
                    var memberData = list[i];
                    if (memberData.Type == string.Empty || memberData.PropertyName == string.Empty)
                        continue;

                    Transform transformComp = null;
                    Component component = null;
                    if (memberData.Type.Equals("Transform"))
                    {
                        transformComp = actor;
                        component = transformComp;
                    }
                    else
                    {
                        component = GetActorComponent(memberData.Type, actor);
                    }

                    if (component == null)
                    {
                        continue;
                    }

#if PROFILE_FILE
                    Profiler.BeginSample("CinemaActorClipCurve.SampleTime.seg_SetProperty");
#endif // PROFILE_FILE
                    if (ReflectionHelper.UseCodeGen)
                    {
                        if (transformComp != null)
                        {
                            if (memberData.PropertyType == PropertyTypeInfo.Vector3)
                            {
                                transformComp.FastSetter(memberData.PropertyName, evaluateVector3(memberData, time));
                            }
                            else if (memberData.PropertyType == PropertyTypeInfo.Quaternion)
                            {
                                transformComp.FastSetter(memberData.PropertyName, evaluateQuaternion(memberData, time));
                            }

                        }
                        else
                        {
                            var camera = component as Camera;
                            if (camera != null)
                            {
                                switch (memberData.PropertyType)
                                {
                                    case PropertyTypeInfo.Float:
                                    case PropertyTypeInfo.Double:
                                        float v1 = (float)evaluateNumbber(memberData, time);
                                        camera.FastSetter(memberData.PropertyName, v1);
                                        break;
                                    case PropertyTypeInfo.Int:
                                        int v2 = (int)evaluateNumbber(memberData, time);
                                        camera.FastSetter(memberData.PropertyName, v2);
                                        break;
                                    case PropertyTypeInfo.Color:
                                        Color v3 = evaluateColor(memberData, time);
                                        camera.FastSetter(memberData.PropertyName, v3);
                                        break;
                                    default:
                                        object result = evaluate(memberData, time);
                                        camera.FastSetter(memberData.PropertyName, result);
                                        break;
                                }
                                
                            }
                            else
                            {
                                object result = evaluate(memberData, time);
                                ComponentReflectionExt.FastSetter(component, memberData.PropertyName, result);
                            }
                        }

                    }
                    else
                    {
                        object value = evaluate(memberData, time);
                        Type componentType = component.GetType();

                        if (memberData.IsProperty)
                        {

                            PropertyInfo propertyInfo = ReflectionHelper.GetProperty(componentType, memberData.PropertyName);
#if !UNITY_IOS
                        propertyInfo.SetValue(component, value, null);
#else
                            tempObjectArr[0] = value;
                            propertyInfo.GetSetMethod().Invoke(component, tempObjectArr);
#endif
                        }
                        else
                        {

                            FieldInfo fieldInfo = ReflectionHelper.GetField(componentType, memberData.PropertyName);
                            ;
                            fieldInfo.SetValue(component, value);
                        }

                    }
#if PROFILE_FILE
                    Profiler.EndSample();
#endif // PROFILE_FILE
                }
            }
#if PROFILE_FILE
            Profiler.EndSample();
#endif // PROFILE_FILE
        }

        internal void Reset()
        {
            // for (int k = 0; k < CurveData.Count; ++k)
            // {
            //     MemberClipCurveData data = CurveData[k];
            //    memberData.Reset(Actor);
            //}
        }

        /// <summary>
        /// Option for choosing when this curve clip will Revert to initial state in Editor.
        /// </summary>
        public RevertMode EditorRevertMode
        {
            get { return editorRevertMode; }
            set { editorRevertMode = value; }
        }

        /// <summary>
        /// Option for choosing when this curve clip will Revert to initial state in Runtime.
        /// </summary>
        public RevertMode RuntimeRevertMode
        {
            get { return runtimeRevertMode; }
            set { runtimeRevertMode = value; }
        }
    }
}