using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System.Text;
using UnityEngine.UI.Extensions;
using System;
using LBoot;

namespace BTEditor.control{
	public class BTNode : BaseControl {
		public static int DefaultWidth = 100;
		public static int DefaultHeight = 30;

		public static int EditWidth = 200;
		public static int EditHeight = 300;

		public static int SaveBtnHeight = 22;


		public BTNode nodeParent = null;
		public List<BTNode> nodeChildren = new List<BTNode> ();

		public string nodeCategory = "";
		public string nodeName = "基类节点";
		public int nodeIndex = 1;

		protected Rect _rcBody;
		protected Rect _rcBar;
		protected Rect _rcTxt;
		protected Rect _rcIndex;

		protected bool _mouseDownBody = false;
		protected bool _mouseDownBar = false;
		private Vector2 _ptMouseLast;   
		
		protected Texture _textureBg = null;
		protected Texture _textureBgFocus = null;
		protected Texture _textureBar = null;

		protected bool _editMode = false;

		protected List<BaseControl> _editCtrls = new List<BaseControl>();
		protected Textfield _tfName ;
		protected Textfield _tfWeight;

		protected JsonData _cfg; //for project
		protected JsonData _out; //for game

		public BTNode(EditorWindow ewin, Rect rc, BaseControl parent = null)
		: base(ewin, rc, parent){
		}

		public BTNode(){
		}

		public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null){
			base.Initialize (ewin, rc, parent);
			this._textureBg = AssetDatabase.LoadAssetAtPath ("Assets/Editor/BTEditor/Assets/nodebg.png", typeof(Texture)) as Texture;
			this._textureBar = AssetDatabase.LoadAssetAtPath ("Assets/Editor/BTEditor/Assets/nodebar.png", typeof(Texture)) as Texture;
			this._textureBgFocus = AssetDatabase.LoadAssetAtPath ("Assets/Editor/BTEditor/Assets/nodebgfocus.png", typeof(Texture)) as Texture;
			
			this._CalcBaseRects ();
		}

		public virtual void LoadConfig(JsonData cfg, BTNode parentNode = null){
			this._cfg = cfg;
			this.SetNodeParent (parentNode);

			if (this._cfg.Keys.Contains ("px")) {
				float x = (float)(double)this._cfg["px"];
				this.position.x = x;
			}

			if (this._cfg.Keys.Contains ("py")) {
				float y = (float)(double)this._cfg["py"];
				this.position.y = y;
			}

			if (this._cfg.Keys.Contains ("pw")) {
				float w = (float)(double)this._cfg["pw"];
				this.position.width = w;
			}

			if (this._cfg.Keys.Contains ("ph")) {
				float h = (float)(double)this._cfg["ph"];
				this.position.height = h;
			}

			if (this._cfg.Keys.Contains ("diyname")) {
				this.nodeName = (string)this._cfg["diyname"];
			}

			this._CalcBaseRects ();
		}

		public virtual void BeginEditMode(){
			this._editMode = true;
			this.FillEditCtrls ();
			this._CalcBaseRects ();
			this.eWin.Repaint ();
		}

		public virtual void EndEditMode(){
			this._editMode = false;
			this.ClearEditCtrls ();
			this._CalcBaseRects ();
			this.eWin.Repaint ();
		}

		protected void Copy2Out(JsonWriter w, string key, string t){
			if (this._cfg == null)
				return;

			if (this._cfg.Keys.Contains (key)) {
				w.WritePropertyName (key);
				if(t == "string")
					w.Write ((string)this._cfg [key]);
				else if(t == "float")
                    try{
                        double db = (double)this._cfg [key];
                        w.Write (db);
                    }catch(Exception e){
                        int db = (int)this._cfg [key];
                        w.Write ((double)db);
                    }

					
				else if(t == "int")
					w.Write ((int)this._cfg [key]);
				else if(t == "bool")
					w.Write ((bool)this._cfg [key]);
				else
					LogUtil.Debug("Error arguement type"+t.ToString());
			}
		}

