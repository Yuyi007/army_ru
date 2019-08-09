using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;
using System;
using LBoot;

namespace BTEditor.control{

	public class TaskNode : BTNode {

		public List<Textfield> lstTextfieldArgs = new List<Textfield>();
		public DropdownList<MethodDefine> ddlMethod;
		protected List<MethodDefine> lstMethods;
		private string _curMethod = null;

		public TaskNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		:base(ewin, rc, parent){
		}

		public TaskNode (){
		}
		
		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this.nodeCategory = "task";
			this.nodeName = "执行任务";
		}

		public override void LoadConfig(JsonData cfg, BTNode parentNode = null){
			base.LoadConfig (cfg, parentNode);
		}

		private void _calcPosition(){
			this.position.width = BTNode.EditWidth;
			this.position.height = BTNode.EditHeight;

			Vector2 ptStart = this.getEditPtStart ();
			ptStart.y += 22; //method ddl

            MethodDefine mf = MethodDefine.LstMethods[0];
			if (this._curMethod == null) {
				if (this._cfg != null && this._cfg.Keys.Contains("method")) 
					this._curMethod = (string)this._cfg ["method"];
			}
			
			if (this._curMethod != null) {
                mf = MethodDefine.LstMethods.Find (delegate(MethodDefine s) {
					return s.strName == this._curMethod;
				});
			}
			ptStart.y += mf.lstArgType.Count * 21;

			this.position.height = ptStart.y - this.position.y + 2;
			LogUtil.Debug (this.position.height);
		}

		protected override void BeforeFillEditCtrls(){
			this._calcPosition ();
			this._CalcBaseRects ();
		}

		protected bool OnSelMethodChange(MethodDefine mf){
			this.ClearEditCtrls ();
			this._curMethod = mf.strName;
			this.FillEditCtrls ();
			this.eWin.Repaint ();
			return false;
		}

		private void _FillMethod(){
			Vector2 ptStart = this.getEditPtStart ();
			Rect rcLM = new Rect(ptStart.x, ptStart.y, 40, 20);
			Label lmethod = new Label("方法:", this.eWin, rcLM, null);
			this._editCtrls.Add(lmethod);

			Rect rcDDL = new Rect(ptStart.x + 42, ptStart.y, this.position.width - 46 - this._rcBar.width, 22);
			ptStart.y += 22;

			int nIndex = 0;
            MethodDefine mf = MethodDefine.LstMethods[0];

			if (this._curMethod == null) {
				if (this._cfg != null && this._cfg.Keys.Contains("method")) 
					this._curMethod = (string)this._cfg ["method"];
			}

			if (this._curMethod != null) {
                nIndex = MethodDefine.LstMethods.FindIndex (delegate(MethodDefine s) {
					return s.strName == this._curMethod;
				});
                mf = MethodDefine.LstMethods.Find (delegate(MethodDefine s) {
					return s.strName == this._curMethod;
				});
			}

            ddlMethod = new DropdownList<MethodDefine>(this.eWin, rcDDL, null, MethodDefine.LstMethods, nIndex);
			ddlMethod.OnSelectChange = new DropdownList<MethodDefine>.DropDownListDelegate(OnSelMethodChange);
			this._editCtrls.Add (ddlMethod);
			
			for (int i = 0; i < mf.lstArgType.Count; i++) {
				string strArg = "";
				string ka = "arg"+(i+1).ToString();
				if(this._cfg != null && this._cfg.Keys.Contains(ka)){
					string t = mf.lstArgType[i];
					LogUtil.Debug(t);
					if(t == "string")
						strArg = (string)this._cfg[ka];
					else if(t == "float")
                        try{
            			    strArg = ((double)this._cfg[ka]).ToString();
                        }catch(Exception e){
                            int tmp = (int)this._cfg[ka];
                            strArg = ((double)tmp).ToString();
                        }
					else if(t == "int")
						strArg = ((int)this._cfg[ka]).ToString();
					else if(t == "bool")
						strArg = (bool)this._cfg[ka] ? "true" : "false";
					else
						LogUtil.Debug ("Error arguement type"+t.ToString());
					
				}
				
				Rect rcLA = new Rect(ptStart.x, ptStart.y + i * 22, 40, 20);
				Label label = new Label("参数"+(i+1).ToString()+":", this.eWin, rcLA, null);
				this._editCtrls.Add(label);
				
				Rect rcTF = new Rect(ptStart.x + 42, ptStart.y + i * 21, this.position.width - 46 - this._rcBar.width, 20);
				Textfield tf = new Textfield(strArg, this.eWin, rcTF, null );
				this.lstTextfieldArgs.Add(tf);
				this._editCtrls.Add(tf);
			}
			ptStart.y += mf.lstArgType.Count * 21;
		}

		protected override void FillEditCtrls(){
			base.FillEditCtrls ();
		
			this._FillMethod();
		}

		protected override void ClearEditCtrls(){
			base.ClearEditCtrls ();
			this.lstTextfieldArgs.Clear ();
		}

		public void SaveCommon(JsonWriter w){
			this.Copy2Out (w, "method", "string");

			if(this._cfg != null && this._cfg.Keys.Contains("method")){
                MethodDefine mf = MethodDefine.LstMethods.Find (delegate(MethodDefine s) {
					return s.strName == (string)this._cfg["method"];
				});

				for (int i = 0; i < mf.lstArgType.Count; i++) {
					string sa = "arg"+(i+1).ToString();

					string t = mf.lstArgType[i];
					//LogUtil.Debug(t);
					this.Copy2Out(w, sa, t);
				}
			}
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
	
			w.WritePropertyName ("method");
			MethodDefine md = this.ddlMethod.selectItem;
			w.Write (md.strName);

			for (int i = 0; i < this.lstTextfieldArgs.Count; i++) {
				Textfield tf = this.lstTextfieldArgs[i];
				if(tf.text != ""){
					w.WritePropertyName ("arg"+(i+1).ToString());
					string strType = (string)md.lstArgType[i];
					if(strType == "float"){
						w.Write(double.Parse(tf.text));
					}else if(strType == "bool"){
						if(tf.text == "true")
							w.Write(true);
						else
							w.Write(false);

					}else if(strType == "int"){
						w.Write(int.Parse(tf.text));
					}else if(strType == "string"){
						w.Write(tf.text);
					}
				}
			}
		}
	}

}
