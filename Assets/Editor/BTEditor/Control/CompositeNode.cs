using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;
using LBoot;

namespace BTEditor.control{

	public class CompositeNode : BTNode {
		public CompositeNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public CompositeNode(){
		}

		protected override void BeforeFillEditCtrls (){
			this.position.width = BTNode.EditWidth;
			this.position.height = 90;
			this._CalcBaseRects ();
		}

		protected virtual void SaveCompositeOutput(JsonWriter w){
			this._saveComposite (w, false);
		}

		protected virtual void SaveCompositeProj(JsonWriter w){
			this._saveComposite (w, true);
		}

		private void _saveComposite(JsonWriter w, bool bProj){
			if (this.nodeChildren.Count > 0) {
				w.WritePropertyName("nodes");
				w.WriteArrayStart();
				foreach (BTNode node in this.nodeChildren) {
					if(bProj)
						node.SaveProject(w);
					else
						node.SaveOutput(w);
				}
				w.WriteArrayEnd();
			}
		}

		public override void SaveOutput(JsonWriter w){
			w.WriteObjectStart ();
			
			base.SaveOutput (w);
			this.SaveCompositeOutput (w);
			
			w.WriteObjectEnd ();
		}
		
		
		public override void SaveProject(JsonWriter w){
			w.WriteObjectStart ();
			//LogUtil.Debug (this.nodeCategory);
			base.SaveProject (w);
			this.SaveCompositeProj (w);
			
			w.WriteObjectEnd ();
		}

		protected virtual void bb_SaveProject(JsonWriter w){
			base.SaveProject (w);
		}
		
		protected virtual void bb_SaveOutput(JsonWriter w){
			base.SaveOutput (w);
		}
	}

}
