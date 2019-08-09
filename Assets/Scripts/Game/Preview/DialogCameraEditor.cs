using UnityEngine;
using System.Collections;
using System.IO;

#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent (typeof(Camera))]
public class DialogCameraEditor : MonoBehaviour 
{	
	private Camera cam = null;
	public string playerPrefab = "";
	public string npcPrefab = "";
	public float talkDistance = 1.0f;
	public Vector3 lookOffset = Vector3.zero;

	public bool testCamValue = false;
	public Vector3 camPos = Vector3.zero;
	public float headHeight = 0;

	private GameObject root = null;
	private GameObject npc = null;
	private GameObject player = null;
	private Transform playerHead = null;

	void Awake()
	{
#if UNITY_EDITOR
		if (playerPrefab == "" || npcPrefab == "")
			return;

		cam = this.transform.GetComponent<Camera>();

		root = new GameObject();
		root.name = "root";
		root.transform.position = Vector3.zero;
		root.transform.rotation = Quaternion.identity;

		player = makePrefabGameObject(playerPrefab);
		npc = makePrefabGameObject(npcPrefab);

		if (player == null || npc == null)
			return;

		npc.name = "npc";
		npc.transform.parent = root.transform;
		npc.transform.position = Vector3.zero;
		npc.transform.rotation = Quaternion.identity;

		player.name = "player";
		player.transform.parent = root.transform;
		player.transform.position = npc.transform.position + talkDistance * npc.transform.forward;
		player.transform.rotation = Quaternion.Euler(0, 180, 0);

		var headt = player.transform.GetComponentsInChildren<Transform>();
		foreach (var t in headt)
		{
			if (t.name == "Head")
			{
				playerHead = t;
				break;
			}
		}
#endif
	}

	GameObject makePrefabGameObject(string prefabName)
	{
#if UNITY_EDITOR
		return CommonUtils.makePrefabGameObject(prefabName);
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

		if (npc == null || player == null || playerHead == null)
			return;

		if (testCamValue)
		{
			cam.transform.position = camPos;
		}

		// adjust talk distance 
		player.transform.position = npc.transform.position + talkDistance * npc.transform.forward;

		// find player's head transform, and let camera look at head with look offset
		Vector3 headPos = playerHead.transform.position;

		if (testCamValue)
		{
			headPos = player.transform.position;
			headPos.y += headHeight;
		}

		Vector3 localHeadPos = npc.transform.InverseTransformPoint (headPos);
		Vector3 newHeadPos = npc.transform.TransformPoint(localHeadPos + lookOffset);
		cam.transform.LookAt (newHeadPos);
#endif
	}


}
