using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;

namespace BTEditor.control{
	
	public class ParallelNode : CompositeNode {
		private Toggle _ckFailMode = null;
		private Toggle _ckSuccMode = null;
		private Toggle _ckLoopMode = null;
		private Toggle _ckStopMode = null;

		public ParallelNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public ParallelNode (){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "parallel";
			this.nodeName = "并行节点";
		}

		protected override void BeforeFillEditCtrls(){
			base.BeforeFillEditCtrls ();
			this.position.height = this.getEditPtStart ().y - this.position.y + 22*4;
			this._CalcBaseRects ();
		}

		protected override void FillEditCtrls(){
			base.FillEditCtrls ();
			
			Vector2 ptStart = this.getEditPtStart ();

			bool bFailMode = false;
			if (this._cfg != null && this._cfg.Keys.Contains ("failmode")) {
				string strMode = (string)this._cfg["failmode"];
				bFailMode = (strMode == "all") ? true : false;
			}
			Rect rcFCK = new Rect (ptStart.x, ptStart.y, 180, 20);
			this._ckFailMode = new Toggle ("(全部/一个)败为失败", bFailMode, this.eWin, rcFCK, null);
			this._editCtrls.Add (this._ckFailMode);

			ptStart.y += 22 + 2;


			bool bSuccMode = false;
			if (this._cfg != null && this._cfg.Keys.Contains ("successmode")) {
				string strMode = (string)this._cfg["successmode"];
				bSuccMode = (strMode == "all") ? true : false;
			}
			Rect rcSCK = new Rect (ptStart.x, ptStart.y, 180, 20);
			this._ckSuccMode = new Toggle ("(全部/一个)成功为成功", bSuccMode, this.eWin, rcSCK, null);
			this._editCtrls.Add (this._ckSuccMode);
			
			ptStart.y += 22 + 2;


			bool bLoopMode = false;
			if (this._cfg != null && this._cfg.Keys.Contains ("childloopmode")) {
				string strMode = (string)this._cfg["childloopmode"];
				bLoopMode = (strMode == "y") ? true : false;
			}
			Rect rcLCK = new Rect (ptStart.x, ptStart.y, 180, 20);
			this._ckLoopMode = new Toggle ("已结束子节点下次（是/否）执行", bLoopMode, this.eWin, rcLCK, null);
			this._editCtrls.Add (this._ckLoopMode);
			
			ptStart.y += 22 + 2;


			bool bStopMode = false;
			if (this._cfg != null && this._cfg.Keys.Contains ("stoprunning")) {
				string strMode = (string)this._cfg["stoprunning"];
				bStopMode = (strMode == "y") ? true : false;
			}
			Rect rcTCK = new Rect (ptStart.x, ptStart.y, 180, 20);
			this._ckStopMode = new Toggle ("(是/否)结束正运行节点", bStopMode, this.eWin, rcTCK, null);
			this._editCtrls.Add (this._ckStopMode);

		}
		
		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();

			this._ckFailMode = null;
			this._ckLoopMode = null;
			this._ckStopMode = null;
			this._ckSuccMode = null;
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
			this.Copy2Out (w, "failmode", "string");
			this.Copy2Out (w, "successmode", "string");
			this.Copy2Out (w, "childloopmode", "string");
			this.Copy2Out (w, "stoprunning", "string");
		}
		
		protected override void OnProcBtnSave(JsonWriter w){
			base.OnProcBtnSave (w);
			
			w.WritePropertyName ("failmode");
			bool bMode = this._ckFailMode.IsCheck;
			string str = bMode ? "all" : "one";
			w.Write (str);

			w.WritePropertyName ("successmode");
			bMode = this._ckSuccMode.IsCheck;
			str = bMode ? "all" : "one";
			w.Write (str);

			w.WritePropertyName ("childloopmode");
			bMode = this._ckLoopMode.IsCheck;
			str = bMode ? "y" : "n";
			w.Write (str);

			w.WritePropertyName ("stoprunning");
			bMode = this._ckStopMode.IsCheck;
			str = bMode ? "y" : "n";
			w.Write (str);
		}
	}

}
