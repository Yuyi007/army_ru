using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{

	public class PriorityNode : CompositeNode {

		public PriorityNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
			:base(ewin, rc, parent){
		}
		
		public PriorityNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "priority";
			this.nodeName = "优先节点";
		}
	}

}
