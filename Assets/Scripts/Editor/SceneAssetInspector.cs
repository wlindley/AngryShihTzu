using UnityEngine;
using UnityEditor;
using System;

namespace AST
{
    public class SceneAssetInspector : AssetInspector
    {
        public void OnEnable(DefaultAsset target)
        {
            
        }

        public void OnInspectorGUI(DefaultAsset target)
        {
            EditorGUILayout.LabelField(target.name);
        }

        public bool IsValid(DefaultAsset target)
        {
            return AssetDatabase.GetAssetPath(target).EndsWith(".unity");
        }
    }
}
