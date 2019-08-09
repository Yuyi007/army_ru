using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{

	public class InverterNode : DecorateNode {
		public InverterNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public InverterNode(){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "inverter";
			this.nodeName = "取反节点";
		}
	}

}
