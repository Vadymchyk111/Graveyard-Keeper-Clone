using UnityEditor;
using UnityEngine;
using Values.ScriptableObjects;

namespace Editor
{
    [CustomEditor(typeof(ScriptableObjectInt))]
    public class ScriptableObjectIntEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            ScriptableObjectInt scriptableObjectInt = (ScriptableObjectInt)target;

            if (!GUILayout.Button("Clear"))
            {
                return;
            }
            
            scriptableObjectInt.Value.ChangeValue(0);
            EditorUtility.SetDirty(scriptableObjectInt);
        }
    }
}