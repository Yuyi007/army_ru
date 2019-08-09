using UnityEngine;
using System.Collections;

namespace LBoot
{
    public class AnimationEfxCtrl : MonoBehaviour
    {

        public GameObject effectPrefab = null;
        public bool triggerEffect = false;
        private bool preTrigger = false;
		
        // Use this for initialization
        void Start()
        {
            if (!effectPrefab)
            {
                return;
            }

        }
		
        // Update is called once per frame
        void Update()
        {
            UpdateAutoDestroyEffect();
            UpdateTriggerEffect();
        }

        void UpdateTriggerEffect()
        {
            if (!effectPrefab)
            {
                return;
            }
            if (triggerEffect && !preTrigger)
            {
                string path = FindPrefabPath(effectPrefab);
                var go = BundleHelper.LoadAndCreate(path, -1);
                go.transform.SetParent(gameObject.transform, false);
            }
            preTrigger = triggerEffect;
        }

        void UpdateAutoDestroyEffect()
        {
            foreach (Transform child in transform)
            {
                if (isParticleDone(child.gameObject))
                {
                    Destroy(child.gameObject);
                }
            }
        }

        bool isParticleDone(GameObject go)
        {
            bool alive = false;
            foreach (Transform child in go.transform)
            {
                ParticleSystem[] systems = child.gameObject.GetComponents<ParticleSystem>();
                foreach (ParticleSystem ps in systems)
                {
                    alive = alive || ps.IsAlive();
                    if (alive)
                    {
                        break;
                    }
                }

                if (child.gameObject)
                {
                    alive = alive || !isParticleDone(child.gameObject);
                }

                if (alive)
                {
                    return false;
                }
            }
            return true;
        }

        void ForceDestroyAllEffects()
        {

        }

        string FindPrefabPath(GameObject prefab)
        {
            return "prefab/misc/" + prefab.name;
        }
    }

}




