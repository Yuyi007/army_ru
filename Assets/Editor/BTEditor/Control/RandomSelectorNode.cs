using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{
	
	public class RandomSelectorNode : CompositeNode {
		
		public RandomSelectorNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public RandomSelectorNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "randomselector";
			this.nodeName = "随机节点";
		}
	}
	
}
