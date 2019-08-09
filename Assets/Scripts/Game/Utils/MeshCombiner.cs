using System;
using UnityEngine;
using SLua;
using System.Collections.Generic;


namespace Game
{
	/// <summary>
	/// Combines the sub skinned mesh renderers into one
	/// </summary>
	[SLua.CustomLuaClass]
	public class MeshCombiner : MonoBehaviour
	{
		private SkinnedMeshRenderer[] renderers;
		private Transform[] myBones;
		private SkinnedMeshRenderer combinedRenderer;
		private Transform skinRoot;

		void Start()
		{
			myBones = transform.GetComponentsInChildren<Transform>(true);
			skinRoot = transform.Find("skin");
		}

		public void Combine()
		{
			if (skinRoot == null) return;

			var allBones = myBones;
			var combineInstances = new List<CombineInstance>();
			var materials = new List<Material>();
			var bones = new List<Transform>();
			var renderers = skinRoot.GetComponentsInChildren<SkinnedMeshRenderer>(true);

			for (var i = 0; i < renderers.Length; ++i)
			{
				var smr = renderers[i];
				materials.AddRange(smr.sharedMaterials);
				for (int sub = 0; sub < smr.sharedMesh.subMeshCount; ++sub)
				{
					var ci = new CombineInstance();
					ci.mesh = smr.sharedMesh;
					ci.subMeshIndex = sub;
					combineInstances.Add(ci);
					for (var j = 0; j < smr.bones.Length; ++j)
					{
						var bone = smr.bones[j];
						var b = Array.Find(allBones, t => t.name == bone.name);
						if (b != null) bones.Add(b);
					}
				}

				smr.enabled = false;
			}

			var r = gameObject.GetComponent<SkinnedMeshRenderer>();
			if (r == null) r = gameObject.AddComponent<SkinnedMeshRenderer>();
			if (r.sharedMesh != null)
			{
				GameObject.Destroy(r.sharedMesh);
			}

			r.sharedMesh = new Mesh();
			r.sharedMesh.CombineMeshes(combineInstances.ToArray(), false, false);
			r.sharedMaterials = materials.ToArray();
			r.bones = bones.ToArray();
			r.receiveShadows = false;
			r.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			r.updateWhenOffscreen = false;
		}
	}
}
