using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace AST
{
    public class PolymorphicListEditor<T> : Editor where T : ScriptableObject
    {
        private List<T> list = new List<T>();
        private List<int> toRemove = new List<int>();
        private ScriptableObjectHelper helper = ScriptableObjectHelper.GetInstance();
        private TypeFinder finder = TypeFinder.GetInstance();
        private Type[] validTypes = new Type[0];
        private string[] validTypeNames = new string[0];
        private int selectionIndex = 0;
        private bool areHidden = true;

        protected virtual void OnEnable()
        {
            var plist = target as PolymorphicList<T>;
            if (null != plist)
                list = plist.list;

            if (0 < list.Count && null != list[0])
                areHidden = HideFlags.HideInHierarchy == list[0].hideFlags;

            validTypes = finder.FindTypesWhere((type) => type.IsSubclassOf(typeof(T)) && !type.IsAbstract);
            validTypeNames = validTypes.Select<Type, string>((type) => type.Name).ToArray();
        }

        public override void OnInspectorGUI()
        {
            toRemove.Clear();
            for (var i = 0; i < list.Count; i++)
            {
                if (null == list[i])
                    continue;
                using (var row = new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField(i.ToString(), GUILayout.MaxWidth(50));
                    list[i] = EditorGUILayout.ObjectField(list[i], typeof(ScriptableObject), false) as T;
                    if (GUILayout.Button("Type", GUILayout.MaxWidth(40)))
                    {
                    }
                    if (GUILayout.Button("X", GUILayout.MaxWidth(20)))
                    {
                        toRemove.Add(i);
                        if (list.Count((item) => item == list[i]) <= 1)
                        {
                            ScriptableObject.DestroyImmediate(list[i], true);
                            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(target));
                        }
                    }
                }
            }
            for (var i = toRemove.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(toRemove[i]);
            }

            using (var row = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Hide"))
                {
                    areHidden = true;
                    foreach (var item in list)
                    {
                        item.hideFlags = HideFlags.HideInHierarchy;
                        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(item));
                    }
                }
                if (GUILayout.Button("Show"))
                {
                    areHidden = false;
                    foreach (var item in list)
                    {
                        item.hideFlags = HideFlags.None;
                        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(item));
                    }
                }
                selectionIndex = EditorGUILayout.Popup(selectionIndex, validTypeNames);
                if (GUILayout.Button("+"))
                {
                    var so = ScriptableObject.CreateInstance(validTypes[selectionIndex]) as T;
                    so.name = validTypes[selectionIndex].Name;
                    if (areHidden)
                        so.hideFlags = HideFlags.HideInHierarchy;
                    AssetDatabase.AddObjectToAsset(so, target);
                    AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(so));
                    list.Add(so);
                }
            }
        }
    }
}
