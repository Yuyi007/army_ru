using System;
using UnityEditor;
using UnityEngine;
[CustomEditor (typeof(PreviewBehaviour))]
public class PreviewBehaviourEdit : Editor{

	SerializedObject serObj;

	SerializedProperty cameraMode;

	//model city
	SerializedProperty PlayerInitPosx;
	SerializedProperty PlayerInitPosy;
	SerializedProperty PlayerInitPosz;

	SerializedProperty useConfig;
	SerializedProperty useHighVisual;

	SerializedProperty CameraInitY;
	SerializedProperty CameraInitZ;
	SerializedProperty CameraMaxY;
	SerializedProperty CameraMinY;
	SerializedProperty sensitivity;
	SerializedProperty rotHorizonMult;
	SerializedProperty rotVerticalMult;
	SerializedProperty minDist;
	SerializedProperty runSpeed;

	SerializedProperty showColliderBox;

	SerializedProperty cameraObstacleDist;
	SerializedProperty lodObstacleDist;
	SerializedProperty lodObstacle120Dist;

	SerializedProperty recommendCameraMode;

	void OnEnable () {
		serObj = new SerializedObject (target);

		cameraMode= serObj.FindProperty ("cameraMode");
		PlayerInitPosx= serObj.FindProperty ("PlayerInitPosx");
		PlayerInitPosy= serObj.FindProperty ("PlayerInitPosy");
		PlayerInitPosz= serObj.FindProperty ("PlayerInitPosz");
		useConfig= serObj.FindProperty ("useConfig");
		useHighVisual= serObj.FindProperty ("useHighVisual");
		CameraInitY= serObj.FindProperty ("CameraInitY");
		CameraInitZ= serObj.FindProperty ("CameraInitZ");
		CameraMaxY= serObj.FindProperty ("CameraMaxY");
		CameraMinY= serObj.FindProperty ("CameraMinY");
		sensitivity= serObj.FindProperty ("sensitivity");
		rotHorizonMult= serObj.FindProperty ("rotHorizonMult");
		rotVerticalMult= serObj.FindProperty ("rotVerticalMult");
		minDist= serObj.FindProperty ("minDist");
		runSpeed= serObj.FindProperty ("runSpeed");
		showColliderBox= serObj.FindProperty ("showColliderBox");
		cameraObstacleDist= serObj.FindProperty ("cameraObstacleDist");
		lodObstacleDist= serObj.FindProperty ("lodObstacleDist");
		lodObstacle120Dist= serObj.FindProperty ("lodObstacle120Dist");

		recommendCameraMode = serObj.FindProperty ("recommendCameraMode");

		var name = EditorApplication.currentScene.Split(char.Parse("/"));

		if (name.Length > 0) {
			string sceneName = name [name.Length - 1];

			if (sceneName.StartsWith ("trs")) {
				recommendCameraMode.intValue = 1;
			}else
				recommendCameraMode.intValue = 0;

			serObj.ApplyModifiedProperties();
		}
			
	}

	public override void OnInspectorGUI () {
		serObj.Update ();

		EditorGUILayout.LabelField("choose camera mode city or combat?", EditorStyles.label);

		EditorGUILayout.PropertyField (cameraMode, new GUIContent("Camera Mode"));
		EditorGUILayout.Separator ();

		if (0 == cameraMode.intValue) {
			EditorGUILayout.PropertyField (PlayerInitPosx, new GUIContent("PlayerInitPosx"));
			EditorGUILayout.PropertyField (PlayerInitPosy, new GUIContent("PlayerInitPosy"));
			EditorGUILayout.PropertyField (PlayerInitPosz, new GUIContent("PlayerInitPosz"));
			EditorGUILayout.PropertyField (useConfig, new GUIContent("useConfig"));
			EditorGUILayout.PropertyField (useHighVisual, new GUIContent("useHighVisual"));
			EditorGUILayout.PropertyField (CameraInitY, new GUIContent("CameraInitY"));
			EditorGUILayout.PropertyField (CameraInitZ, new GUIContent("CameraInitZ"));
			EditorGUILayout.PropertyField (CameraMaxY, new GUIContent("CameraMaxY"));
			EditorGUILayout.PropertyField (CameraMinY, new GUIContent("CameraMinY"));
			EditorGUILayout.PropertyField (sensitivity, new GUIContent("sensitivity"));
			EditorGUILayout.PropertyField (rotHorizonMult, new GUIContent("rotHorizonMult"));
			EditorGUILayout.PropertyField (rotVerticalMult, new GUIContent("rotVerticalMult"));
			EditorGUILayout.PropertyField (minDist, new GUIContent("minDist"));
			EditorGUILayout.PropertyField (runSpeed, new GUIContent("runSpeed"));
			EditorGUILayout.PropertyField (showColliderBox, new GUIContent("showColliderBox"));
			EditorGUILayout.PropertyField (cameraObstacleDist, new GUIContent("cameraObstacleDist"));
			EditorGUILayout.PropertyField (lodObstacleDist, new GUIContent("lodObstacleDist"));
			EditorGUILayout.PropertyField (lodObstacle120Dist, new GUIContent("lodObstacle120Dist"));

		} else {
			//			EditorGUILayout.PropertyField (, new GUIContent(""));

		}



		serObj.ApplyModifiedProperties();
	}
		
}
