using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ReflectSurface : MonoBehaviour
{
	// The proxy volume used for local reflection calculations.
	public GameObject reflectionProbeGO;
	private List<Material> allMaterials = new List<Material>();
	private ReflectionProbe rp = null;

	void Start()
	{
		if (!initData ()) {
			return;
		}
		updateReflectionBound ();
	}

	bool initData()
	{
		if (reflectionProbeGO == null)
			return false;

		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer> (true);
		foreach (Renderer r in renderers) {
			// Pass the values to the material.
			foreach (Material m in r.sharedMaterials) {
				allMaterials.Add (m);
			}
		}

		rp = reflectionProbeGO.GetComponent<ReflectionProbe> ();
		if (rp == null)
			return false;

		return true;
	}

	void updateReflectionBound()
	{
		if (reflectionProbeGO == null) {
			return;
		}

		if (rp == null || allMaterials.Count <= 0) {
			initData ();
			return;
		}

		Bounds bd = rp.bounds;
		Vector3 bboxLength = bd.size;
		Vector3 centerBBox = bd.center;
		// Min and max BBox points in world coordinates.
		Vector3 BMin = centerBBox - bboxLength/2;
		Vector3 BMax = centerBBox + bboxLength/2;

		foreach (Material m in allMaterials) {
			m.SetVector ("_BBoxMin", BMin);
			m.SetVector ("_BBoxMax", BMax);
			m.SetVector ("_EnviCubeMapPos", centerBBox);
		}
	}

	#if UNITY_EDITOR
	void Update()
	{
		updateReflectionBound ();
	}
	#endif

}