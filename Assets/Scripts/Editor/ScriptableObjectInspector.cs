using UnityEngine;
using UnityEditor;
using System;

namespace AST
{
    [CustomEditor(typeof(MonoScript))]
    public class ScriptableObjectInspector : Editor
    {
        private ScriptableObjectHelper helper = ScriptableObjectHelper.GetInstance();

        public override void OnInspectorGUI()
        {
            var type = (target as MonoScript).GetClass();
            if (!helper.IsTypeScriptableObject(type))
                DrawDefaultInspector();
            else if (GUILayout.Button("Create Instance"))
                helper.CreateScriptableObjectInstance(type);
        }
    }
}
