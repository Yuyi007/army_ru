using UnityEngine;
using UnityEditor;
using System.Collections;

namespace BTEditor.control{

	public class Textfield : BaseControl {

		public string text ;
		public Textfield(string text, EditorWindow ewin, Rect rc, BaseControl parent)
			: base(ewin, rc, parent){
			this.text = text;
		}

		public override bool OnRender(){
			this.text = GUI.TextField (this.position, this.text);
			return true;
		}
	}

}

