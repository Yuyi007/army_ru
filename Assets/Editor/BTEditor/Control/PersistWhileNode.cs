using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{
	
	public class PersistWhileNode : DecorateNode {
		private Textfield _tfTime;
		public PersistWhileNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public PersistWhileNode(){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "persistwhile";
			this.nodeName = "持续时间节点";
		}
		
		protected override void BeforeFillEditCtrls(){
			base.BeforeFillEditCtrls ();
			this.position.height = this.getEditPtStart ().y - this.position.y + 22;
			this._CalcBaseRects ();
		}
		
		protected override void FillEditCtrls(){
			base.FillEditCtrls ();
			
			Vector2 ptStart = this.getEditPtStart ();
			
			Rect rc = new Rect (ptStart.x, ptStart.y, 80, 20);
			Label l = new Label ("持续时间:", this.eWin, rc, null);
			this._editCtrls.Add (l);
			
			string strTime = "";
			if (this._cfg != null && this._cfg.Keys.Contains ("tmspan")) {
				double span = (double)this._cfg["tmspan"];
				strTime = span.ToString();
			}
			rc = new Rect (ptStart.x + 80, ptStart.y, 100, 20);
			this._tfTime = new Textfield (strTime, this.eWin, rc, null);
			this._editCtrls.Add (this._tfTime);
		}
		
		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();
			
			this._tfTime = null;
		}
		
		private void _saveCommon(JsonWriter w){
			this.Copy2Out (w, "tmspan", "float");
		}
		
		public override void SaveOutput(JsonWriter w){
			w.WriteObjectStart ();
			
			base.bb_SaveOutput (w);
			base.SaveDecorateOutput (w);
			this._saveCommon (w);
			
			w.WriteObjectEnd ();
		}
		
		public override void SaveProject(JsonWriter w){
			w.WriteObjectStart ();
			
			base.bb_SaveProject (w);
			base.SaveDecorateProj (w);
			this._saveCommon (w);
			
			w.WriteObjectEnd ();
		}
		
		protected override void OnProcBtnSave(JsonWriter w){
			base.OnProcBtnSave (w);
			
			if (this._tfTime.text != "") {
				float num = float.Parse (this._tfTime.text);
				w.WritePropertyName ("tmspan");
				w.Write (num);
			}
		}
	}
	
}
