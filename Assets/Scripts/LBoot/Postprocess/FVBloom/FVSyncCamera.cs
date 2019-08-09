using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Camera))]
[ExecuteInEditMode]
public class FVSyncCamera : MonoBehaviour {

    public Camera mainCamera = null;
    public Camera cam = null;
	// Use this for initialization
	void Start () {
        mainCamera = this.transform.parent.GetComponent<Camera>();
        cam = this.transform.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (mainCamera == null || 
            (cam.clearFlags == mainCamera.clearFlags &&
            cam.backgroundColor == mainCamera.backgroundColor))
            return;

        cam.clearFlags = mainCamera.clearFlags;
        cam.backgroundColor = mainCamera.backgroundColor;
	}
}
