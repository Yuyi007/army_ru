using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BTEditor.control{
	public class Label : BaseControl {
		string text;

		public Label(string text, EditorWindow ewin, Rect rc, BaseControl parent)
		:base(ewin, rc, parent){
			this.text = text;
		}

		public override bool OnRender(){
			GUI.Label (this.position, this.text);
			return true;
		}
	}
}
