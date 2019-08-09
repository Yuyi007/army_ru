using UnityEngine;

 [ExecuteInEditMode]
public class PhysicsEntity : MonoBehaviour {

    public PhysicsEntityType _type;

    public PhysicsEntityType Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
            ChangeMaterials(value);
        }
    }

    //头部位置  --  判断car撞击位置，给予撞击伤害
    public GameObject goHead;

    //标识特定元素tid  -- 如barrier,需要对应barrier表的tid
    public string tid;

    [HideInInspector]
    public Material[] materials;
    MeshRenderer[] mr;

    // Use this for initialization
    void Awake () {
        materials = Resources.LoadAll<Material>("Materials");
    }

    void ChangeMaterials(PhysicsEntityType type)
    {
        mr = transform.GetComponentsInChildren<MeshRenderer>();
        int num = 0;

        num = (int)type;
        
        for (int i = 0; i < mr.Length; i++)
        {
            if (num < materials.Length)
                // mr[i].material = materials[0];
                mr[i].material = materials[num];
            // else
                
        }
    }
}