		protected void SavePosition(JsonWriter w){
			w.WritePropertyName ("px");
			w.Write ((double)this.position.x);

			w.WritePropertyName ("py");
			w.Write ((double)this.position.y);

			w.WritePropertyName ("pw");
			w.Write ((double)this.position.width);

			w.WritePropertyName ("ph");
			w.Write ((double)this.position.height);
		}

		public virtual void SaveProject(JsonWriter w){
			w.WritePropertyName ("kind");
			w.Write (this.nodeCategory);

			this.Copy2Out (w, "diyname", "string");
			this.Copy2Out (w, "weight", "string");

			this.SavePosition (w);
		}

		public virtual void SaveOutput(JsonWriter w){
			w.WritePropertyName ("kind");
			w.Write (this.nodeCategory);
            //this.Copy2Out (w, "diyname", "string");
			this.Copy2Out (w, "weight", "string");
		}

		protected virtual void OnProcBtnSave(JsonWriter w){
			if (this._tfName.text != "") {
				w.WritePropertyName ("diyname");
				w.Write (this._tfName.text);
				this.nodeName = this._tfName.text;
			}

			this.SavePosition (w);
		
			if (this.nodeParent != null && this.nodeParent.nodeCategory == "weightselector") {
				w.WritePropertyName ("weight");
                w.Write (this._tfWeight.text);

			}
		}

		protected virtual void OnBtnSave(){
			LogUtil.Debug ("On Btn Save");
			StringBuilder sb = new StringBuilder();
			JsonWriter w = new JsonWriter (sb);
			
			w.WriteObjectStart ();

			this.OnProcBtnSave (w);

			w.WriteObjectEnd ();

			this._cfg = JsonMapper.ToObject(sb.ToString ());
		}

		protected Vector2 getEditPtStart(){
			Vector2 v = new Vector2 (this.position.x + this._rcBar.width + 2, 
			                                      this.position.y + BTNode.DefaultHeight + BTNode.SaveBtnHeight + 22 + 4);
			if (this.nodeParent != null && this.nodeParent.nodeCategory == "weightselector") {
				v.y += 22;
			}
			return v;
		}

		protected virtual void BeforeFillEditCtrls (){
			this.position.width = BTNode.EditWidth;
			this.position.height = BTNode.EditHeight;
		}

		protected virtual void FillEditCtrls(){
			this.BeforeFillEditCtrls ();

			//for weight selector special proccess
			if (this.nodeParent != null && this.nodeParent.nodeCategory == "weightselector") {
				this.position.height += 22;
				this._CalcBaseRects();
			}

			Rect rcBtn = new Rect (this.position.x + 50, this.position.y + BTNode.DefaultHeight + 2, 80, BTNode.SaveBtnHeight);
			Button btnSave = new Button ("Save", this.eWin, rcBtn, null);
			btnSave.OnClick = new Button.ButtonDelegate(OnBtnSave);
			this._editCtrls.Add(btnSave);

			float y = this.position.y + BTNode.DefaultHeight + BTNode.SaveBtnHeight + 4;
			float x = this.position.x + this._rcBar.width + 2;
			Rect rcLabel = new Rect (x, y, 40, 20);
			Label labelName = new Label("名称:", this.eWin, rcLabel, null);
			this._editCtrls.Add(labelName);

			string strDiyName = "";
			if(this._cfg != null && this._cfg.Keys.Contains ("diyname"))
				strDiyName = (string)this._cfg["diyname"];
			float wtf = this.position.width - 46 - this._rcBar.width;
			Rect rcTextfield = new Rect(x + 40, y, wtf, 20);
			this._tfName = new Textfield (strDiyName, this.eWin, rcTextfield, null);
			this._editCtrls.Add(this._tfName);

			//for weight selector special proccess
			if (this.nodeParent != null && this.nodeParent.nodeCategory == "weightselector") {
				y += 22;
				Rect rcWL = new Rect (x, y, 40, 20);
				Label labelW = new Label("权重:", this.eWin, rcWL, null);
				this._editCtrls.Add(labelW);

				string strWeight = "";
				if(this._cfg != null && this._cfg.Keys.Contains ("weight"))
                    strWeight =  (string)this._cfg["weight"];

				Rect rctfW = new Rect(x + 40, y, wtf, 20);
				this._tfWeight = new Textfield (strWeight, this.eWin, rctfW, null);
				this._editCtrls.Add(this._tfWeight);
			}
		}

