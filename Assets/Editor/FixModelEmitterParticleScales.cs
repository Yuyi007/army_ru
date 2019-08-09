using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

public class FixModelEmitterParticleScales {
	
	[MenuItem("Tools/FVParticleTools/FixScale/Square the Scale of Seleted Mesh Emitter")]
	public static void SquareScaleMeshEmitter()
	{
		_IterateAllParticlesThenScale ((scaleVal) => {
			return scaleVal * scaleVal;
		});
	}

	[MenuItem("Tools/FVParticleTools/FixScale/SquareRoot the Scale of Seleted Mesh Emitter")]
	public static void SquareRootScaleMeshEmitter()
	{
		_IterateAllParticlesThenScale ((scaleVal) => {
			return Mathf.Sqrt(scaleVal);
		});
	}

	private static void _IterateAllParticlesThenScale(Func<float, float> scaleFunc)
	{
		string processedFiles = "已经全自动处理的文件：";
		string unprocessedFiles = "需要手动处理的文件：";

		string[] prefabs = Selection.assetGUIDs.Select(x => AssetDatabase.GUIDToAssetPath(x)).ToArray();
		for (int i = 0; i < prefabs.Length; ++i)
		{
			var file = prefabs [i];
			var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);
			GameObject go = GameObject.Instantiate(prefab);
			bool allProcessed = _DoChangeScaleForMeshEmitter(go, scaleFunc);
			// save to prefab
			PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ReplaceNameBased);
			GameObject.DestroyImmediate(go);

			if (allProcessed) {
				processedFiles = processedFiles + "\n" + file;
			} else {
				unprocessedFiles = unprocessedFiles + "\n" + file;
			}
		}

		Debug.Log (processedFiles);
		Debug.Log (unprocessedFiles);
	}

	private static bool _DoChangeScaleForMeshEmitter(GameObject root, Func<float, float> scaleFunc)
	{
		bool allProcessed = true;
		ParticleSystemRenderer[] allPsr = root.GetComponentsInChildren<ParticleSystemRenderer> (true);
		for (int i = 0; i < allPsr.Length; ++i) {
			ParticleSystemRenderer psr = allPsr [i];
			if (psr.renderMode == ParticleSystemRenderMode.Mesh) {
				Vector3 orgScale = psr.transform.localScale;

				if (Mathf.Abs(orgScale.x - orgScale.y) < 0.1f &&
					Mathf.Abs(orgScale.x - orgScale.z) < 0.1f &&
					Mathf.Abs(orgScale.z - orgScale.y) < 0.1f) {
					psr.transform.localScale = new Vector3 (
						scaleFunc.Invoke (orgScale.y), 
						scaleFunc.Invoke (orgScale.y), 
						scaleFunc.Invoke (orgScale.z)
					);
				} else {
					allProcessed = false;
				}
			}
		}
		return allProcessed;
	}

}
