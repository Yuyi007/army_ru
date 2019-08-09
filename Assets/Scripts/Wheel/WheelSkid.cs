using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;

// Example skid script. Put this on a WheelCollider.
// Copyright 2017 Nition, BSD licence (see LICENCE file). http://nition.co
// [RequireComponent(typeof(WheelCollider))]
[CustomLuaClassAttribute]
public class WheelSkid : MonoBehaviour {

	// INSPECTOR SETTINGS
	//[SerializeField]
	Skidmarks skidmarksController;

	// END INSPECTOR SETTINGS

	//WheelCollider wheelCollider;
	//WheelHit wheelHitInfo;

	//const float SKID_FX_SPEED = 0.5f; // Min side slip speed in m/s to start showing a skid
	//const float MAX_SKID_INTENSITY = 20.0f; // m/s where skid opacity is at full intensity
	//const float WHEEL_SLIP_MULTIPLIER = 10.0f; // For wheelspin. Adjust how much skids show
	int lastSkid = -1; // Array index for the skidmarks controller. Index of last skidmark piece this wheel used
    static float intensity = 0.2f;
    static float skid_time = 0.2f;
    static bool wheelSkidState = false;
    static float fadeIdensity = 0.0f;
    static float maxIdensity = 0.8f;

    public void SetSkidParams(float width, int limit, float life, float offset,float skidTime, float fadeIden = 0.0f, float maxIden = 0.8f)
    {
    	skidmarksController.MARK_WIDTH = width;
			skidmarksController.MAX_MARKS = limit;
			skidmarksController.SHOW_MARK_TIME = life;
			skidmarksController.GROUND_OFFSET=offset;
			skid_time = skidTime;

			fadeIdensity = fadeIden;
    	maxIdensity = maxIden;
    }
    // #### UNITY INTERNAL METHODS ####

	public static void ShowSkid(){
		wheelSkidState = true;
		intensity = fadeIdensity;
	}

	public static void HideSkid(){
		wheelSkidState = false;
	}


    public void Awake() {
        skidmarksController = GameObject.Find("skid_marks(Clone)").GetComponent<Skidmarks>();
	}


	public void LateUpdate() {
        if(wheelSkidState){
			Vector3 skidPoint = gameObject.transform.position;
			skidPoint.y = 0.01f;

			if(intensity < maxIdensity) 
			{
				float dt = Time.deltaTime / skid_time;
				intensity = intensity + dt;
			}

			lastSkid = skidmarksController.AddSkidMark(skidPoint, Vector3.up, intensity, lastSkid);
		}else{
			if(intensity > fadeIdensity)
			{
				Vector3 skidPoint = gameObject.transform.position;
				skidPoint.y = 0.01f;

				float dt = Time.deltaTime / skid_time;
				intensity = intensity - dt;

				lastSkid = skidmarksController.AddSkidMark(skidPoint, Vector3.up, intensity, lastSkid);
			}
			else
			{
				lastSkid= -1;
			}
		}
		
	}

	// #### PUBLIC METHODS ####

	// #### PROTECTED/PRIVATE METHODS ####


}
