using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;

public class DataProxy{

    private string entityPath;

    static DataProxy instance;
    private string scenePath;

    private DataProxy () 
    {
        scenePath = Application.dataPath + "/Editor/PhysicsEditor/PhysicsData/scenes/";
        entityPath = Application.dataPath + "/Editor/PhysicsEditor/PhysicsData/entities/";
    }
	
    public static DataProxy Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new DataProxy();
            }
            return instance;
        }
    }

    public string ScenePath
    {
        get
        {
            return scenePath;
        }
    }

    public string EntityPath
    {
        get
        {
            return entityPath;
        }

    }

    public void SaveScene()
    {
        if(PhysicsEntityManager.Instance.EntityScene==null)
        {
            EditorUtility.DisplayDialog("提示",
                                        "保存失败！\n" +
                                        "请先创建 PhysicsScene ！",
                                        "ok");
            return;
        }

        SceneData sceneData = new SceneData();
        sceneData.name = PhysicsEntityManager.Instance.EntityScene.name;

        GameObject[] goes = GameObject.FindGameObjectsWithTag(PhysicsType.PhysicsEntity.ToString());
        goes=goes.OrderBy(g => g.transform.GetSiblingIndex()).ToArray();

        //foreach (var go in PhysicsEntityManager.Instance.EntityScene.PhysicsEntities)
        foreach (var go in goes)
        {
            EntityData entityData = new EntityData();
            PhysicsEntity entityBhv = go.GetComponent<PhysicsEntity>();

            entityData.name = go.name;
            entityData.entityType = entityBhv.Type;
            entityData.tid = entityBhv.tid;
  
            entityData.posX = Round(go.transform.localPosition.x);
            entityData.posY = Round(go.transform.localPosition.y);
            entityData.posZ = Round(go.transform.localPosition.z);
            entityData.quaternionX = Round(go.transform.localRotation.x);
            entityData.quaternionY = Round(go.transform.localRotation.y);
            entityData.quaternionZ = Round(go.transform.localRotation.z);
            entityData.quaternionW = Round(go.transform.localRotation.w);
            entityData.length = Round(go.transform.localScale.x);
            entityData.height = Round(go.transform.localScale.y);
            entityData.width = Round(go.transform.localScale.z);

            foreach (var trans in go.GetComponentsInChildren<Transform>())
            {
                switch (trans.gameObject.tag)
                {
                    case "Cube":
                        AddPrimitiveData(entityData, PhysicsType.Cube, trans.gameObject);
                        break;
                    case "Sphere":
                        AddPrimitiveData(entityData, PhysicsType.Sphere, trans.gameObject);
                        break;
                        //default:
                        //Debug.LogError("cannot found the type:"+trans.gameObject.tag);
                        //break;
                }
            }
            sceneData.entities.Add(entityData);
        }
        string str = JsonUtility.ToJson(sceneData, true);
        File.WriteAllText(scenePath + sceneData.name + ".json", str);

        string msg=string.Format("PhysicScene 保存成功!");
        UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
    }

    public void SelectScene(string path)
    {
        //string path = EditorUtility.OpenFilePanel("请选择文件", Application.dataPath + "/Editor/PhysicsEditor/PhysicsData/", "json");
        if (path != string.Empty)
        {
            SceneData sceneData = Read<SceneData>(path);

            PhysicsEntityManager.Instance.CreatePhysicsScene(sceneData);
        }
    }

    public void SavePhysicEntity(GameObject[] objects)
    {
        int saveCount = 0;
        foreach (var go in objects)
        {
            PhysicsEntity entityBhv = go.GetComponent<PhysicsEntity>();
            EntityData entityData = new EntityData();
            entityData.name = go.name;
            entityData.entityType = entityBhv.Type;
            entityData.tid = entityBhv.tid;

            entityData.posX = 0;
            entityData.posY = 0;
            entityData.posZ = 0;
            entityData.quaternionX = Round(go.transform.localRotation.x);
            entityData.quaternionY = Round(go.transform.localRotation.y);
            entityData.quaternionZ = Round(go.transform.localRotation.z);
            entityData.quaternionW = Round(go.transform.localRotation.w);
            entityData.length = Round(go.transform.localScale.x);
            entityData.height = Round(go.transform.localScale.y);
            entityData.width = Round(go.transform.localScale.z);


            int cubeIndex = 0;
            int sphereIndex = 0;
            entityData.headIndex = 0;
            entityData.headType = HeadType.sphere;

            var trans = go.GetComponentInChildren<Transform>();
            foreach (Transform tran in trans)
            {
                
                switch (tran.gameObject.tag)
                {
                    case "Cube":
                        AddPrimitiveData(entityData, PhysicsType.Cube, tran.gameObject);
                        if (entityBhv.goHead == tran.gameObject)
                        {
                            entityData.headType = HeadType.cube;
                            entityData.headIndex = cubeIndex;
                        }
                        cubeIndex++;
                        break;
                    case "Sphere":
                        AddPrimitiveData(entityData, PhysicsType.Sphere, tran.gameObject);
                        if (entityBhv.goHead == tran.gameObject)
                        {
                            entityData.headType = HeadType.sphere;
                            entityData.headIndex = sphereIndex;
                        }
                        sphereIndex++;
                        break;
                        //default:
                        //Debug.LogError("cannot found the type:"+trans.gameObject.tag);
                        //break;
                }
            }

            string str = JsonUtility.ToJson(entityData, true);
            File.WriteAllText(entityPath + go.name + ".json", str);
            saveCount++;
        }

        string msg;
        if(saveCount>0)
            msg = string.Format("成功保存「{0}」个文件",saveCount);
        else
        {
            msg = "保存失败！\n没有选中任何 PhysicsEntity!";
        }
        UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
    }

    void AddPrimitiveData(EntityData entity,PhysicsType type,GameObject go)
    {
        switch(type)
        {
            case PhysicsType.Cube:
                CubeData cube = new CubeData();
                cube.posX = Round( go.transform.localPosition.x);
                cube.posY =Round(go.transform.localPosition.y);
                cube.posZ =Round(go.transform.localPosition.z);

                cube.quaternionX =Round(go.transform.localRotation.x);
                cube.quaternionY =Round(go.transform.localRotation.y);
                cube.quaternionZ = Round(go.transform.localRotation.z);
                cube.quaternionW = Round(go.transform.localRotation.w);

                cube.length =  Round(go.transform.localScale.x);
                cube.height = Round(go.transform.localScale.y);
                cube.width =Round(go.transform.localScale.z);

                entity.cubeData.Add(cube);
                break;
            case PhysicsType.Sphere:
                SphereData sphere = new SphereData();
                sphere.posX = Round(go.transform.localPosition.x);
                sphere.posY = Round(go.transform.localPosition.y);
                sphere.posZ =Round(go.transform.localPosition.z);

                sphere.radius = Round(go.transform.localScale.x/2);

                entity.sphereData.Add(sphere);
                break;
        }
    }
    protected double Round(double value)
    {
        return Math.Round(value, 4);
        //return value;
    }
 

    string ReadString(string path)
    {
        if(!File.Exists(path))
        {
            string msg="could not found the file at path:" + path;
            UnityEditor.EditorUtility.DisplayDialog("提示", msg, "ok");
            return null;
        }

        StreamReader sr = new StreamReader(path);

        if(sr==null)
        {
            return null;
        }

        string json = sr.ReadToEnd();

        return json;
    }
    public T  Read<T>(string path)
    {
        string json = ReadString(path);
        if(json!=null)
        {
            return JsonUtility.FromJson<T>(json);
        }
        return default(T);
    }

    public void AddDrawGizmosScript()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("DrawGizmos");

        if (cubes.Length == 0)
        {
            EditorUtility.DisplayDialog("提示",
                                            "添加失败！\n" +
                                            "请先创建带 DrawGizmos 标签的物体！",
                                            "ok");
            return;
        }
        else
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                if (cubes[i].GetComponent<DrawGizmosTest>() != null)
                {
                    EditorUtility.DisplayDialog("提示",
                                            "添加失败！\n" +
                                            "已经存在脚本 DrawGizmosTest！",
                                            "ok");
                    return;
                }
            }
            cubes[0].AddComponent<DrawGizmosTest>();
        }
    }
}
