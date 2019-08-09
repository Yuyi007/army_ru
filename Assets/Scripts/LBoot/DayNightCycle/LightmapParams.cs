using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
[RequireComponent (typeof(Renderer))]
public class LightmapParams : MonoBehaviour {

	public List<Vector4> lsParams = new List<Vector4>();
	public List<int> lsIndices = new List<int>();
	public Renderer rendr = null;

	// Use this for initialization
	void Start () {
		RefreshData ();
	}

	public void RefreshData()
	{
		rendr = GetComponent<Renderer> ();
		while (lsParams.Count < 2)
			lsParams.Add (rendr.lightmapScaleOffset);
		while (lsIndices.Count < 2)
			lsIndices.Add (rendr.lightmapIndex);
	}

	public void SetData(int dataIndex)
	{
		Vector4 lmData = rendr.lightmapScaleOffset;
		int lmIndex = rendr.lightmapIndex;
		lsParams [dataIndex] = lmData;
		lsIndices [dataIndex] = lmIndex;
	}

	public void ApplyData(int dataIndex)
	{
		rendr.lightmapIndex = lsIndices [dataIndex];
		rendr.lightmapScaleOffset = lsParams [dataIndex];
	}
}

