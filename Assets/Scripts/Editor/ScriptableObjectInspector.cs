using UnityEngine;
using UnityEditor;

namespace AST
{
    [CustomEditor(typeof(ScriptableObject), true)]
    public class ScriptableObjectInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawBackButton();
            DrawNameField();
            DrawDefaultInspector();
        }

        private void DrawNameField()
        {
            target.name = EditorGUILayout.TextField("Name", target.name);
        }

        private void DrawBackButton()
        {
            if (IsSubAsset() && GUILayout.Button("◄ Back to Parent"))
                AssetDatabase.OpenAsset(GetParent());
        }

        private bool IsSubAsset()
        {
            return GetParent() != target;
        }

        private ScriptableObject GetParent()
        {
            return AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GetAssetPath(target));
        }
    }
}
