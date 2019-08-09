using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace BTEditor.control{

	public class DropdownList<T> : BaseControl {
		public int popup = 0;
		public List<T> items;
		public T selectItem { private set; get; }
		public int selectIndex { private set; get; }

		public delegate bool DropDownListDelegate(T t);
		public DropDownListDelegate OnSelectChange;

		public DropdownList(EditorWindow ewin, Rect rc, BaseControl parent, List<T> items, int selected) : base(ewin, rc, parent) {
			this.items = items;
			this.popup = selected; 
		}

		public override bool OnRender(){
			base.OnRender ();

			List<string> names = new List<string>();  
			foreach (T item in this.items)  
				names.Add(item.ToString());  

			int oldPop = popup;
			popup = EditorGUI.Popup (this.position, popup, names.ToArray());

			if (popup >= 0 && popup < this.items.Count) {
				this.selectItem = this.items[popup];
				this.selectIndex = popup;
				if(oldPop != popup){
					if(this.OnSelectChange != null )
						return this.OnSelectChange(this.selectItem);
				}
				else
				{
					return true;
				}
			}

			return true;
		}
	}
}
