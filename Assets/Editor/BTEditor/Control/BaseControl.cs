using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace BTEditor.control
{


    public class BaseControl
    {
        public EditorWindow eWin;
        public Rect position;
        public BaseControl parent;
        public List<BaseControl> children = new List<BaseControl>();
        protected bool _focus = false;
        public bool enabled = true;

        public BaseControl(EditorWindow ewin, Rect rc, BaseControl parent = null)
        {
            this.Initialize(ewin, rc, parent);
        }

        public BaseControl()
        {
        }

        public virtual void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null)
        {
            this.eWin = ewin;
            this.position = rc;
            this.parent = parent;
        }

        public void AddChild(BaseControl ctrl, int index = -1)
        {
            if (index == -1)
            {
                this.children.Add(ctrl);
            }
            else
            {
                this.children.Insert(index, ctrl);
            }
            ctrl.OnInit();
        }

        public void RemoveChild(BaseControl ctrl)
        {
            ctrl.OnDestroy();
            this.children.Remove(ctrl);
        }

        public void RemoveChild(int index)
        {
            BaseControl ctrl = this.children[index];
            ctrl.OnDestroy();
            this.children.RemoveAt(index);
        }

        public void RemoveAllChildren()
        {
            foreach (BaseControl ctrl in this.children)
            {
                ctrl.OnDestroy();
            }
            this.children.RemoveAll((BaseControl obj) =>
                {
                    return true;
                });
            this.eWin.Repaint();
        }

        public virtual void OnInit()
        {
        }

        public virtual void OnDestroy()
        {
        }

        public virtual void OnFocus()
        {
            this._focus = true;
        }

        public virtual void OnLostFocus()
        {
            this._focus = false;
        }


        public virtual void OnPreRender()
        {
            GUI.enabled = this.enabled;
        }

        public virtual void OnPostRender()
        {
            GUI.enabled = true;
        }

        public virtual bool OnRender()
        {
            foreach (BaseControl ctrl in children)
            {
                ctrl.OnPreRender();
                bool suc = ctrl.OnRender();
                ctrl.OnPostRender();
                if (!suc)
                    return false;
            }
            return true;
        }

        public virtual bool Intersect(Vector2 pt)
        {
            Rect rcGlobal = new Rect(this.position.x + this.parent.position.x, this.position.y + this.parent.position.y, this.position.width, this.position.height);
            return rcGlobal.Contains(pt);
        }

        public virtual BaseControl GetIntersectCtrl(Vector2 pt)
        {
            foreach (BaseControl ctrl in children)
            {
                if (ctrl.Intersect(pt))
                {
                    if (ctrl.children.Count > 0)
                    {
                        BaseControl child = ctrl.GetIntersectCtrl(pt);
                        if (child != null)
                            return child;
                        else
                            return ctrl;
                    }
                    else
                    {
                        return ctrl;
                    }
                }
            }
            return null;
        }

        public virtual void OnMouseDrag(Event evt)
        {
        }

        public virtual void OnMouseDown(Event evt)
        {
        }

        public virtual void OnMouseUp(Event evt)
        {
        }
    }

}
