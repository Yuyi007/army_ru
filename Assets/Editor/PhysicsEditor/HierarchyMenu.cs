using UnityEngine;
using UnityEditor;
using System.Collections;

public class HierarchyMenu
{
    static int selectionID;

    [MenuItem("GameObject/Physics Scene", priority = 49)]
    private static void CreatePhysicsScene()
    {
        PhysicsEntityManager.Instance.CreatePhysicsScene();
    }

    [MenuItem("GameObject/Entities/Physics Entity/Physics Entity")]
    private static void CreatePhysicsEntity()
    {
        PhysicsEntityManager.Instance.CreatePhysicEntity();
    }

    [MenuItem("GameObject/Entities/Physics Entity Sons/Cube")]
    static void CreateCube()
    {
        GameObject parent = EditorUtility.InstanceIDToObject(selectionID) as GameObject;
        PhysicsEntityManager.Instance.CreateSubItem(PhysicsType.Cube, parent);
    }

    [MenuItem("GameObject/Entities/Physics Entity Sons/Sphere")]
    static void CreateSphere()
    {
        GameObject parent = EditorUtility.InstanceIDToObject(selectionID) as GameObject;
        PhysicsEntityManager.Instance.CreateSubItem(PhysicsType.Sphere, parent);
    }

    [MenuItem("Tools/Save PhysicsScene",priority = 120)]
    static void SavePhysicsScene()
    {
        DataProxy.Instance.SaveScene();
    }

    [MenuItem("Tools/Open PhysicsScene",priority = 120)]
    static void SelectPhysicsScene()
    {
        string path = EditorUtility.OpenFilePanel("请选择文件", DataProxy.Instance.ScenePath, "json");
        DataProxy.Instance.SelectScene(path);
    }

    [MenuItem("Tools/Save PhysicsEntity",priority = 132)]
    static void SavePhysicsEntity()
    {
        DataProxy.Instance.SavePhysicEntity(Selection.gameObjects);
    }

    [MenuItem("Tools/Open PhysicsEntity",priority = 132)]
    static void SelectPhysicEntity()
    {
        string path = EditorUtility.OpenFilePanel("请选择文件", DataProxy.Instance.EntityPath, "json");
        if (path != string.Empty)
        {
            EntityData entityData=DataProxy.Instance.Read<EntityData>(path);

            PhysicsEntityManager.Instance.CreatePhysicEntity(entityData);
        }
    }

    [MenuItem("Tools/Add DrawGizmos Script", priority = 144)]
    static void AddDrawGizmosScript()
    {
        DataProxy.Instance.AddDrawGizmosScript();
    }

    [InitializeOnLoadMethod]
    static void StartInitializeOnLoadMethod()
    {
        EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
    }

    static void OnHierarchyGUI(int instanceID, Rect selectionRect)
    {
        if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
            && Event.current.button == 1 && Event.current.type <= EventType.MouseUp)
        {
            GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;


            Vector2 mousePosition = Event.current.mousePosition;
            switch(selectedGameObject.tag)
            {
                case "PhysicsScene":
                    EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "GameObject/Entities/Physics Entity", null);
                    Event.current.Use();
                    break;

                case "PhysicsEntity":
                    selectionID = instanceID;
                    EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "GameObject/Entities/Physics Entity Sons", null);
                    Event.current.Use();
                    break;

                case "Cube":

                    //EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), null, null);
                    Event.current.Use();
                    break;
                case "Sphere":

                    //EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), null, null);
                    Event.current.Use();
                    break;
                default:
                    Debug.Log("could not found the tag:" + selectedGameObject.tag);
                    break;
            }
        }
    }


}
