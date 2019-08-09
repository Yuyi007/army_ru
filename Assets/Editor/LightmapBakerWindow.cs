using UnityEditor;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
using LBoot;

public class LightmapBakerWindow : EditorWindow
{
	public static LightmapBakerWindow theWindow;


	private List<Action<int>>	actions = new List<Action<int>>();
	private string busyString = "";

	[MenuItem("Window/Day Night Lightmaps Baker")]
	public static void Init()
	{
		theWindow = EditorWindow.GetWindow<LightmapBakerWindow>(false, "Lightmap Baker", true);
		theWindow.Show();
		EditorWindow.FocusWindowIfItsOpen<SceneView>();
	}

	// Update is called once per frame
	void Update()
	{
		if (actions.Count > 0 && !Lightmapping.isRunning)
		{
			try
			{
				var func = actions[0];
				func(0);
				actions.RemoveAt(0);
			}
			catch (Exception e)
			{
				actions.Clear();
				LogUtil.Error("baking day night lightmap has something bad happened!  " + e.ToString());
			}
		}
	}

	void OnGUI()
	{
		if (isBusy ()) {
			GUILayout.Label (busyString, GUILayout.Width (200));
			return;
		}

		GUILayout.Label ("点击烘焙按钮会清除原有的lightmap图（其他文件不会清除），注意做好备份");

		if (GUILayout.Button ("烘焙白天lightmap", EditorStyles.miniButtonMid, GUILayout.Width (200))) {
			BakeLightMaps (false);
		}

		if (GUILayout.Button ("烘焙夜晚lightmap", EditorStyles.miniButtonMid, GUILayout.Width (200))) {
			BakeLightMaps (true);
		}
	}

	void BakeLightMaps(bool isNight)
	{
		EnterBusyState("正在烘培白天lightmap，请别乱动！");

		actions.Clear();

		actions.Add(delegate(int a) {
			Lightmapping.Clear();
		});

		actions.Add(delegate(int a) {
			// clear previous lightmaps
			string productionScenePath = EditorApplication.currentScene;
			string ppath = Path.GetDirectoryName(productionScenePath) + "/";
			string pname = Path.GetFileNameWithoutExtension(productionScenePath);
			string lightmapTgtPath = ppath + pname + "/";
			string[] plightmaps = Directory.GetFiles(lightmapTgtPath, "Lightmap*.exr");
			foreach (string lmname in plightmaps)
			{
				FileUtil.DeleteFileOrDirectory(lmname);
			}
		});

		actions.Add(delegate(int a) {
			Lightmapping.BakeAsync();
		});

		actions.Add(delegate(int a) {
			try {
				CollectLightmapParams(isNight);
			}
			catch(Exception e) {
				RefreshEditorStateDisp();
				Debug.LogException(e);
			}
		});
	}

	void CollectLightmapParams(bool isNight)
	{
		GameObject scenery = GameObject.Find ("scenery");
		if (scenery == null) {
			RefreshEditorStateDisp ();
			return;
		}

		GameObject models = GameObject.Find ("scenery/models");
		if (models == null){
			RefreshEditorStateDisp ();
			return;
		}

		GameObject dncc = null;
		DayNightConfig dnc = scenery.GetComponentInChildren<DayNightConfig> ();
		if (dnc == null) {
			var prefabc = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/Models/Prefab/lightingCtrl/dayNightCycleCtrls.prefab");
			dncc = PrefabUtility.InstantiatePrefab(prefabc) as GameObject;
			dncc.transform.SetParent (scenery.transform, false);
		} else {
			dncc = dnc.gameObject;
		}

		GameObject lsgo = null;
		LightmapSwitcher lss = dncc.GetComponentInChildren<LightmapSwitcher> ();
		if (lss == null) {
			var prefabc = AssetDatabase.LoadAssetAtPath<GameObject> ("Assets/Models/Prefab/lightingCtrl/lightmapSwitcher.prefab");
			lsgo = PrefabUtility.InstantiatePrefab(prefabc) as GameObject;
			lsgo.transform.SetParent (dncc.transform, false);
			lss = lsgo.GetComponent<LightmapSwitcher> ();
		} else {
			lsgo = lss.gameObject;
		}

		List<LightmapParams> lps = new List<LightmapParams> ();
		Renderer[] renderers = models.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in renderers) {
			LightmapParams lp = r.gameObject.GetComponent<LightmapParams> ();
			if (lp == null)
				lp = r.gameObject.AddComponent<LightmapParams> ();
			lp.RefreshData ();
			lp.SetData (isNight ? 1 : 0);
			lps.Add (lp);
		}

		lss.allParams = lps.ToArray ();

		RefreshEditorStateDisp ();
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