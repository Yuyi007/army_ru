using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{

	public class LoopNode : DecorateNode {
		private Textfield _tfNum;
		public LoopNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public LoopNode(){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "loop";
			this.nodeName = "循环节点";
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
			Label l = new Label ("循环的次数:", this.eWin, rc, null);
			this._editCtrls.Add (l);

			string strNum = "";
			if (this._cfg != null && this._cfg.Keys.Contains ("num")) {
				int num = (int)this._cfg["num"];
				strNum = num.ToString();
			}
			rc = new Rect (ptStart.x + 80, ptStart.y, 100, 20);
			this._tfNum = new Textfield (strNum, this.eWin, rc, null);
			this._editCtrls.Add (this._tfNum);
		}

		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();
			
			this._tfNum = null;
		}

		private void _saveCommon(JsonWriter w){
			this.Copy2Out (w, "num", "int");
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

			if (this._tfNum.text != "") {
				int num = int.Parse (this._tfNum.text);
				w.WritePropertyName ("num");
				w.Write (num);
			}
		}
	}

}