		protected virtual void ClearEditCtrls(){
			this.position.width = BTNode.DefaultWidth;
			this.position.height = BTNode.DefaultHeight;
			this._editCtrls.Clear();
		}

		public override bool Intersect(Vector2 pt){
			Scrollview sv = this.parent as Scrollview;
			Rect rcGlobal = new Rect (this.position.x + this.parent.position.x - sv.scrollPosition.x, this.position.y + this.parent.position.y - sv.scrollPosition.y, this.position.width, this.position.height);
			return rcGlobal.Contains(pt);
		}

		protected void _CalcBaseRects(){
			int barW = this._textureBar.width; 
			int barH = this._textureBar.height;

			Rect rcMain = this.position;
			this._rcBody = new Rect (rcMain.x + barW, rcMain.y, rcMain.width - barW, rcMain.height);
			this._rcBar = new Rect (rcMain.x, rcMain.y + (rcMain.height - barH) / 2, barW, barH);
			this._rcTxt = new Rect (rcMain.x + barW + 14, rcMain.y + 7 , rcMain.width - barW - 4, 16);
			this._rcIndex = new Rect (rcMain.x + barW + 1, rcMain.y + 7, rcMain.width - barW - 4, 16);
		}

		protected virtual void CheckMouseHitArea(Vector2 pt){
			Scrollview sv = this.parent as Scrollview;
			Vector2 relativePt = new Vector2(pt.x - sv.position.x + sv.scrollPosition.x, pt.y - sv.position.y + sv.scrollPosition.y); 
			if (this._rcBody.Contains (relativePt)) {
				this._mouseDownBody = true;
				this._mouseDownBar = false;
			} else {
				this._mouseDownBody = false;
				this._mouseDownBar = true;
			}
		}

		public override bool OnRender(){
			base.OnRender ();

			//body background
			if (this._focus) 
				GUI.DrawTexture (this._rcBody, this._textureBgFocus, ScaleMode.StretchToFill);
			else
				GUI.DrawTexture (this._rcBody, this._textureBg, ScaleMode.StretchToFill);

			//bar
			GUI.DrawTexture (this._rcBar, this._textureBar, ScaleMode.StretchToFill);

			//text
			GUI.Label (this._rcTxt, this.nodeName);

			//index
			GUI.Label (this._rcIndex, this.nodeIndex.ToString());

			//line
			if (this._mouseDownBar) {
				Scrollview sv = this.parent as Scrollview;
				Vector2 ptA = new Vector2 (this._rcBar.x, this._rcBar.y + this._rcBar.height/2);
				Vector2 ptB = new Vector2 (this._ptMouseLast.x - sv.position.x + sv.scrollPosition.x, this._ptMouseLast.y - sv.position.y + sv.scrollPosition.y);
				Handles.BeginGUI ();
				Handles.DrawLine (new Vector3 (ptA.x, ptA.y), new Vector3 (ptB.x, ptB.y));
				Handles.EndGUI ();
			}
			else{
				if(this.nodeParent != null){
					Vector2 ptA = new Vector2 (this._rcBar.x, this._rcBar.y + this._rcBar.height/2);
					Vector2 ptB = new Vector2 (this.nodeParent.position.x + this.nodeParent.position.width, this.nodeParent.position.y + this.nodeParent.position.height/2);
					Handles.BeginGUI ();
					Handles.DrawLine (new Vector3 (ptA.x, ptA.y), new Vector3 (ptB.x, ptB.y));
					Handles.EndGUI ();
				}
			}

			if (this._editMode) {
				if(!this.OnRenderEditMode())
					return false;
			}

			return true;
		}

		public virtual bool OnRenderEditMode(){
			foreach (BaseControl ctrl in this._editCtrls) {
				bool suc = ctrl.OnRender();
				if(!suc)
					return false;
			}
			return true;
		}

		public override void OnFocus(){
			base.OnFocus ();
			this.eWin.Repaint ();
		}
		
