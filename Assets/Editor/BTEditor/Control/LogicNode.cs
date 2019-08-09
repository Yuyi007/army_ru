using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{

	public class LogicNode : CompositeNode{
		private Textfield _tfLogic;

		public LogicNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public LogicNode (){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "logic";
			this.nodeName = "逻辑运算节点";
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
			Label l = new Label ("逻辑运算符:", this.eWin, rc, null);
			this._editCtrls.Add (l);
			
			string strLogic = "";
			if (this._cfg != null && this._cfg.Keys.Contains ("logic")) {
				strLogic = (string)this._cfg["logic"];
			}
			rc = new Rect (ptStart.x + 80, ptStart.y, 100, 20);
			this._tfLogic = new Textfield (strLogic, this.eWin, rc, null);
			this._editCtrls.Add (this._tfLogic);
		}
		
		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();
			
			this._tfLogic = null;
		}

		public override void SaveOutput(JsonWriter w){
			w.WriteObjectStart ();
			
			base.bb_SaveOutput (w);
			base.SaveCompositeOutput (w);
			this.SaveCommon (w);
			
			w.WriteObjectEnd ();
		}
		
		public override void SaveProject(JsonWriter w){
			w.WriteObjectStart ();
			
			base.bb_SaveProject (w);
			base.SaveCompositeProj (w);
			this.SaveCommon (w);
			
			w.WriteObjectEnd ();
		}
		
		private void SaveCommon(JsonWriter w){
			this.Copy2Out (w, "logic", "string");
		}
		
		protected override void OnProcBtnSave(JsonWriter w){
			base.OnProcBtnSave (w);

			if (this._tfLogic.text != "") {
				w.WritePropertyName ("logic");
				string strLogic = this._tfLogic.text;
				w.Write (strLogic);
			}
		}
	}

}
