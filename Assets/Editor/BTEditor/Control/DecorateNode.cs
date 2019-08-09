using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{
	
	public class DecorateNode : BTNode {
		public DecorateNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public DecorateNode(){
		}

		protected override void BeforeFillEditCtrls (){
			this.position.width = BTNode.EditWidth;
			this.position.height = 90;
			this._CalcBaseRects ();
		}

		protected virtual void SaveDecorateOutput(JsonWriter w){
			this._saveDecorate (w, false);
		}
		
		protected virtual void SaveDecorateProj(JsonWriter w){
			this._saveDecorate (w, true);
		}

		private void _saveDecorate(JsonWriter w, bool bProj){
			if (this.nodeChildren.Count > 0) {
				w.WritePropertyName("node");
				if(bProj)
					this.nodeChildren[0].SaveProject(w);
				else
					this.nodeChildren[0].SaveOutput(w);
			}
		}

		public override void SaveOutput(JsonWriter w){
			w.WriteObjectStart ();
			
			base.SaveOutput (w);
			this.SaveDecorateOutput (w);
			
			w.WriteObjectEnd ();
		}
		
		
		public override void SaveProject(JsonWriter w){
			w.WriteObjectStart ();
			
			base.SaveProject (w);
			this.SaveDecorateProj (w);
			
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
