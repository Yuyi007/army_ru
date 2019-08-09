using UnityEngine;
using System.Collections;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent (typeof(Camera))]
public class SoliloquyCameraEdit : MonoBehaviour 
{	
	private Camera cam = null;
	public string playerPrefab = "daoshi001_rda001";
	private bool testCamValue = true;

	public Vector3 camPos = Vector3.zero;

	public Vector3 lookOffset = Vector3.zero;

	private GameObject root = null;
	private GameObject player = null;
	private Transform playerHead = null;

	void Awake()
	{
		#if UNITY_EDITOR

		cam = this.transform.GetComponent<Camera>();

		root = new GameObject();
		root.name = "root";
		root.transform.position = Vector3.zero;
		root.transform.rotation = Quaternion.identity;

		player = makePrefabGameObject(playerPrefab);

		if (player == null)
			return;

		player.name = "player";
		player.transform.parent = root.transform;
		player.transform.rotation = Quaternion.identity;

		var headt = player.transform.GetComponentsInChildren<Transform>();
		foreach (var t in headt)
		{
			if (t.name == "Head")
			{
				playerHead = t;
				Debug.Log(t.transform.position.ToString());
				break;
			}
		}

		cam.transform.parent = player.transform;
		#endif
	}

	GameObject makePrefabGameObject(string prefabName)
	{
		#if UNITY_EDITOR
		string path = CommonUtils.findPrefabPath (prefabName);
		GameObject prefabc = null;
		if (path != null)
		{
			prefabc = AssetDatabase.LoadAssetAtPath<GameObject> (path);
		}
		if (prefabc == null)
			return null;

		var pgo = PrefabUtility.InstantiatePrefab(prefabc) as GameObject;
		return pgo;
		#else
		return null;
		#endif
	}

	void Update()
	{
		#if UNITY_EDITOR
		// align the camera
		SceneView sceneView     = SceneView.lastActiveSceneView;
		if (sceneView != null)
		{
			Camera scam        		= sceneView.camera; //here is the scene camera
			if (scam != null)
			{
				cam.transform.position 	= scam.transform.position;
			}
		}

		if (player == null || playerHead == null)
			return;

		if (testCamValue)
		{
			cam.transform.localPosition = camPos;
		}
			
		// find player's head transform, and let camera look at head with look offset
		Vector3 headPos = playerHead.transform.position;


//		Debug.Log(headPos.ToString());


		Vector3 localHeadPos = player.transform.InverseTransformPoint (headPos);
		Vector3 newHeadPos = player.transform.TransformPoint(localHeadPos + lookOffset);
		cam.transform.LookAt (newHeadPos);
		Debug.DrawLine(cam.transform.position, newHeadPos);
		#endif
	}


}
