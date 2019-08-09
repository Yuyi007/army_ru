using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{

	public class LoopUntilNode : DecorateNode {
		private Textfield _tfNum;
		private Toggle _tgConditon;
		public LoopUntilNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}
		
		public LoopUntilNode(){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "loopuntil";
			this.nodeName = "循环直到节点";
		}
		
		protected override void BeforeFillEditCtrls(){
			base.BeforeFillEditCtrls ();
			this.position.height = this.getEditPtStart ().y - this.position.y + 22 + 22;
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

			ptStart.y += 22;

			//condition
			bool b = false;
			if (this._cfg != null && this._cfg.Keys.Contains ("condition")) {
				b = (bool)this._cfg["condition"];
			}
			rc = new Rect (ptStart.x, ptStart.y, 180, 20);
			this._tgConditon = new Toggle ("直到子节点返回成功", b, this.eWin, rc, null);
			this._editCtrls.Add (this._tgConditon);
		}
		
		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();
			
			this._tfNum = null;
			this._tgConditon = null;
		}
		
		private void _saveCommon(JsonWriter w){
			this.Copy2Out (w, "num", "int");
			this.Copy2Out (w, "condition", "string");
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

			w.WritePropertyName ("condition");
			bool condition = this._tgConditon.IsCheck;
			string str = condition ? "y" : "n";
			w.Write (str);
		}
	}

}
