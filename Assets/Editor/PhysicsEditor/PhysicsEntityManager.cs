using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class PhysicsEntityManager
{
    static PhysicsEntityManager instance;

    PhysicsScene entityScene = null;

    private PhysicsEntityManager()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(PhysicsType.PhysicsScene.ToString());
        if (objects.Length > 0)
        {
            EntityScene = objects[0].GetComponent<PhysicsScene>();
            //Selection.objects = new GameObject[] { objects[0] };
        }
    }

    public static PhysicsEntityManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PhysicsEntityManager();
            }
            return instance;
        }
    }

    public PhysicsScene EntityScene
    {
        get
        {
            return entityScene;
        }

        set
        {
            entityScene = value;
        }
    }

    /// <summary>
    /// 创建空scene
    /// </summary>
    public void CreatePhysicsScene()
    {
        if (exitPhysicsScene())
            return;

        GameObject go = new GameObject("physics_scene");
        go.tag = PhysicsType.PhysicsScene.ToString();

        EntityScene = go.AddComponent<PhysicsScene>();

        Selection.objects = new GameObject[] { go };
    }

    /// <summary>
    /// 通过JSON数据创建场景
    /// </summary>
    public void CreatePhysicsScene(SceneData data)
    {
        if (exitPhysicsScene())
            return;

        GameObject go = new GameObject(data.name);
        go.tag = PhysicsType.PhysicsScene.ToString();

        EntityScene = go.AddComponent<PhysicsScene>();

        Selection.objects = new GameObject[] { go };

        foreach (var e in data.entities)
        {
            GameObject obj = CreatePhysicEntity(e);
            obj.transform.SetParent(go.transform);
        }
    }

    //初次打开场景时，hierarchyWindowChanged执行顺序无法保证；
    //每次创建时，检测是否存在；
    public bool exitPhysicsScene()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(PhysicsType.PhysicsScene.ToString());
        if(objects.Length==0)
        {
            return false;
        }
        else
        {
            EditorUtility.DisplayDialog("提示",
                            "已经存在 PhysicsScene",
                            "ok");
            Selection.objects = new GameObject[]{objects[0]};
            entityScene = objects[0].GetComponent<PhysicsScene>();
            return true;
        }
    }

    //初始化时，从hierarchy窗口中读取entity实例；
    public void AddFromHierarchy(GameObject[] objects)
    {
        //GameObject[] objects= GameObject.FindGameObjectsWithTag(PhysicsType.PhysicsScene.ToString());

        Debug.Log("init:" + objects.Length);
        //EntityList.AddRange(objects);
        if(objects.Length==1)
        {
            EntityScene = objects[0].GetComponent<PhysicsScene>();
            Debug.Log("init:" + EntityScene.ToString());
        }
        else if(objects.Length>1)
        {
            EditorUtility.DisplayDialog("提示",
                            "场景中存在多个 PhysicsScene",
                            "ok");
        }
    }



    /// <summary>
    /// 创建空entity
    /// </summary>
    /// <returns>The physic entity.</returns>
    public GameObject CreatePhysicEntity()
    {
        string name="physics_entity";
        if (entityScene.PhysicsEntities.Count!=0)
        {
            name = name + entityScene.PhysicsEntities.Count.ToString();
        }
        GameObject obj= CreatePhysicsGameObject(name, PhysicsEntityType.None);

        Selection.objects = new GameObject[] { obj };

        return obj;
    }

    /// <summary>
    /// 通过 JSON数据创建
    /// </summary>
    /// <returns>The physic entity.</returns>
    /// <param name="data">Data.</param>
    public GameObject CreatePhysicEntity(EntityData data)
    {
        GameObject obj = CreatePhysicsGameObject(data.name, data.entityType);

        if (obj == null)
            return null;

        PhysicsEntity pe =  obj.GetComponent<PhysicsEntity>();
           
        int index = 0;
        obj.transform.localPosition = new Vector3((float)data.posX,
                                    (float)data.posY,
                                    (float)data.posZ);

        obj.transform.localRotation = new Quaternion((float)data.quaternionX,
                                               (float)data.quaternionY,
                                               (float)data.quaternionZ,
                                               (float)data.quaternionW);

        obj.transform.localScale = new Vector3((float)data.length,
                                            (float)data.height,
                                            (float)data.width);
        GameObject goHead = null;
        if(data.cubeData!=null)
        {
            foreach(var sub in data.cubeData)
            {
                
                GameObject go= CreateSubItem(PhysicsType.Cube, obj);

                go.transform.localPosition = new Vector3((float)sub.posX, 
                                                    (float)sub.posY, 
                                                    (float)sub.posZ);
                
                go.transform.localRotation = new Quaternion((float)sub.quaternionX,
                                                       (float)sub.quaternionY,
                                                       (float)sub.quaternionZ,
                                                       (float)sub.quaternionW);

                go.transform.localScale = new Vector3((float)sub.length,
                                                    (float)sub.height,
                                                    (float)sub.width);

                if(data.headType == HeadType.cube && index == data.headIndex)
                {
                    goHead = go;
                }
                index++;
            }
        }

        index = 0;
        if(data.sphereData!=null)
        {
            foreach(var sub in data.sphereData)
            {
                GameObject go = CreateSubItem(PhysicsType.Sphere, obj);

                go.transform.localPosition = new Vector3((float)sub.posX,
                                    (float)sub.posY,
                                    (float)sub.posZ);

                go.transform.localScale = new Vector3((float)sub.radius*2,
                                                      (float)sub.radius*2,
                                                      (float)sub.radius*2);

                if (data.headType == HeadType.sphere && index == data.headIndex)
                {
                    goHead = go;
                }
                index++;
            }
        }

        pe.Type = data.entityType;
        pe.goHead = goHead;
        pe.tid = data.tid;
        return obj;
    }

    /// <summary>
    /// 通过复制或者activity创建
    /// </summary>
    /// <param name="objects">Objects.</param>
    public void AddPhysicEntity(GameObject[] objects)
    {
        if(EntityScene == null)
            return;
        List<GameObject> diffList = objects.Except(EntityScene.PhysicsEntities).ToList();
        if(diffList.Count>0)
        {
            Debug.Log("add:" + diffList.Count);
            foreach(var go in diffList)
            {
                EntityScene.PhysicsEntities.Add(go);
            }
        }
    }

    public void RemovePhysicEntity(GameObject[] objects)
    {
        if (EntityScene == null)
            return;
        List<GameObject> list = EntityScene.PhysicsEntities;
        list.Add(EntityScene.gameObject);
        
        List<GameObject> diffList=list.Except(objects).ToList();

        if(diffList.Count>0)
        {
            Debug.Log("removed:" + diffList.Count);
        }

        foreach (var go in diffList)
        {
            //删除了场景
            if(go==entityScene.gameObject)
            {
                EntityScene = null;
                return;
            }
            
            EntityScene.PhysicsEntities.Remove(go);
        }

    }
    //创建实例子节点
    public GameObject CreateSubItem(PhysicsType type,int instanceID)
    {
        GameObject go=null;

        GameObject parent= GetEntityByID(instanceID);
        if (parent != null)
        {
            go= CreateSubItem(type, parent);
        }

        return go;
    }

    public GameObject CreateSubItem(PhysicsType type,GameObject parent)
    {
        GameObject go;
        switch (type)
        {
            case PhysicsType.Cube:
                go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.tag = type.ToString();
                break;
            case PhysicsType.Sphere:
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.tag = type.ToString();
                break;
            default:
                Debug.LogError("can not find the type:" + type);
                return null;
        }
        go.transform.SetParent(parent.transform);
        return go;
    }


    GameObject GetEntityByID(int instanceID)
    {
        foreach (var v in entityScene.PhysicsEntities)
        {
            if (v.GetInstanceID() == instanceID)
                return v;
        }
            //找不到对应的ID的gameobject
        EditorUtility.DisplayDialog("提示",
                                    "the item that be selected is not 'PhysicsEntity'",
                                    "ok");
        return null;

    }

    public GameObject CreatePhysicsGameObject(string name,PhysicsEntityType type)
    {
        GameObject obj = CreateWithSelection();

        if (obj == null)
            return null;

        obj.name = name;
        obj.tag = PhysicsType.PhysicsEntity.ToString();

        PhysicsEntity entityBhv = obj.AddComponent<PhysicsEntity>();
        entityBhv.Type = type;

        return obj;
    }

    public GameObject CreateWithSelection()
    {
        GameObject[] gos = Selection.gameObjects;
        if (gos.Length == 1)
        {
            if (gos[0].tag == "PhysicsScene")
            {
                GameObject obj = new GameObject();
                obj.transform.SetParent(gos[0].transform);

                PhysicsScene physicsScene = gos[0].GetComponent<PhysicsScene>();
                physicsScene.PhysicsEntities.Add(obj);

                return obj;
            }
            else
            {
                EditorUtility.DisplayDialog("提示",
                                            "请选中一个 PhysicScene 物体",
                                            "ok");
            }
        }
        else if(gos.Length>1)
        {
            EditorUtility.DisplayDialog("提示",
                                        "选中物体太多",
                                        "ok");
        }
        else{
            EditorUtility.DisplayDialog("提示",
                                        "请先选中一个 PhysicScene 物体",
                                        "ok");
        }

        return null;
    }

}
