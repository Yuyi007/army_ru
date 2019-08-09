using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control{
	
	public class SubTreeNode : BTNode {

		public DropdownList<SubTreeDefine> ddlSubTree;
		protected List<SubTreeDefine> lstSubTree;
		private string _curSubTree = null;

		public SubTreeNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}
		
		public SubTreeNode (){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "subtree";
			this.nodeName = "子树节点";
		}

		protected override void BeforeFillEditCtrls (){
			this.position.width = BTNode.EditWidth;

			Vector2 ptStart = this.getEditPtStart ();
			ptStart.y += 22; //method ddl
			this.position.height = ptStart.y - this.position.y + 2;
	
			this._CalcBaseRects ();
		}

		protected bool OnSelectSubTreeChange(SubTreeDefine sd){
			this._curSubTree = sd.strName;
			return false;
		}
		
		protected override void FillEditCtrls(){
			base.FillEditCtrls ();
			
			Vector2 ptStart = this.getEditPtStart ();
			Rect rcLM = new Rect(ptStart.x, ptStart.y, 40, 20);
			Label lmethod = new Label("子树:", this.eWin, rcLM, null);
			this._editCtrls.Add(lmethod);
			
			Rect rcDDL = new Rect(ptStart.x + 42, ptStart.y, this.position.width - 46 - this._rcBar.width, 22);
			ptStart.y += 22;
			
			int nIndex = 0;

			if (this._curSubTree == null) {
				if (this._cfg != null && this._cfg.Keys.Contains("subtree")) 
					this._curSubTree = (string)this._cfg ["subtree"];
			}
			
			if (this._curSubTree != null) {
                nIndex = SubTreeDefine.LstSubTrees.FindIndex (delegate(SubTreeDefine s) {
					return s.strName == this._curSubTree;
				});
			}

            this.ddlSubTree = new DropdownList<SubTreeDefine>(this.eWin, rcDDL, null, SubTreeDefine.LstSubTrees, nIndex);
			this.ddlSubTree.OnSelectChange = new DropdownList<SubTreeDefine>.DropDownListDelegate(OnSelectSubTreeChange);
			this._editCtrls.Add (ddlSubTree);
		}

		private void SaveCommon(JsonWriter w){
			this.Copy2Out (w, "subtree", "string");
		}

		public override void SaveOutput(JsonWriter w){
			w.WriteObjectStart ();
			
			base.SaveOutput (w);
			this.SaveCommon (w);
			
			w.WriteObjectEnd ();
		}
		
		public override void SaveProject(JsonWriter w){
			w.WriteObjectStart ();
			
			base.SaveProject (w);
			this.SaveCommon (w);
			
			w.WriteObjectEnd ();
		}

		protected override void OnProcBtnSave(JsonWriter w){
			base.OnProcBtnSave (w);
			
			w.WritePropertyName ("subtree");
			SubTreeDefine sd = this.ddlSubTree.selectItem;
			w.Write (sd.strName);
		}
	}
	
}