		public override void OnLostFocus(){
			base.OnLostFocus ();

			if (this._editMode)
				this.EndEditMode ();
			else
				this.eWin.Repaint ();
		}

		public override void OnMouseDrag(Event evt){
			if (this._editMode)
				return;

			float dtX = evt.mousePosition.x - this._ptMouseLast.x;
			float dtY = evt.mousePosition.y - this._ptMouseLast.y;
	
			if (this._mouseDownBody) {
				this.position.x += dtX;
				this.position.y += dtY;
				this._CalcBaseRects();
			}
			this.eWin.Repaint();
			this._ptMouseLast = evt.mousePosition;
		}
		
		public override void OnMouseDown(Event evt){
			if (this._editMode)
				return;

			this.CheckMouseHitArea (evt.mousePosition);
			this._ptMouseLast = evt.mousePosition;
		}

		private BTNode _GetRootNode(){
			BTNode n = this;
			while (n.nodeParent != null) {
				n = n.nodeParent;
			}
			return n;
		}


		private BTNode _GetIntersectNode(Vector2 pt){
			BaseControl ctrl = this.parent.GetIntersectCtrl (pt);
			BTNode n = ctrl as BTNode;
			if (this.nodeChildren.Contains (n))
				return null;

			return n;
		}

		public void SetNodeParent(BTNode n){
			if (this.nodeParent != null) {
				this.nodeParent.RemoveChildNode(this);
			}

			this.nodeParent = n;

			if (n != null) {
				n.AddChildNode(this);
			}
		}

		public override void OnMouseUp(Event evt){
			if (this._editMode)
				return;

			if (this._mouseDownBar) {
				BTNode n = this._GetIntersectNode(evt.mousePosition);
				LogUtil.Debug (n);
				if(n != null){
					bool add = true;
					//must not self
					if(n == this)
						add = false;

					//entry child must be one
					if(( n as BTEntry != null) && n.nodeChildren.Count > 0)
						add = false;

					//task node can't has child
					if(n.nodeCategory == "task")
						add = false;

					//condition children count must less than 3
					if((n.nodeCategory == "conditionselector") && (n.nodeChildren.Count == 3))
						add = false;

					//logic children count must less than 2
					if((n.nodeCategory == "logic") && (n.nodeChildren.Count == 2))
						add = false;

					//loop monitor inverter retfail retsuccess utlfail utlsuccess must has only one child
					if((n.nodeCategory == "loop" ||
					   n.nodeCategory == "monitor" ||
					   n.nodeCategory == "inverter" ||
					   n.nodeCategory == "retfail" ||
					   n.nodeCategory == "retsuccess" ||
					   n.nodeCategory == "utlfail" ||
					   n.nodeCategory == "utlsuccess") && n.nodeChildren.Count == 1)
						add = false;

		
					if(add)
						this.SetNodeParent(n);
				}
				else{
					this.SetNodeParent(null);
				}
			}

			this._mouseDownBar = false;
			this._mouseDownBody = false;
			this.eWin.Repaint ();

			if (evt.button == 1 && evt.isMouse) {
				BTEntry en = this as BTEntry;
				if(en == null){
					//show menu
					EditorUtility.DisplayPopupMenu (new Rect (evt.mousePosition.x, evt.mousePosition.y, 0, 0), "Tools/AI/Edit/", null);
				}
			}
		}

		public override void OnDestroy(){
			foreach(BTNode n in this.nodeChildren){
				n.nodeParent = null;
			}
			this.nodeChildren.Clear();

			if (this.nodeParent != null) {
				this.nodeParent.nodeChildren.Remove (this);
			}
		}

		public void AddChildNode(BTNode node){
			this.nodeChildren.Add (node);
			node.nodeIndex = this.nodeChildren.Count;
			//LogUtil.Debug (node.nodeIndex);
		}

		public void RemoveChildNode(BTNode node){
			this.nodeChildren.Remove (node);

			int nIndex = 1;
			foreach (BTNode n in this.nodeChildren) {
				n.nodeIndex = nIndex;
				nIndex += 1;
			}

			this.eWin.Repaint ();
		}

	}
}
