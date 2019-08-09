using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{
	
	public class WeightSelectorNode : CompositeNode {
		
		public WeightSelectorNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public WeightSelectorNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "weightselector";
			this.nodeName = "权重节点";
		}

	}
	
}
