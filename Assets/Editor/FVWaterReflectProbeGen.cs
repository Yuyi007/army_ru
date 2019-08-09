using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using LBoot;

public class FVWaterReflectProbeGenWindow : EditorWindow {

	public static FVWaterReflectProbeGenWindow theWindow;

	private List<Action<int>>	actions = new List<Action<int>>();
	private string busyString = "";
	private string[] weatherNames = {"day", "night", "yintian", "day_wumai", "night_wumai"};
	private int curIndex = 0;
	private ReflectionProbe curProbe = null;
	private FVWaterCubemapLoader curLoader = null;
	private int haltFrame = 0;

	[MenuItem("Window/Water Reflection Probe Generator")]
	public static void Init()
	{
		theWindow = EditorWindow.GetWindow<FVWaterReflectProbeGenWindow>(false, "Water Reflection Probe Generator", true);
		theWindow.Show();
		EditorWindow.FocusWindowIfItsOpen<SceneView>();
	}

	// Update is called once per frame
	void Update()
	{
		if (actions.Count > 0) {
			if (haltFrame < 5) {
				haltFrame++;
				return;
			}
			try {
				var func = actions [0];
				func (0);
				actions.RemoveAt (0);
			} catch (Exception e) {
				actions.Clear ();
				LogUtil.Error ("Water Reflection Probe has something bad happened!  " + e.ToString ());
			}
			haltFrame = 0;
		}
	}

	void OnGUI()
	{
		if (isBusy ()) {
			GUILayout.Label (busyString, GUILayout.Width (200));
			return;
		}

		GUILayout.Label ("请选定一个GameObject，在此GameObject处生成ReflectionProbe");

		if (GUILayout.Button ("生成ReflectionProbe", EditorStyles.miniButtonMid, GUILayout.Width (200))) {
			GenerateReflectionProbes ();
		}
	}

	[ContextMenu ("Generate Reflection Probes")]
	public void GenerateReflectionProbes () {
		DayNightConfig dnc = GameObject.FindObjectOfType<DayNightConfig>();
		GameObject parent = Selection.activeGameObject;
		if (dnc == null || parent == null)
			return;

		LightmapSwitcher ls = GameObject.FindObjectOfType<LightmapSwitcher>();
		if (ls != null) {
			ls.initData ();
		}

		FogCtrl fc = GameObject.FindObjectOfType<FogCtrl>();

		IgnoreFarClip[] ifcs = Resources.FindObjectsOfTypeAll<IgnoreFarClip> ();

		EnterBusyState("正在烘焙ReflectionProbes，请别乱动！");
		curIndex = 0;

		string productionScenePath = EditorApplication.currentScene;
		string ppath = Path.GetDirectoryName(productionScenePath) + "/";
		string pname = Path.GetFileNameWithoutExtension(productionScenePath);
		string lightmapTgtPath = ppath + pname + "/";
		string[] wrps = Directory.GetFiles(lightmapTgtPath, "water_reflection_probe_*.exr");
		foreach (string wrpname in wrps)
		{
			FileUtil.DeleteFileOrDirectory(wrpname);
		}
		AssetDatabase.Refresh();

		actions.Clear();

		actions.Add(delegate(int a) {
			// disable all IgnoreFarClips
			for (int i = 0; i < ifcs.Length; ++i)
			{
				IgnoreFarClip ifc = ifcs[i];
				ifc.gameObject.isStatic = true;
				Renderer rdr = ifc.gameObject.GetComponent<Renderer>();
				if (rdr == null)
					continue;

				foreach(Material m in rdr.sharedMaterials)
				{
					m.SetInt ("_ifc", 0);
					m.DisableKeyword ("IGNORE_FAR_CLIP");
				}
			}
		});

		for (int i = 0; i < weatherNames.Length; ++i) {
			// create gameobject and reflection probe
			actions.Add(delegate(int a) {
				string wname = weatherNames[curIndex];
				string goname = "water_reflection_probe_" + wname;
				Transform probTrans = parent.transform.Find(goname);
				if (probTrans == null)
				{
					GameObject probGO = new GameObject();
					probGO.name = goname;
					probGO.transform.SetParent(parent.transform, false);
					probTrans = probGO.transform;
				}
				ReflectionProbe rp = probTrans.GetComponent<ReflectionProbe>();
				if (rp == null)
				{
					rp = probTrans.gameObject.AddComponent<ReflectionProbe>();
				}

				rp.size = new Vector3(400, 200, 400);
				rp.resolution = 128;
				rp.nearClipPlane = 0.5f;
				rp.farClipPlane = 3000.0f;
				rp.cullingMask = ~0;
				rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Baked;
				curProbe = rp;

//				FVWaterCubemapLoader cl = probTrans.GetComponent<FVWaterCubemapLoader>();
//				if (cl == null)
//				{
//					cl = probTrans.gameObject.AddComponent<FVWaterCubemapLoader>();
//				}
//				curLoader = cl;
			});

//			if (Application.isPlaying) 
			{
				// switch weather
				actions.Add (delegate(int a) {
					dnc.SetToWeather (curIndex);
				});

				actions.Add (delegate(int a) {
					if (ls != null)
					{
						ls.DoRefresh();
					}
					if (fc != null) {
						fc.DoRefresh ();
					}
				});

				actions.Add (delegate(int a) {
					string wname = weatherNames[curIndex];
					string goname = "water_reflection_probe_" + wname;
					string path = AssetDatabase.GenerateUniqueAssetPath (Path.Combine (lightmapTgtPath, goname + ".exr"));
					Lightmapping.BakeReflectionProbe (curProbe, path);

					curProbe.mode = UnityEngine.Rendering.ReflectionProbeMode.Custom;
					curProbe.customBakedTexture = UnityEditor.AssetDatabase.LoadAssetAtPath<Texture>(path);

//					curLoader.texPath = path;
				});
			}

			actions.Add(delegate(int a) {
				++curIndex;
			});
		}

		actions.Add(delegate(int a) {
			// disable all IgnoreFarClips
			for (int i = 0; i < ifcs.Length; ++i)
			{
				IgnoreFarClip ifc = ifcs[i];
				ifc.gameObject.isStatic = false;
				Renderer rdr = ifc.gameObject.GetComponent<Renderer>();
				if (rdr == null)
					continue;

				foreach(Material m in rdr.sharedMaterials)
				{
					m.SetInt("_ifc", 1);
					m.EnableKeyword("IGNORE_FAR_CLIP");
				}
			}
		});

		actions.Add(delegate(int a) {
			dnc.SetToWeather(0);
		});

		actions.Add (delegate(int a) {
			if (ls != null)
			{
				ls.DoRefresh();
			}
			if (fc != null) {
				fc.DoRefresh ();
			}
		});

		actions.Add(delegate(int a) {
			RefreshEditorStateDisp();
		});

		haltFrame = 0;
	}

	bool isBusy()
	{
		return busyString != "";
	}

	void EnterBusyState(string str)
	{
		busyString = str;
		Repaint();
	}

	void RefreshEditorStateDisp()
	{
		busyString = "";
		Repaint();
		AssetDatabase.Refresh();
	}
}
