using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SLua;

namespace Game
{
    [CustomLuaClassAttribute]
    public class ToggleButton: MonoBehaviour
    {
        public ToggleBtnGroup group = null;

        public GameObject normal = null;
        public GameObject check = null;
	
        private bool isOn = false;

        public void OnEnable()
        {
            if (group == null)
            {
                return;
            }

            group.RegistToggleBtn(this);
        }

        public void OnDisable()
        {
            if (group == null)
            {
                return;
            }

            group.UnregistToggleBtn(this);
        }

        public void DisplayCheck(bool isOn)
        {
            normal.SetActive(!isOn);
            check.SetActive(isOn);
        }

        public void SetOn(bool on)
        {
            if (on)
                group.SelectToggleBtn(this);

            DisplayCheck(on);
            this.isOn = on;
        }

        public void SetParent(Transform parent)
        {
            Transform contariner = gameObject.transform.parent;
            contariner.SetParent(parent, true);
        }
    }
}
