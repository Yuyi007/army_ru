using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{
	
	public class RetrunningNode : DecorateNode {
		public RetrunningNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public RetrunningNode(){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "retrunning";
			this.nodeName = "运行中节点";
		}
	}
	
}
