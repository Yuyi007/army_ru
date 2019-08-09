using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PhysicsEntity))]
public class serializedEntitiyInspector : Editor 
{
    PhysicsEntityType initType;
    PhysicsEntity physicsEntity;

    private SerializedObject serializedEntitiy;
    private SerializedProperty type, goHead, tid;
    void OnEnable()
    {
        Debug.Log("serializedEntitiyInspector OnEnable");
        serializedEntitiy = new SerializedObject(target);

        physicsEntity = target as PhysicsEntity;

        type = serializedEntitiy.FindProperty("_type");
        initType = (PhysicsEntityType)type.enumValueIndex;

        goHead = serializedEntitiy.FindProperty("goHead");
        tid = serializedEntitiy.FindProperty("tid");
    }
    public override void OnInspectorGUI()
    {
        serializedEntitiy.Update();
        EditorGUILayout.PropertyField(type);

        PhysicsEntityType t = (PhysicsEntityType)type.enumValueIndex;

        if(t != initType)
        {
            initType = t;
            physicsEntity.Type = t;
        }

        if(t == PhysicsEntityType.Barrier)
        {
            //Debug.Log("serializedEntitiyInspector type:" + type.enumValueIndex);
            EditorGUILayout.PropertyField(tid);
        }
        else if(t == PhysicsEntityType.Car)
        {
            EditorGUILayout.PropertyField(goHead);
        }

        serializedEntitiy.ApplyModifiedProperties();
    }
}
