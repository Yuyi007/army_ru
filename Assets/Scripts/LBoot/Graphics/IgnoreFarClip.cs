using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;

[CustomLuaClassAttribute]
public class IgnoreFarClip : MonoBehaviour {

	public bool isSkyBox = true;
	public float farClipPlane = 3000.0f;
	private Material[] materials = null;
	private float preFarClipPlane = -1.0f;

	// Use this for initialization
	void Start () {
//		List<Material> mlist = new List<Material> ();
//		Renderer[] renderers = this.gameObject.GetComponentsInChildren<Renderer> (true);
//		for (int i = 0; i < renderers.Length; ++i) {
//			var r = renderers [i];
//			mlist.AddRange (r.sharedMaterials);
//		}
//		materials = mlist.ToArray ();
//		for (int i = 0; i < materials.Length; ++i) {
//			var mat = materials [i];
//			mat.shader = Shader.Find ("Shaders/LightmapUberShader-NoFog-IgnoreFarClip");
//			mat.SetInt ("_ifc", 1);
//			mat.EnableKeyword ("IGNORE_FAR_CLIP");
//		}
//		preFarClipPlane = -1.0f;
	}

	void OnDestroy()
	{
//		for (int i = 0; i < materials.Length; ++i) {
//			var mat = materials [i];
//			mat.SetInt ("_ifc", 0);
//			mat.DisableKeyword ("IGNORE_FAR_CLIP");
//		}
	}

	// Update is called once per frame
	void Update () {
//		Camera cam = Camera.main;
//		if (cam == null) {
//			// need to refresh farclip matrix, if camera has been changed.
//			preFarClipPlane = -1.0f;
//			return;
//		}
//		if (Mathf.Abs (farClipPlane - preFarClipPlane) < 0.01f)
//			return;
//			
//		float orgFar = cam.farClipPlane;
//		cam.farClipPlane = farClipPlane;
//		cam.ResetProjectionMatrix ();
//		Matrix4x4 engineMat = cam.projectionMatrix;
//		Matrix4x4 shaderMat = GL.GetGPUProjectionMatrix (engineMat, false);
//		Shader.SetGlobalMatrix ("_customFarClipMat", shaderMat);
////		for (int i = 0; i < materials.Length; ++i) {
////			var mat = materials [i];
////			mat.SetMatrix ("_customFarClipMat", shaderMat);
////			if (isSkyBox) {
////				mat.renderQueue = 1000;
////			} else {
////				mat.renderQueue = 1001;
////			}
////		}
//		cam.farClipPlane = orgFar;
//		preFarClipPlane = farClipPlane;
	}
}
