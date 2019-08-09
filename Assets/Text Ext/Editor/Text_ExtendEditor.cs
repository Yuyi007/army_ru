using UnityEngine;
using UnityEngine.UI;

namespace UnityEditor.UI
{
    [CustomEditor(typeof(Text_Extend), true)]
    [CanEditMultipleObjects]
    public class Text_ExtendEditor : TextEditor
    {
        SerializedProperty m_OriginText;
        SerializedProperty linkObject;

        protected override void OnEnable()
        {
            base.OnEnable();
            m_OriginText = serializedObject.FindProperty("m_OriginText");
            linkObject = serializedObject.FindProperty("linkObject");
            
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(m_OriginText);
            EditorGUILayout.PropertyField(linkObject);
            serializedObject.ApplyModifiedProperties();

            base.OnInspectorGUI();



        }
    }
}