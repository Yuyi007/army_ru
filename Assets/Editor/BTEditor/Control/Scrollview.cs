using UnityEngine;
using UnityEditor;
using System.Collections;
using LBoot;

namespace BTEditor.control{

	public class Scrollview : BaseControl {
		public Rect viewRect;
		public Vector2 scrollPosition;

		private Texture _textureBg = null;

		public Texture textureBg {
			get {
				return _textureBg;
			}
			set {
				_textureBg = value;
			}
		}

		private Vector2 _lastMousePt;
		private bool _mouseDown;
		private int _svBarWidth = 18;

		public Scrollview(EditorWindow ewin, Rect rc, BaseControl parent, Rect view):base(ewin, rc, parent){
			this.viewRect = view;
			this._textureBg = AssetDatabase.LoadAssetAtPath ("Assets/Editor/BTEditor/Assets/svbg.png", typeof(Texture)) as Texture;
		}

		public override bool OnRender(){
			if (this._textureBg != null) {
				Rect rcDraw = new Rect(this.position.x, this.position.y, this.position.width - this._svBarWidth, this.position.height - this._svBarWidth);
				Rect rcUV = new Rect (0,0, (this.position.width - this._svBarWidth)/this._textureBg.width , (this.position.height - this._svBarWidth)/this._textureBg.height);
				GUI.DrawTextureWithTexCoords (rcDraw, this._textureBg, rcUV);
			}
			this.scrollPosition = GUI.BeginScrollView (this.position, this.scrollPosition, viewRect);
				foreach (BaseControl ctrl in children) {
					ctrl.OnRender();
				}
			GUI.EndScrollView ();
			return true;
		}

		public override void OnMouseDrag(Event evt){
			if (this._mouseDown) {
				//LogUtil.Debug(_LastMousePt);
				//LogUtil.Debug(evt.mousePosition);
				this.scrollPosition.x -= evt.mousePosition.x - this._lastMousePt.x;
				this.scrollPosition.y -= evt.mousePosition.y - this._lastMousePt.y;
				this._lastMousePt = new Vector2(evt.mousePosition.x, evt.mousePosition.y); 
				this.eWin.Repaint();
			}
		}

		public override void OnMouseUp(Event evt){
			this._mouseDown = false;
		}

		public override void OnMouseDown(Event evt){
			Rect rcBottom = new Rect (this.position.x, this.position.y + this.position.height - this._svBarWidth, this.position.width, this._svBarWidth);
			Rect rcRight = new Rect (this.position.x + this.position.width - this._svBarWidth, this.position.y, this._svBarWidth, this.position.height);
			if (!rcBottom.Contains (evt.mousePosition) && !rcRight.Contains (evt.mousePosition)) {
				this._lastMousePt = new Vector2 (evt.mousePosition.x, evt.mousePosition.y);
				this._mouseDown = true;
			}
		}
	}

}
