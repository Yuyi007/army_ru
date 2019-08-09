// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System.Reflection;
using UnityEngine.UI;

namespace SLua
{
    using System.Collections.Generic;
    using System;
    using System.IO;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class CustomExport
    {
        public static void OnGetAssemblyToGenerateExtensionMethod(out List<string> list)
        {
            list = new List<string>
            {
                "Assembly-CSharp",
            };
        }

        public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
        {
            add(typeof(VerifyCenter), null);
            add(typeof(System.Func<int>), null);
            add(typeof(System.Action<int, string>), null);
            add(typeof(System.Action<int, Dictionary<int, object>>), null);
            add(typeof(List<int>), "ListInt");
            // add(typeof(UnityEngine.Events.UnityEvent<Candlelight.UI.HyperText, Candlelight.UI.HyperText.LinkInfo>),
            //     "LuaUnityEventHyperTextLinkInfo");
            add(typeof(List<Sprite>), "ListSprite");
            add(typeof(List<string>), "ListString");
            // add(typeof(List<Candlelight.UI.HyperText.LinkInfo>), "ListHyperTextLinkInfo");
            add(typeof(Dictionary<string, Sprite>), "DictSprite");
            add(typeof(Dictionary<string, System.Object>), "DictObject");
            add(typeof(List<UnityEngine.EventSystems.EventTrigger.Entry>), "ListEventTriggerEntry");
            add(typeof(List<GameObject>), "ListGo");
            add(typeof(List<Vector4>), "ListVector4");
            add(typeof(List<Vector3>), "ListVector3");
            add(typeof(List<Vector2>), "ListVector2");
            add(typeof(List<Material>), "ListMaterial");
            // add(typeof(List<DynamicBone>), "ListDynamicBone");
            // add(typeof(List<DynamicBoneCollider>), "ListDynamicBoneCollider");
            add(typeof(List<CombineInstance>), "ListCombineInstance");
            add(typeof(Dictionary<string, LBoot.AssetBundleRef>), "DictAssetBundleRef");
            add(typeof(Game.EventExecutor<IPointerClickHandler>), "PointClickExecutor");
            add(typeof(bool), "Bool");
            add(typeof(object), "Object");
            add(typeof(int), "Int");
            add(typeof(long), "Long");
            add(typeof(float), "Float");
            add(typeof(double), "Double");
            add(typeof(string), "String");
            add(typeof(System.IO.Directory), null);
            add(typeof(System.IO.File), null);
            add(typeof(SearchOption), null);
            add(typeof(System.Security.Cryptography.MD5), null);
//            add(typeof(LeanTween), null);
//            add(typeof(LeanTweenType), null);
//            add(typeof(LTEvent), null);
//            add(typeof(LTDescr), null);
//            add(typeof(LTBezier), null);
//            add(typeof(LTBezierPath), null);
            // add(typeof(LTSpline), null);
//            add(typeof(LTRect), null);
//            add(typeof(LeanAudio), null);
//            add(typeof(LeanAudioOptions), null);
//            add(typeof(TweenAction), null);
            add(typeof(Go), null);
            add(typeof(GoTweenConfig), null);
            add(typeof(GoTweenCollectionConfig), null);
            add(typeof(GoTween), null);
            add(typeof(GoEaseType), null);
            add(typeof(GoLoopType), null);
            add(typeof(GoUpdateType), null);
            add(typeof(GoDuplicatePropertyRuleType), null);
            add(typeof(GoLogLevel), null);
            add(typeof(GoTweenChain), null);
            add(typeof(GoTweenFlow), null);
            add(typeof(GoTweenUtils), null);
            add(typeof(GoEaseAnimationCurve), null);
            add(typeof(GoSpline), null);
            add(typeof(GoSpline), null);
            add(typeof(GoSplineType), null);
            add(typeof(AbstractGoTween), null);
            add(typeof(AbstractGoTweenCollection), null);
            add(typeof(GoShakeType), null);
            add(typeof(GoLookAtType), null);
            add(typeof(GoSmoothingType), null);
            add(typeof(GoUpdateType), null);
            add(typeof(GoTweenState), null);
            // add(typeof(HighlightingSystem.Highlighter), null);
            // add(typeof(HighlightingSystem.HighlightingRenderer), null);
            // add(typeof(HighlightingSystem.HighlightingBase), null);
            // add(typeof(DynamicBone), null);
            // add(typeof(DynamicBoneCollider), null);
            // add(typeof(DynamicBoneHelper), null);
            add(typeof(System.DateTime), null);
            add(typeof(System.DateTimeKind), null);
            add(typeof(System.DateTimeOffset), null);
            add(typeof(System.DayOfWeek), null);
            // add(typeof(TMPro.TextMeshPro), null);
            // add(typeof(TMPro.TMP_Text), null);
            // add(typeof(TMPro.TextMeshProUGUI), null);
            // add(typeof(TMPro.TMP_FontAsset), null);
            // add(typeof(TMPro.TMP_SpriteAsset), null);
            // add(typeof(TMPro.TMP_Asset), null);
            add(typeof(CinemaDirector.Cutscene), null);
            add(typeof(CinemaDirector.TrackGroup), null);
            add(typeof(CinemaDirector.ActorTrackGroup), null);
            add(typeof(CinemaDirector.CharacterTrackGroup), null);
            add(typeof(CinemaDirector.TimelineItem), null);
            add(typeof(CinemaDirector.TimelineAction), null);
            add(typeof(CinemaDirector.CinemaGlobalAction), null);
            add(typeof(CinemaDirector.ColorTransition), null);
            add(typeof(CinemaDirector.FadeFromBlack), null);
            add(typeof(CinemaDirector.FadeFromWhite), null);
            add(typeof(CinemaDirector.FadeToBlack), null);
            add(typeof(CinemaDirector.FadeToWhite), null);
            add(typeof(CinemaDirector.SetParent), null);
            add(typeof(CinemaDirector.CinemaActorEvent), null);
            add(typeof(CinemaDirector.EnableGameObjectGlobal), null);
            add(typeof(CinemaDirector.DisableGameObjectGlobal), null);
            add(typeof(CinemaDirector.PlayAudioEvent), null);
            add(typeof(CinemaDirector.PlayOneShotAudioEvent), null);
            add(typeof(CinemaDirector.TimelineAction), null);
            add(typeof(CinemaDirector.TimelineActionFixed), null);
            add(typeof(CinemaDirector.CinemaAudio), null);
            add(typeof(CinemaDirector.PauseCutscene), null);
            add(typeof(CinemaDirector.TimelineTrack), null);
            add(typeof(CinemaDirector.CinemaGlobalEvent), null);
            add(typeof(CinemaDirector.CrossFadeAnimatorEvent), null);
            add(typeof(CinemaDirector.PlayAnimatorEvent), null);
            add(typeof(CinemaDirector.SetTriggerAnimatorEvent), null);
            add(typeof(CinemaDirector.SetBoolAnimatorEvent), null);
            add(typeof(UnityStandardAssets.ImageEffects.Bloom), null);
            add(typeof(UnityStandardAssets.ImageEffects.BloomOptimized), null);
            add(typeof(UnityStandardAssets.ImageEffects.ColorCorrectionCurves), null);
			add(typeof(UnityStandardAssets.ImageEffects.ColorCorrectionLookup), null);
            add(typeof(UnityStandardAssets.ImageEffects.FVColorCorrectionLookup), null);
            add(typeof(UnityStandardAssets.ImageEffects.PostEffectsBase), null);
            add(typeof(LightmapSwitcher), null);
            add(typeof(GameObjectCtrl), null);
            add(typeof(PostProcessCtrl), null);
            add(typeof(PostProcessCtrl2), null);
            add(typeof(SetLightMapWithDynamicLightColor), null);
            add(typeof(FogCtrl), null);
            add(typeof(WaterCtrl), null);
            add(typeof(GoInstance), null);
            add(typeof(Text_Extend), null);
            add(typeof(UGUIText_Extend), null);
            add(typeof(UIGradient), null);
            add(typeof(LinkObject), null);
            add(typeof(TextSegmentFlag), null);
            add(typeof(UnityEngine.ParticleSystemShapeType), null);
            add(typeof(UnityEngine.ParticleSystem.ShapeModule), null);
            add(typeof(UnityEngine.ParticleSystem.SizeBySpeedModule), null);
            add(typeof(UnityEngine.ParticleSystem.SizeOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.SubEmittersModule), null);
            add(typeof(UnityEngine.ParticleSystem.TextureSheetAnimationModule), null);
            add(typeof(UnityEngine.ParticleSystem.VelocityOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.RotationOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.RotationBySpeedModule), null);
            add(typeof(UnityEngine.ParticleSystem.LimitVelocityOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.ForceOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.EmissionModule), null);
            add(typeof(UnityEngine.ParticleSystem.ColorOverLifetimeModule), null);
            add(typeof(UnityEngine.ParticleSystem.ColorBySpeedModule), null);
            add(typeof(UnityEngine.ParticleSystem.CollisionModule), null);
            add(typeof(UnityEngine.ParticleSystem.EmitParams), null);
            add(typeof(UnityEngine.ParticleSystem.ExternalForcesModule), null);
            add(typeof(UnityEngine.ParticleSystem.InheritVelocityModule), null);
            add(typeof(UnityEngine.ParticleSystem.InheritVelocityModule), null);
            add(typeof(UnityEngine.ParticleSystem.InheritVelocityModule), null);
            add(typeof(UnityEngine.ParticleSystem.InheritVelocityModule), null);
            add(typeof(UnityEngine.ParticleSystem.MinMaxCurve), null);
            add(typeof(UnityEngine.ParticleSystem.MinMaxGradient), null);
            add(typeof(UnityEngine.ParticleSystem.Particle), null);
            add(typeof(UnityStandardAssets.ImageEffects.Bloom), null);
            add(typeof(UnityStandardAssets.ImageEffects.BloomOptimized), null);
            add(typeof(UnityEngine.Rendering.LightProbeUsage), null);
            add(typeof(FXAA), null);
            add(typeof(FXAAPostEffectsBase), null);
            add(typeof(AmplifyBloomManager), null);
            add(typeof(QuaternionExt),null);
            add(typeof(UniWebViewManager), null);

            //            add(typeof(TalkingDataGA), null);
            //            add(typeof(TDGAAccount), null);
            //            add(typeof(TDGAMission), null);
            //            add(typeof(TDGAItem), null);
            //            add(typeof(TDGAVirtualCurrency), null);

        }

        public static bool IsDelegate(Type type)
        {
            return typeof(MulticastDelegate).IsAssignableFrom(type.BaseType);
        }

        public static void OnAddCustomAssembly(ref List<string> list)
        {
            // add your custom assembly here
            // you can build a dll for 3rd library like ngui titled assembly name "NGUI", put it in Assets folder
            // add it's name into list, slua will generate all exported interface automatically for you

            //list.Add("NGUI");
        }

        public static HashSet<string> OnAddCustomNamespace()
        {
            return new HashSet<string>
            {
                //"NLuaTest.Mock"
            };
        }

        // if uselist return a white list, don't check noUseList(black list) again
        public static void OnGetUseList(out List<string> list)
        {
            list = new List<string>
            {
                "UnityEngine.AvatarIKGoal",
                "UnityEngine.AvatarTarget",
                "UnityEngine.AvatarIKGoal",
                "UnityEngine.AvatarIKHint",
                "UnityEngine.MatchTargetWeightMask",
                // "UnityEngine.TouchScreenKeyboard",
                "UnityEngine.TouchScreenKeyboardType",
                "UnityEngine.ThreadPriority",
                "UnityEngine.AsyncOperation",
                "UnityEngine.AssetBundleCreateRequest",
                "UnityEngine.AssetBundleRequest",
                "UnityEngine.Object",
                "UnityEngine.AssetBundle",
                "UnityEngine.AssetBundleManifest",
                "UnityEngine.SendMessageOptions",
                "UnityEngine.PrimitiveType",
                "UnityEngine.Space",
                "UnityEngine.LayerMask",
                "UnityEngine.RuntimePlatform",
                "UnityEngine.SystemLanguage",
                "UnityEngine.LogType",
                "UnityEngine.DeviceType",
                "UnityEngine.SystemInfo",
                "UnityEngine.WaitForSeconds",
                "UnityEngine.WaitForFixedUpdate",
                "UnityEngine.WaitForEndOfFrame",
                // "UnityEngine.ScriptableObject",
                "UnityEngine.Profiling.Profiler",
                "UnityEngine.RenderSettings",
                "UnityEngine.QualitySettings",
                "UnityEngine.Component",
                "UnityEngine.MeshFilter",
                "UnityEngine.Mesh",
                "UnityEngine.BoneWeight",
                "UnityEngine.Renderer",
                "UnityEngine.SkinnedMeshRenderer",
                "UnityEngine.TrailRenderer",
                "UnityEngine.LineRenderer",
                "UnityEngine.MaterialPropertyBlock",
                "UnityEngine.Graphics",
                "UnityEngine.Resolution",
                "UnityEngine.Screen",
                "UnityEngine.SleepTimeout",
                "UnityEngine.GL",
                "UnityEngine.MeshRenderer",
                "UnityEngine.RenderingPath",
                "UnityEngine.AnimationCurve",
                "UnityEngine.StaticBatchingUtility",
                "UnityEngine.Texture",
                "UnityEngine.Texture2D",
                "UnityEngine.Texture3D",
                "UnityEngine.RenderTexture",
                "UnityEngine.LOD",
                "UnityEngine.LODGroup",
                "UnityEngine.Gradient",
                "UnityEngine.ScaleMode",
                "UnityEngine.FocusType",
                "UnityEngine.RectOffset",
                "UnityEngine.ImagePosition",
                "UnityEngine.Event",
                "UnityEngine.KeyCode",
                "UnityEngine.Vector2",
                "UnityEngine.Vector3",
                "UnityEngine.Color",
                "UnityEngine.Color32",
                "UnityEngine.Quaternion",
                "UnityEngine.Rect",
                "UnityEngine.Matrix4x4",
                "UnityEngine.Bounds",
                "UnityEngine.Vector4",
                "UnityEngine.Ray",
                "UnityEngine.Ray2D",
                "UnityEngine.Plane",
                "UnityEngine.Mathf",
                "UnityEngine.Transform",
                "UnityEngine.RectTransform",
                "UnityEngine.RectTransform.Edge",
                "UnityEngine.RectTransform.Axis",
                "UnityEngine.Resources",
                "UnityEngine.TextAsset",
                // "UnityEngine.Security",
                "UnityEngine.Shader",
                "UnityEngine.Material",
                // "UnityEngine.Rendering.SphericalHarmonicsL2",
                "UnityEngine.SpriteAlignment",
                "UnityEngine.SpriteMeshType",
                "UnityEngine.Sprite",
                "UnityEngine.SpriteRenderer",
                "UnityEngine.Sprites.DataUtility",
                "UnityEngine.Hash128",
                "UnityEngine.WWW",
                "UnityEngine.WWWForm",
                "UnityEngine.Caching",
                "UnityEngine.Application",
                "UnityEngine.Behaviour",
                "UnityEngine.TransparencySortMode",
                "UnityEngine.Camera",
                "UnityEngine.Debug",
                "UnityEngine.Display",
                "UnityEngine.MonoBehaviour",
                "UnityEngine.TouchPhase",
                "UnityEngine.Touch",
                "UnityEngine.DeviceOrientation",
                "UnityEngine.AccelerationEvent",
                // "UnityEngine.LocationInfo",
                // "UnityEngine.LocationServiceStatus",
                // "UnityEngine.LocationService",
                "UnityEngine.GUILayer",
                "UnityEngine.Input",
                "UnityEngine.Light",
                "UnityEngine.GameObject",
                "UnityEngine.Time",
                "UnityEngine.Random",
                "UnityEngine.PlayerPrefs",
                "UnityEngine.Motion",
				"UnityEngine.UI.ReflectionMethodsCache",
                // "UnityEngine.BillboardAsset",
                "UnityEngine.BillboardRenderer",
                "UnityEngine.ParticleSystemRenderMode",
                "UnityEngine.ParticleSystemSimulationSpace",
                "UnityEngine.ParticleSystem",
                "UnityEngine.ParticleSystem.Particle",
                "UnityEngine.ParticleSystemRenderer",
                // "UnityEngine.ParticleCollisionEvent",
                // "UnityEngine.ParticlePhysicsExtensions",
                // "UnityEngine.Particle",
                // "UnityEngine.ParticleEmitter",
                // "UnityEngine.ParticleRenderMode",
                // "UnityEngine.ParticleRenderer",
                "UnityEngine.ForceMode",
                "UnityEngine.Physics",
                "UnityEngine.QueryTriggerInteraction",
                "UnityEngine.RigidbodyConstraints",
                "UnityEngine.Rigidbody",
                "UnityEngine.RigidbodyInterpolation",
                "UnityEngine.RotationDriveMode",
                "UnityEngine.ConstantForce",
                "UnityEngine.CollisionDetectionMode",
                "UnityEngine.Collider",
                "UnityEngine.BoxCollider",
                "UnityEngine.SphereCollider",
                "UnityEngine.MeshCollider",
                "UnityEngine.CapsuleCollider",
                // "UnityEngine.WheelFrictionCurve",
                "UnityEngine.WheelHit",
                "UnityEngine.WheelCollider",
                "UnityEngine.RaycastHit",
                "UnityEngine.PhysicMaterialCombine",
                "UnityEngine.PhysicMaterial",
                "UnityEngine.ContactPoint",
                "UnityEngine.Collision",
                "UnityEngine.CollisionFlags",
                "UnityEngine.ControllerColliderHit",
                "UnityEngine.CharacterController",
                "UnityEngine.Physics2D",
                "UnityEngine.RaycastHit2D",
                "UnityEngine.RigidbodySleepMode2D",
                "UnityEngine.CollisionDetectionMode2D",
                "UnityEngine.ForceMode2D",
                "UnityEngine.Rigidbody2D",
                "UnityEngine.Collider2D",
                "UnityEngine.CircleCollider2D",
                "UnityEngine.BoxCollider2D",
                "UnityEngine.EdgeCollider2D",
                "UnityEngine.PolygonCollider2D",
                "UnityEngine.ContactPoint2D",
                "UnityEngine.Collision2D",
				"UnityEngine.HingeJoint",
				"UnityEngine.Joint",
                "UnityEngine.JointDrive",
                "UnityEngine.JointLimits",
                "UnityEngine.JointMotor",
                "UnityEngine.JointSpring",
                // "UnityEngine.AnchoredJoint2D",
                // "UnityEngine.DistanceJoint2D",
                "UnityEngine.ObstacleAvoidanceType",
                "UnityEngine.NavMeshAgent",
                "UnityEngine.NavMeshHit",
                "UnityEngine.NavMeshTriangulation",
                "UnityEngine.NavMesh",
                "UnityEngine.NavMeshObstacleShape",
                "UnityEngine.NavMeshObstacle",
                "UnityEngine.NavMeshPathStatus",
                "UnityEngine.NavMeshPath",
                "UnityEngine.OffMeshLinkType",
                "UnityEngine.OffMeshLinkData",
                "UnityEngine.OffMeshLink",
                "UnityEngine.AudioConfiguration",
                "UnityEngine.AudioSettings",
                "UnityEngine.AudioType",
                "UnityEngine.AudioClip",
                "UnityEngine.AudioListener",
                "UnityEngine.AudioSource",
                "UnityEngine.AnimationClipPair",
                "UnityEngine.WrapMode",
                "UnityEngine.AnimationEvent",
                "UnityEngine.AnimationClip",
                "UnityEngine.Keyframe",
                "UnityEngine.PlayMode",
                "UnityEngine.QueueMode",
                "UnityEngine.AnimationBlendMode",
                "UnityEngine.AnimationPlayMode",
                "UnityEngine.AnimationCullingType",
                "UnityEngine.Animation",
                "UnityEngine.Component",
                "UnityEngine.Behaviour",
                "UnityEngine.AnimationState",
                // "UnityEngine.AnimatorControllerParameterType",
                // "UnityEngine.AnimatorRecorderMode",
                "UnityEngine.AnimatorClipInfo",
                "UnityEngine.AnimatorCullingMode",
                "UnityEngine.AnimatorUpdateMode",
                "UnityEngine.AnimatorStateInfo",
                "UnityEngine.AnimatorTransitionInfo",
                "UnityEngine.Animator",
                // "UnityEngine.AnimatorControllerParameter",
                "UnityEngine.AnimatorUtility",
                "UnityEngine.TextAnchor",
                "UnityEngine.HorizontalWrapMode",
                "UnityEngine.VerticalWrapMode",
                "UnityEngine.TextMesh",
                "UnityEngine.Font",
                "UnityEngine.RenderMode",
                "UnityEngine.Canvas",
                "UnityEngine.CanvasGroup",
                "UnityEngine.CanvasRenderer",
                "UnityEngine.RectTransformUtility",
                "UnityEngine.CombineInstance",
                // "UnityEngine.RenderBuffer",
                "UnityEngine.LightType",
                "UnityEngine.LightRenderMode",
                "UnityEngine.LightProbes",
                "UnityEngine.LightmapSettings",
                "UnityEngine.CameraClearFlags",
                "UnityEngine.DepthTextureMode",
                "UnityEngine.BlendWeights",
                "UnityEngine.SkinQuality",
                "UnityEngine.ColorSpace",
                "UnityEngine.ScreenOrientation",
                "UnityEngine.FilterMode",
                "UnityEngine.TextureWrapMode",
                "UnityEngine.TextureFormat",
                "UnityEngine.RenderTextureFormat",
                "UnityEngine.RenderTextureReadWrite",
                "UnityEngine.StateMachineBehaviour",
                "UnityEngine.Events.PersistentListenerMode",
                "UnityEngine.Events.UnityEventCallState",
                "UnityEngine.Events.UnityEventBase",
                "UnityEngine.Events.UnityEvent",
                "UnityEngine.RuntimeAnimatorController",
                "UnityEngine.AnimatorController",
                "UnityEngine.AnimatorOverrideController",
                "UnityEngine.Gizmos",
                "UnityEngine.Projector",
                "UnityEngine.SerializedObject",
                "UnityEngine.Rendering.ShadowCastingMode",
                "UnityEngine.EventSystems.ExecuteEvents",
                "UnityEngine.LightmapData",
                "UnityEngine.UI",
                "UnityEngine.SceneManagement.SceneManager",
                "UnityEngine.SceneManagement.LoadSceneMode",
                "UnityEngine.SceneManagement.Scene",
                "UnityEngine.Experimental.Director.DirectorPlayer",
                "UnityEngine.CrashReport",
                // "UnityEngine.Handheld", // Needs to be edited manually to seperate Android and IOS code
            };
        }

        public static List<string> FunctionFilterList = new List<string>()
        {
            "UIWidget.showHandles",
            "UIWidget.showHandlesWithMoveTool",
            "System.IO.Directory.SetAccessControl",
            "System.IO.Directory.GetAccessControl",
            "System.IO.File.SetAccessControl",
            "System.IO.File.GetAccessControl",
            "System.IO.File.Create|3",
            "System.IO.File.Create|4",
            "System.IO.Directory.CreateDirectory|2",
        };

        // black list if white list not given
        public static void OnGetNoUseList(out List<string> list)
        {
            list = new List<string>
            {
                "HideInInspector",
                "ExecuteInEditMode",
                "AddComponentMenu",
                "ContextMenu",
                "RequireComponent",
                "DisallowMultipleComponent",
                "SerializeField",
                "AssemblyIsEditorAssembly",
                "Attribute",
                "Types",
                "UnitySurrogateSelector",
                "TrackedReference",
                "TypeInferenceRules",
                "FFTWindow",
                "RPC",
                "Network",
                "MasterServer",
                "BitStream",
                "HostData",
                "ConnectionTesterStatus",
                "GUI",
                "EventType",
                "EventModifiers",
                "FontStyle",
                "TextAlignment",
                "TextEditor",
                "TextEditorDblClickSnapping",
                "TextGenerator",
                "TextClipping",
                "Gizmos",
                "ADBannerView",
                "ADInterstitialAd",
                "Android",
                "jvalue",
                "iPhone",
                "iOS",
                "CalendarIdentifier",
                "CalendarUnit",
                "CalendarUnit",
                "FullScreenMovieControlMode",
                "FullScreenMovieScalingMode",
                "LocalNotification",
                "NotificationServices",
                "RemoteNotificationType",
                "RemoteNotification",
                "SamsungTV",
                "TextureCompressionQuality",
                "TouchScreenKeyboardType",
                "TouchScreenKeyboard",
                "MovieTexture",
                "UnityEngineInternal",
                "Terrain",
                "Tree",
                "SplatPrototype",
                "DetailPrototype",
                "DetailRenderMode",
                "MeshSubsetCombineUtility",
                "AOT",
                "Social",
                "Enumerator",
                "SendMouseEvents",
                "Cursor",
                "Flash",
                "ActionScript",
                "OnRequestRebuild",
                "Ping",
                "ShaderVariantCollection",
                "MissingComponentException",
                "MissingComponentException",
                "NPOTSupport",
                "MissingReferenceException",
                "MatchTargetWeightMask",
                "ClothSkinningCoefficient",
                "DrivenTransformProperties",
                "DrivenRectTransformTracker",
                "ApplicationSandboxType",
                "PlayerPrefsException",
                "WindZone",
                "JointLimitState2D",
                "JointSuspension2D",
                "SpringJoint2D",
                "HingeJoint2D",
                "PhysicsMaterial2D",
                "AudioDataLoadState",
                "AudioVelocityUpdateMode",
                "AudioRolloffMode",
                "AudioEchoFilter",
                "WebCamFlags",
                "WebCamDevice",
                "WebCamTexture",
                "AnimatorOverrideController",
                "AnimationCurve",
                "AvatarTarget",
                "AvatarIKGoal",
                "AvatarIKHint",
                "CharacterInfo",
                "UICharInfo",
                "UILineInfo",
                "UIVertex",
                "LightShadows",
                "FogMode",
                "ShadowProjection",
                "MeshTopology",
                "LightmapsMode",
                "UnassignedReferenceException",
                "StackTraceUtility",
                "TextGenerationSettings",
                "OcclusionArea",
                "OcclusionPortal",
                "LightmapData",
                "LightmapsModeLegacy",
                "ImageEffectOpaque",
                "ImageEffectTransformsToLDR",
                "SparseTexture",
                "GradientColorKey",
                "GradientAlphaKey",
                "LightProbeGroup",
                "Handheld",  // Needs to be edited manually to seperate Android and IOS code
                "Rendering.CommandBuffer",
                "Rendering.RenderTargetIdentifier",
                "Rendering.RenderBufferLoadAction",
                "Rendering.RenderBufferLoadAction",
                "Rendering.RenderBufferStoreAction",
                "Rendering.BlendMode",
                "Rendering.BlendOp",
                "Rendering.CompareFunction",
                "Rendering.CullMode",
                "Rendering.ColorWriteMask",
                "Rendering.StencilOp",
                "Rendering.AmbientMode",
                "Rendering.DefaultReflectionMode",
                "Rendering.CameraEvent",
                "Rendering.BuiltinRenderTextureType",
                "Rendering.PassType",
                "Rendering.ShadowCastingMode",
                "Rendering.ReflectionProbeUsage",
                "Rendering.ReflectionProbeType",
                "Rendering.ReflectionProbeClearFlags",
                "Rendering.ReflectionProbeMode",
                "Rendering.ReflectionProbeBlendInfo",
                "Rendering.ReflectionProbeRefreshMode",
                "Rendering.ReflectionProbeTimeSlicingMode",
                "JetBrains.Annotations.ImplicitUseKindFlags",
                "JetBrains.Annotations.ImplicitUseTargetFlags",
                "UnityException",
                "UnityEngine.Avatar",
                "UnityEngine.AvatarBuilder",
                "Microphone",
                "Gyroscop",
                "ParticleAnimator",
                "SoftJointLimit",
                "ConfigurableJoin",
                "RigidbodyInterpolation2D",
                "UnityEngine.AudioSpeakerMode",
                "UnityEngine.AudioCompressionFormat",
                "UnityEngine.AudioClipLoadType",
                "UnityEngine.AudioReverbPreset",
                "UnityEngine.AudioReverbZone",
                "UnityEngine.AudioLowPassFilter",
                "UnityEngine.AudioHighPassFilter",
                "UnityEngine.AudioDistortionFilter",
                "UnityEngine.AudioChorusFilter",
                "UnityEngine.AudioReverbFilter",
                "UnityEngine.Audio.AudioMixer",
                "UnityEngine.Audio.AudioMixerSnapshot",
                "UnityEngine.Audio.AudioMixerGroup",
                "UnityEngine.SkeletonBone",
                "UnityEngine.HumanLimit",
                "UnityEngine.HumanBone",
                "UnityEngine.HumanDescription",
                "UnityEngine.HumanBodyBones",
                "UnityEngine.HumanTrait",
                "UnityEngine.CombineInstance",
                "UnityEngine.Flare",
                "UnityEngine.LensFlare",
                "UnityEngine.Projector",
                "UnityEngine.Skybox",
                "UnityEngine.GeometryUtility",
                "UnityEngine.Cubemap",
                "UnityEngine.ReflectionProbe",
                "UnityEngine.FlareLayer",
                "UnityEngine.ResourceRequest",
                "UnityEngine.Rendering_SphericalHarmonicsL2",
                "UnityEngine.ProceduralProcessorUsage",
                "UnityEngine.ProceduralCacheSize",
                "UnityEngine.ProceduralLoadingBehavior",
                "UnityEngine.ProceduralPropertyType",
                "UnityEngine.ProceduralOutputType",
                "UnityEngine.ProceduralPropertyDescription",
                "UnityEngine.ProceduralMaterial",
                "UnityEngine.ProceduralTexture",
                "UnityEngine.SpritePackingMode",
                "UnityEngine.SpritePackingRotation",
                "UnityEngine.UnityEventQueueSystem",
                "UnityEngine.UserAuthorization",
                "UnityEngine.ApplicationInstallMode",
                "UnityEngine.RenderingPath",
                "UnityEngine.ComputeShader",
                "UnityEngine.ComputeBufferType",
                "UnityEngine.ComputeBuffer",
                "UnityEngine.IMECompositionMode",
                "UnityEngine.Compass",
                "UnityEngine.HideFlags",
                "UnityEngine.DynamicGI",
                "UnityEngine.EllipsoidParticleEmitter",
                "UnityEngine.MeshParticleEmitter",
                "UnityEngine.JointMotor",
                "UnityEngine.JointSpring",
                "UnityEngine.JointLimits",
                "UnityEngine.Joint",
                "UnityEngine.HingeJoint",
                "UnityEngine.SpringJoint",
                "UnityEngine.FixedJoint",
                "UnityEngine.JointDriveMode",
                "UnityEngine.JointProjectionMode",
                "UnityEngine.JointDrive",
                "UnityEngine.CharacterJoint",
                "UnityEngine.ClothSphereColliderPair",
                "UnityEngine.Cloth",
                "UnityEngine.JointAngleLimits2D",
                "UnityEngine.JointTranslationLimits2D",
                "UnityEngine.JointMotor2D",
                "UnityEngine.Joint2D",
                "UnityEngine.SliderJoint2D",
                "UnityEngine.WheelJoint2D",
                "UnityEngine.PhysicsUpdateBehaviour2D",
                "UnityEngine.ConstantForce2D",
                "UnityEngine.EffectorSelection2D",
                "UnityEngine.EffectorForceMode2D",
                "UnityEngine.Effector2D",
                "UnityEngine.AreaEffector2D",
                "UnityEngine.PointEffector2D",
                "UnityEngine.PlatformEffector2D",
                "UnityEngine.SurfaceEffector2D",
                "UnityEngine.TexGenMode",
                "UnityEngine.AnisotropicFiltering",
                "UnityEngine.MaterialGlobalIlluminationFlags",

                "Cardboard",
                "CardboardHead",
                "StereoController",
                "CardboardAudioListener",
                "CardboardEye",
                "ICardboardGazePointer",
                "CardboardReticle",
                "CardboardPreRender",
                "CardboardPostRender",

                "SimpleJson.Reflection",
                "CoroutineTween",
                "GraphicRebuildTracker",
                "Advertisements",
                "UnityEditor",
            };
        }

    }
}
