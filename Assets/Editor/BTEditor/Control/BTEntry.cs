using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using LitJson;

namespace BTEditor.control
{
	
    public class BTEntry : CompositeNode
    {
        public string AgentCategory;

        public BTEntry(EditorWindow ewin, Rect rc, BaseControl parent = null)
            : base(ewin, rc, parent)
        {
        }

        public BTEntry()
        {
        }

        public override void Initialize(EditorWindow ewin, Rect rc, BaseControl parent = null)
        {
            base.Initialize(ewin, rc, parent);
            this.nodeCategory = "entry";
            this.nodeName = "入口";
        }

        public override void LoadConfig(JsonData cfg, BTNode parentNode = null)
        {
            base.LoadConfig(cfg, parentNode);
            if (cfg.Keys.Contains("agentcategory"))
            {
                this.AgentCategory = (string)cfg["agentcategory"];
            }
            else
            {
                this.AgentCategory = "Enemy";
            }
        }

        public void SetAngentCategory(string strCategory)
        {
            this.AgentCategory = strCategory;
        }

        protected override void CheckMouseHitArea(Vector2 pt)
        {
            this._mouseDownBody = true;
            this._mouseDownBar = false;
        }

        public override void SaveProject(JsonWriter w)
        {
            w.WriteObjectStart();

            w.WritePropertyName("kind");
            w.Write(this.nodeCategory);
				
            this.Copy2Out(w, "diyname", "string");
            this.Copy2Out(w, "weight", "string");
				
            this.SavePosition(w);

            this.SaveCompositeProj(w);

            w.WritePropertyName("agentcategory");
            w.Write(this.AgentCategory);

            w.WriteObjectEnd();
        }

        public override void SaveOutput(JsonWriter w)
        {
            if (this.nodeChildren.Count > 0)
            {
                this.nodeChildren[0].SaveOutput(w);
            }
        }
    }
}