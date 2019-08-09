using UnityEngine;
using UnityEditor;
using System.Collections;
using LBoot;

namespace BTEditor.control{

	public class Dialog : BaseControl {
		public BaseControl currentControl;

		public Dialog(EditorWindow ewin, Rect rc) 
			: base(ewin, rc, null){
		}
		
		public override void OnMouseDrag(Event evt){
			if (this.currentControl != null) {
				this.currentControl.OnMouseDrag(evt);
			}
		}

		public override void OnMouseDown(Event evt){
			BaseControl ctrl = this.GetIntersectCtrl (evt.mousePosition);
			if (ctrl != null) {
				if(ctrl != this.currentControl){
					if(this.currentControl != null)
						this.currentControl.OnLostFocus();

					this.currentControl = ctrl;
					LogUtil.Debug (this.currentControl);
					this.currentControl.OnFocus();
				}
				ctrl.OnMouseDown(evt);
			}
		}
		
		public override void OnMouseUp(Event evt){
			if (currentControl != null) {
				currentControl.OnMouseUp(evt);
			}
		}
	}
}
