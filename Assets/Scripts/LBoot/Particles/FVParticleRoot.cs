using UnityEngine;
using System.Collections;
using SLua;
using System.Collections.Generic;


namespace LBoot
{
    [CustomLuaClassAttribute]
    public class FVParticleRoot : MonoBehaviour
    {
#if UNITY_EDITOR
        [SLua.DoNotToLua]
        public bool isTesting = false;
        [SLua.DoNotToLua]
        public Vector3 testRotation = Vector3.zero;
        [SLua.DoNotToLua]
        public Vector3 testScale = Vector3.one;
#endif
        public bool noFlip = false;


        private GameObject goParticles = null;

        private Vector3 rotation = Vector3.zero;
        private Quaternion quat = Quaternion.Euler(Vector3.zero);
        private Vector3 scale = Vector3.one;
        private Matrix4x4 transformMatrix;
        private MaterialPropertyBlock propertyBlock = null;

        public MaterialPropertyBlock PropertyBlock
        {
            get
            {
                if (propertyBlock == null)
                {
                    propertyBlock = new MaterialPropertyBlock();
                }
                return propertyBlock;
            }
        }

        public Matrix4x4 TransformMatrix
        {
            get
            {
                return transformMatrix;
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                // Only GC alloc at change
                if (rotation != value)
                {
                    Quat = Quaternion.Euler(value);
                }
                rotation = value;
            }
        }

        public Quaternion Quat
        {
            get
            {
                return quat;
            }
            set
            {
                if (quat != value)
                {
                    quat = value;
                    // foreach is ok on arrays
                    foreach (var go in Others)
                    {
                        go.transform.localRotation = quat;
                    }

                    updatePropertyBlock();
                }
            }
        }

        public Vector3 Scale
        {
            get
            {
                return scale;
            }
            set
            {
                if (noFlip)
                {
                    value.x = Mathf.Abs(value.x);
                }
                if (scale != value)
                {
                    scale = value;
                    // foreach is ok on arrays
                    foreach (var go in Others)
                    {
                        go.transform.localScale = scale;
                    }

                    ScaleRatio = scale.x;
                    updatePropertyBlock();
                }

            }
        }

        private float scaleRatio = 1f;

        public float ScaleRatio
        {
            get
            {
                return scaleRatio;
            }
            set
            {
                if (scaleRatio != value)
                {
                    scaleRatio = value;
                    // foreach is ok on arrays
                    foreach (var go in Others)
                    {
                        ParticleScaler.ScaleSystem(go, scaleRatio);
                    }
                }
            }
        }

        private GameObject[] others;

        public GameObject[] Others
        {
            get
            {
                if (others == null)
                {
                    var list = new List<GameObject>();
                    for (var i = transform.childCount - 1; i >= 0; i--)
                    {
                        var child = transform.GetChild(i);
                        if (child.name != "particles")
                        {
                            list.Add(child.gameObject);
                        }
                        else
                        {
                            goParticles = child.gameObject;
                        }
                    }
                    others = list.ToArray();
                }

                return others;
            }
        }

        private FVParticleScaling[] scalingComps;

        public FVParticleScaling[] ScalingComps
        {
            get
            {
                if (scalingComps == null)
                {
                    scalingComps = gameObject.GetComponentsInChildren<FVParticleScaling>(true);
                }
                return scalingComps;
            }
        }

        private bool hasScalingComps = false;

        void OnDestroy()
        {
            this.scalingComps = null;
            this.others = null;
            this.propertyBlock = null;
            this.goParticles = null;
        }


        void Start()
        {
            #if UNITY_EDITOR
            isTesting = false;
            #endif

            if (goParticles == null)
            {
                // init the others
                var o = Others;
            }

            // ensure ScalingComps is created
            var scs = this.ScalingComps;
            if (scs.Length > 0)
            {
                hasScalingComps = true;
                updatePropertyBlock();
                for (var i = 0; i < scs.Length; i++)
                {
                    var sc = scs[i];
                    sc.Init(this);
                }
            }
            else if (LBootApp.Running)
            {
                this.enabled = false;
            }

            // ensure propertyBlock is created
        }

        void updatePropertyBlock()
        {
            if (!hasScalingComps)
            {
                return;
            }

            transformMatrix = Matrix4x4.TRS(Vector3.zero, this.quat, this.scale);

            var pb = this.PropertyBlock;
            pb.SetMatrix("_RootRSMat", transformMatrix);
            // var cameraToWorldMatrix = Camera.main.cameraToWorldMatrix;
//            pb.SetVector("_Matrix1", transformMatrix.GetRow(0));
//            pb.SetVector("_Matrix2", transformMatrix.GetRow(1));
//            pb.SetVector("_Matrix3", transformMatrix.GetRow(2));
//            pb.SetVector("_Matrix4", transformMatrix.GetRow(3));
        }

        // Update is called once per frame
        [SLua.DoNotToLua]
        void Update()
        {
#if UNITY_EDITOR
            if (isTesting && !LBoot.LBootApp.Running)
            {
                Quat = Quaternion.Euler(testRotation);
                Scale = testScale;
            }
#endif
            if (!hasScalingComps)
                return;

            if (transform.hasChanged)
            {
                Vector4 rootPos = transform.position;
                rootPos.w = 1.0f;

                var pb = this.PropertyBlock;
                pb.SetVector("_RootPos", rootPos);
                transform.hasChanged = false;
            }

            foreach (var sc in scalingComps)
            {
                sc.RefreshPositionAndScale();
            }


        }
    }
}