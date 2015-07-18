using System;
using UnityEngine;
using UnityEditor;

namespace AST
{
    public class ScriptableObjectHelper
    {
        public bool IsTypeScriptableObject(Type type)
        {
            return null != type
                && !type.IsAbstract
                && type.IsSubclassOf(typeof(ScriptableObject))
                && !type.IsSubclassOf(typeof(Editor))
                && !type.IsSubclassOf(typeof(EditorWindow));
        }

        public void CreateScriptableObjectInstance(Type type, string path = null)
        {
            if (!IsTypeScriptableObject(type))
            {
                Debug.LogError("Tried to create instance of " + type.FullName + ", but it is not a ScriptableObject");
                return;
            }

            var asset = ScriptableObject.CreateInstance(type);
            path = ValidatePath(type, path);
            AssetDatabase.CreateAsset(asset, path);
            EditorGUIUtility.PingObject(asset);
        }

        private string ValidatePath(Type type, string path)
        {
            if (null == path)
                path = "Assets/" + type.Name + ".asset";
            path = AssetDatabase.GenerateUniqueAssetPath(path);
            return path;
        }

        private ScriptableObjectHelper() { }

        public static ScriptableObjectHelper GetInstance()
        {
            return new ScriptableObjectHelper();
        }
    }
}
