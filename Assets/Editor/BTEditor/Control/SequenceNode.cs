using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{
	
	public class SequenceNode : CompositeNode {
		
		public SequenceNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public SequenceNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "sequence";
			this.nodeName = "顺序节点";
		}
	}
	
}
