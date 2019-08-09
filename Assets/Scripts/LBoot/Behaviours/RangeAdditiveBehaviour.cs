using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;

namespace Game
{
    [CustomLuaClassAttribute]
    public class RangeAdditiveBehaviour : MonoBehaviour
    {
        public GameObject lightObject = null;
        [HideInInspector]
        public Transform lightTransform = null;
        [HideInInspector]
        public Material mat = null;

        int matType = 0;
        Vector3 offsetVec3 = Vector3.zero;
        // Use this for initialization
        void Start()
        {

        }

        public void SetFakeLightObject(GameObject go)
        {
            lightObject = go;
            ResetTransform();
            ResetMaterial();

        }

        public void SetFakeLightObject(GameObject go, Vector3 offset)
        {
            SetFakeLightObject(go);
            offsetVec3 = new Vector3(offset.x,offset.y,offset.z);
        }

        public void ResetTransform()
        {
            lightTransform = lightObject.GetComponent<Transform>();
        }

        public void ResetMaterial()
        {
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            int len = mr.materials.Length;
            for (int i=0; i<len; i++)
            {
                Material material = mr.materials[i]; 
                if(material.shader.name == "Scene/RangeAdditive")
                {
                    matType = 0;
                    mat = material;
                    return;
                }
                if(material.shader.name == "Scene/runway")
                {
                    matType = 1;
                    mat = material;
                    return;
                }
            }
           //  MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
           // mat = renderer.sharedMaterial;
        }

        // Update is called once per frame
        void Update()
        {
            if (lightObject == null)
                return;

            if (lightTransform == null)
                ResetTransform();

            if (lightTransform == null)
                return;

            if (mat == null)
                ResetMaterial();

            //Debug.Log(lightTransform.position);
            if (matType == 0)
            {
                mat.SetFloat("_LightX", lightTransform.position.x);
                mat.SetFloat("_LightY", lightTransform.position.y);
                mat.SetFloat("_LightZ", lightTransform.position.z);
            }
            else if(matType == 1)
            {
                Matrix4x4 matrix = lightTransform.localToWorldMatrix;
                Vector3 wpos = matrix.MultiplyPoint(offsetVec3);
                mat.SetFloat("_LightX", wpos.x);
                mat.SetFloat("_LightY", wpos.y);
                mat.SetFloat("_LightZ", wpos.z);
            }
        }
    }
}
