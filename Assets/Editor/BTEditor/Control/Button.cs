using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BTEditor.control{
	public class Button : BaseControl {
		public string text;
		public Button(string txt, EditorWindow ewin, Rect rc, BaseControl parent) : base(ewin, rc, parent) {
			this.text = txt;
		}

		public delegate void ButtonDelegate();
		public ButtonDelegate OnClick;

		public override bool OnRender(){
			if (GUI.Button (this.position, this.text)) {
				if(this.OnClick != null){
					OnClick();
				}
			}
			return true;
		}
	}
}
