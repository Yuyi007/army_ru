using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{

	public class RandomSequenceNode : CompositeNode {
		public RandomSequenceNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public RandomSequenceNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "randomsequence";
			this.nodeName = "随机顺序节点";
		}
	}

}
