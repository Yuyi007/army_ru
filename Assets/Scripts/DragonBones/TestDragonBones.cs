using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;


[RequireComponent(typeof(UnityArmatureComponent))]
public class TestDragonBones : MonoBehaviour {

	private UnityArmatureComponent _unityArmature;

	public float speed = 10.0f;

	public float juli=0f;

	public UnityEngine.UI.Image image;

	// Use this for initialization
	void Start () {
		this._unityArmature = GetComponent<UnityArmatureComponent>();
		Debug.Log(_unityArmature.transform.localPosition);
		Debug.Log(image.rectTransform.rect.width);
		juli=image.rectTransform.rect.width/2;
		_unityArmature.transform.localPosition=new Vector3(-juli,_unityArmature.transform.localPosition.y,_unityArmature.transform.localPosition.z);
		StartCoroutine(ShowDialog());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator ShowDialog(){
	    float timeSum = 0.0f;
	    while(this._unityArmature.transform.localPosition.x<juli){	    	
	     	timeSum += speed * Time.deltaTime;
	     	float pointX=-400+System.Convert.ToInt32(timeSum);
	     	_unityArmature.transform.localPosition=new Vector3(pointX,_unityArmature.transform.localPosition.y,_unityArmature.transform.localPosition.z);
	     	yield return null;
	    }
    }
}
