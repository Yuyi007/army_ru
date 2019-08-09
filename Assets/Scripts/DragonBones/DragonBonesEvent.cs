using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class DragonBonesEvent : MonoBehaviour {


	[SerializeField]
	private TextAsset dragonBonesJSON;
	
	[SerializeField]
	private string textureAtlasJSONPath;

	[SerializeField]
	private float scale=1.0f;

	[SerializeField]
	private string armatureName;
	[SerializeField]
	private Vector3 localPosition;
	[SerializeField]
	private string animationMethod;

	private UnityArmatureComponent _mechaArmatureComp = null;
	// Use this for initialization
	void Start () {
		UnityFactory.factory.LoadDragonBonesData(dragonBonesJSON);
	
		UnityFactory.factory.LoadTextureAtlasData(textureAtlasJSONPath);
		// Build Mecha Armature
		this._mechaArmatureComp = UnityFactory.factory.BuildArmatureComponent(armatureName);
		//Set position

		this._mechaArmatureComp.transform.localPosition = localPosition;
		this._mechaArmatureComp.transform.localScale= new Vector3(scale,scale,scale);
		// Add animation event listener
		//this._mechaArmatureComp.AddDBEventListener(EventObject.COMPLETE, this.OnAnimationEventHandler);
		this._mechaArmatureComp.animation.Play(animationMethod);
	}

	
	
	// Update is called once per frame
	void Update () {
		// if(Input.GetMouseButtonDown(0)){
		// 	this._mechaArmatureComp.animation.FadeIn("skill_03", 0.2f);
		// }
	}


	/// <summary>
	///  龙骨动画播发完回调方面
	/// </summary>
	/// <param name="type"></param>
	/// <param name="eventObject"></param>
	void OnAnimationEventHandler(string type, EventObject eventObject)
	{
		if(eventObject.animationState.name == "skill_03"){
			Debug.Log("1111");
			this._mechaArmatureComp.animation.FadeIn("walk", 0.2f);
		}
	}
}
