using UnityEngine;
using System.Collections;

public class SkillTesterSchedulerBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LBoot.GlobalScheduler.Init(gameObject.GetComponent<LBoot.SchedulerBehaviour>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
