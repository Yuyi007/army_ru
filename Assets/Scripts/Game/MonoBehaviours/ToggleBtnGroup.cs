using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SLua;

namespace Game
{
    [CustomLuaClassAttribute]
    public class ToggleBtnGroup : MonoBehaviour
    {
        [HideInInspector]
        public ToggleButton curbtn = null;

        private List<ToggleButton> buttons = new List<ToggleButton>();


        private bool _added(ToggleButton btn)
        {
            var length = buttons.Count;
            for (var i = 0; i < length; i++)
            {
                var bt = buttons[i];
                if (bt.Equals(btn))
                {
                    return true;
                }
            }
            return false;
        }

        public void RegistToggleBtn(ToggleButton btn)
        {
            if (!this._added(btn))
            {
                buttons.Add(btn);
            }
        }

        public void UnregistToggleBtn(ToggleButton btn)
        {
            buttons.Remove(btn);
        }

        public void SelectToggleBtn(ToggleButton btn)
        {
            if (btn != null)
            {
                _bring2Front(btn);
            }

            foreach (ToggleButton bt in buttons)
            {
                if (btn == null || !bt.Equals(btn))
                    bt.SetOn(false);
            }
            curbtn = btn;
        }

        private void _bring2Front(ToggleButton btn)
        {
            btn.transform.parent.SetAsLastSibling();
        }
    }
}
