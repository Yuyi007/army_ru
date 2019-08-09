using UnityEngine;
using System.Collections;

namespace Game
{
	public class MatrixUtil {
		public static Matrix4x4 getRenderMeshToScreenSpaceMat()
		{
			Camera mainCamera = Camera.main;
			Matrix4x4 toScreen = mainCamera.worldToCameraMatrix.inverse;
			float nc = mainCamera.nearClipPlane + 0.01f;
			float fov = mainCamera.fieldOfView;
			float tanv = Mathf.Tan (fov / 360 * Mathf.PI);
			float scy = nc * tanv;
			float scx = scy * mainCamera.aspect;
			float sw = Screen.width;
			float sh = Screen.height;
			
			Vector3 noffset = new Vector3(0, 0, 1) * -nc;
			Matrix4x4 toNearClip = new Matrix4x4 ();
			toNearClip.SetTRS (noffset, Quaternion.identity, Vector3.one);
			toScreen = toScreen * toNearClip;
			Matrix4x4 toScreenCoord = new Matrix4x4 ();
			toScreenCoord.SetTRS (new Vector3 (-scx, -scy, 0), Quaternion.identity, new Vector3 (2*scx/sw, 2*scy/sh, 1));
			toScreen = toScreen * toScreenCoord;
			return toScreen;
		}
	}

}
