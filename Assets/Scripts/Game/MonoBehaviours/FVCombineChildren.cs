using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class FVCombineChildren : MonoBehaviour {
#if UNITY_EDITOR
	public bool combineOnStart = true, destroyAfterOptimized = false, castShadow = true, receiveShadow = true, keepLayer = true, addMeshCollider = false;

	public int maxVertices = 8192;

	[ContextMenu ("Combine Now")]
	public void Combine()
	{
		if (!Application.isPlaying)
			Undo.RegisterSceneUndo("Combine meshes");

		Component[] filters  = GetComponentsInChildren(typeof(MeshFilter));
		Matrix4x4 myTransform = transform.worldToLocalMatrix;
		Hashtable matNameToInst = new Hashtable();
		Hashtable matNameToMaterials = new Hashtable();

		for (int i = 0; i < filters.Length; ++i) {
			MeshFilter filter = (MeshFilter)filters[i];

			if (filter.name.Contains ("$Combined")) {
				Debug.LogFormat ("{0} is already combined", filter.name);
				continue;
			}

			if (filter.sharedMesh == null) {
				Debug.LogFormat ("{0} has null mesh", filter.name);
				continue;
			}

			if (filter.transform == null) {
				Debug.LogFormat ("{0} has null transform", filter.name);
				continue;
			}

			Renderer curRenderer  = filters[i].GetComponent<Renderer>();
			FVMeshCombineUtility.MeshInstance inst = new FVMeshCombineUtility.MeshInstance ();

			// collect filters based on materials
			if (curRenderer != null) {
				inst.transform = myTransform * filter.transform.localToWorldMatrix;

				string mname = MaterialsKey (curRenderer.sharedMaterials);
				ArrayList objects = (ArrayList)matNameToInst [mname];
				Material[] mats = (Material[])matNameToMaterials [mname];
				inst.subMeshCount = filter.sharedMesh.subMeshCount;
				inst.go = filter.gameObject;
				inst.filter = filter;

				if (objects != null) {
					objects.Add (inst);
				} else {
					objects = new ArrayList ();
					objects.Add (inst);
					matNameToInst.Add (mname, objects);

					mats = curRenderer.sharedMaterials;
					matNameToMaterials.Add (mname, mats);
				}

				curRenderer.enabled = false;
			}
		}

		foreach (DictionaryEntry de in matNameToInst) {
			ArrayList elements = (ArrayList)de.Value;
			FVMeshCombineUtility.MeshInstance[] instances = (FVMeshCombineUtility.MeshInstance[])elements.ToArray(typeof(FVMeshCombineUtility.MeshInstance));
			if (instances.Length == 0)
				continue;

			// group all instances to enforce max vertices number per GameObject
			List<List<FVMeshCombineUtility.MeshInstance> > groupInstances = new List<List<FVMeshCombineUtility.MeshInstance> > ();
			groupInstances.Add (new List<FVMeshCombineUtility.MeshInstance>());
			int vn = 0;
			foreach (var instance in instances) {
				List<FVMeshCombineUtility.MeshInstance> gi = groupInstances.Last ();
				int vc = instance.filter.sharedMesh.vertexCount;
				if (vn + vc > maxVertices) {
					if (gi.Count == 0) {
						gi.Add (instance);
						groupInstances.Add (new List<FVMeshCombineUtility.MeshInstance> ());
						vn = 0;
					} else {
						groupInstances.Add (new List<FVMeshCombineUtility.MeshInstance> ());
						gi = groupInstances.Last ();
						gi.Add (instance);
						vn = vc;
					}
					continue;
				}
				gi.Add (instance);
				vn += vc;
			}

			// combine all the gameobjects have same materials
			foreach (var instancesList in groupInstances) {
				var gis = instancesList.ToArray();

				FVMeshCombineUtility.MeshInstance inst = gis [0];
				string key = (string)de.Key;
				Material[] mats = (Material[])matNameToMaterials [key];
				GameObject go = new GameObject(inst.go.name + "$Combined");
				if (keepLayer) go.layer = gameObject.layer;
				go.transform.parent = transform;
				go.transform.localScale = Vector3.one;
				go.transform.localRotation = Quaternion.identity;
				go.transform.localPosition = Vector3.zero;
				go.AddComponent(typeof(MeshFilter));
				go.AddComponent<MeshRenderer>();
				go.GetComponent<Renderer>().sharedMaterials = mats;
				MeshFilter filter = (MeshFilter)go.GetComponent(typeof(MeshFilter));
				filter.sharedMesh = FVMeshCombineUtility.Combine(gis);
				go.GetComponent<Renderer>().castShadows = castShadow;
				go.GetComponent<Renderer>().receiveShadows = receiveShadow;
				if (addMeshCollider) go.AddComponent<MeshCollider>();
			}
		}

		if (!destroyAfterOptimized)
			return;

		for (int i = 0; i < filters.Length; ++i) {
			MeshFilter filter = (MeshFilter)filters[i];
			if (filter.name.Contains ("$Combined")) {
				Debug.LogFormat ("{0} is already combined", filter.name);
				continue;
			}
			if (filter.gameObject == null) {
				Debug.LogFormat ("{0} is already deleted", filter.name);
				continue;
			}
			DestroyImmediate(filter.gameObject);
		}
	}

	public string MaterialsKey(Material[] mats)
	{
		string res = "";
		for (int i = 0; i < mats.Length; ++i)
		{
			Material m = mats [i];
			if (i == 0) {
				res = res + m.name;
			} else {
				res = res + "|" + m.name;
			}
		}
		return res;
	}

#endif
}
