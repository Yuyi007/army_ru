using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BTEditor.control{

	public class Toggle : BaseControl {
		public delegate void ToggleDelegate(bool isbool);  
		public ToggleDelegate OnClick;  
		bool nowbool = false;  
		bool lastbool = false;  
		string txt = "";
		
		public bool IsCheck  {  
			get { return nowbool; }  
			set { nowbool = value; }  
		}   
		
		public Toggle(string txt, bool initBool, EditorWindow ewin, Rect rc, BaseControl parent = null)  
			: base(ewin, rc, parent) {  
			this.nowbool = initBool;  
			this.lastbool = initBool;  
			this.txt = txt;
		}  
		
		public override bool OnRender()  
		{    
			nowbool = GUI.Toggle (this.position, this.nowbool, this.txt);
			
			if (nowbool != lastbool)  
			{  
				if (OnClick != null)  
					OnClick(nowbool);  
				lastbool = nowbool;  
			}
			return true;
		}  
	}

}
