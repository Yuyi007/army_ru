using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using SLua;

[CustomLuaClassAttribute]
public class BindDropdownData : MonoBehaviour {

	[SerializeField]
	public UnityEngine.UI.Dropdown dropdown;

	public List<UnityEngine.UI.Dropdown.OptionData> list;

	// Use this for initialization
	void Start () {
		list=new List<UnityEngine.UI.Dropdown.OptionData>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetItems(string str){
		UnityEngine.UI.Dropdown.OptionData op=new UnityEngine.UI.Dropdown.OptionData();
		op.text = str;
		list.Add(op);
    }

    public void ClearDropdownData(){
    	list=new List<UnityEngine.UI.Dropdown.OptionData>();
    }

    public void RefreshDropdownData(){
    	dropdown.options=list;
    }
}
