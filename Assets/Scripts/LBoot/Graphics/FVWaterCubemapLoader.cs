using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class FVWaterCubemapLoader : MonoBehaviour {

	public string texPath = "";
	private ReflectionProbe rp = null;

	public void tryLoadCubemap()
	{
		ReflectionProbe rp = this.gameObject.GetComponent<ReflectionProbe> ();
		if (rp == null) {
			return;
		}
		tryUnloadCubemap ();

		rp.mode = UnityEngine.Rendering.ReflectionProbeMode.Custom;

#if UNITY_EDITOR
		Cubemap cubemap = AssetDatabase.LoadAssetAtPath<Cubemap>(texPath);
#else
		Cubemap cubemap = LBoot.BundleConfig.Get().GetWaterCubemap(texPath);
#endif
		rp.customBakedTexture = cubemap;
	}

	public void tryUnloadCubemap()
	{
		ReflectionProbe rp = this.gameObject.GetComponent<ReflectionProbe> ();
		if (rp == null || rp.customBakedTexture == null) {
			return;
		}
#if UNITY_EDITOR

#else
		Texture.Destroy(rp.customBakedTexture);
#endif
		rp.customBakedTexture = null;
	}


	public void OnEnable()
	{
//		tryLoadCubemap ();
	}

	public void OnDisable()
	{
//		tryUnloadCubemap ();
	}

	public void OnDestroy()
	{
//		tryUnloadCubemap ();
	}
}
