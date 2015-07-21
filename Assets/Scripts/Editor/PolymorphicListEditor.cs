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
        private bool areHidden = true;

        protected virtual void OnEnable()
        {
            var plist = target as PolymorphicList<T>;
            if (null != plist)
                list = plist.list;

            if (0 < list.Count && null != list[0])
                areHidden = HideFlags.HideInHierarchy == list[0].hideFlags;
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
                        ScriptableObjectTypeSelectionDropDown.ShowDropDownForSubtype(typeof(T), GUILayoutUtility.GetLastRect(), ReplaceInstanceFromSelectedType(i));
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
                if (GUILayout.Button("+"))
                {
                    ScriptableObjectTypeSelectionDropDown.ShowDropDownForSubtype(typeof(T), GUILayoutUtility.GetLastRect(), CreateInstanceFromSelectedType);
                }
            }
        }

        private Action<Type> ReplaceInstanceFromSelectedType(int i)
        {
            return (type) =>
            {
                ScriptableObject.DestroyImmediate(list[i], true);
                var so = ScriptableObject.CreateInstance(type) as T;
                so.name = type.Name;
                if (areHidden)
                    so.hideFlags = HideFlags.HideInHierarchy;
                AssetDatabase.AddObjectToAsset(so, target);
                list[i] = so;
                AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(so));
            };
        }

        private void CreateInstanceFromSelectedType(Type type)
        {
            var so = ScriptableObject.CreateInstance(type) as T;
            so.name = type.Name;
            if (areHidden)
                so.hideFlags = HideFlags.HideInHierarchy;
            AssetDatabase.AddObjectToAsset(so, target);
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(so));
            list.Add(so);
        }
    }
}
