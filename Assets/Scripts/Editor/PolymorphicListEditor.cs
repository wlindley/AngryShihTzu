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
        private Dictionary<int, Rect> buttonRects = new Dictionary<int, Rect>();

        protected virtual void OnEnable()
        {
            var plist = target as PolymorphicList<T>;
            if (null != plist)
                list = plist.list;

            UpdateHiddenState();
        }

        public override void OnInspectorGUI()
        {
            DrawListHeader();
            DrawList();
            ClearQueuedRemovalIndeces();
            DrawListFooter();
        }

        private void DrawListHeader()
        {
            EditorGUILayout.LabelField("Size: " + list.Count);
            EditorGUI.indentLevel++;
        }

        private void UpdateHiddenState()
        {
            if (0 < list.Count && null != list[0])
                areHidden = HideFlags.HideInHierarchy == list[0].hideFlags;
        }

        private void DrawList()
        {
            for (var i = 0; i < list.Count; i++)
            {
                if (null == list[i])
                    continue;
                DrawListRow(i);
            }
        }

        private void DrawListRow(int i)
        {
            using (var row = new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MaxWidth(50));

                list[i] = EditorGUILayout.ObjectField(list[i], typeof(ScriptableObject), false) as T;

                DrawTypeChangeButton(i);
                DrawUpButton(i);
                DrawDownButton(i);
                DrawRemovalButton(i);
            }
        }

        private void DrawTypeChangeButton(int i)
        {
            if (GUILayout.Button("Type", EditorStyles.miniButtonLeft, GUILayout.MaxWidth(40)))
            {
                ScriptableObjectTypeSelectionDropDown.ShowDropDownForSubtype(
                    typeof(T), GetButtonRect(i), ReplaceInstanceFromSelectedType(i)
                );
            }
            CacheLastButtonRect(i);
        }

        private Rect GetButtonRect(int key)
        {
            Rect rect = GetDefaultRect();
            buttonRects.TryGetValue(key, out rect);
            return rect;
        }

        private static Rect GetDefaultRect()
        {
            return new Rect(Input.mousePosition, new Vector2(80, 0));
        }

        private void CacheLastButtonRect(int key)
        {
            var rect = GUILayoutUtility.GetLastRect();
            if (rect.x != 0f && rect.y != 0f)
            {
                var topLeft = EditorGUIUtility.GUIToScreenPoint(rect.position);
                buttonRects[key] = new Rect(topLeft, new Vector2(rect.width, 0));
            }
        }

        private void DrawUpButton(int i)
        {
            if (GUILayout.Button("˄", EditorStyles.miniButtonMid, GUILayout.MaxWidth(20)))
                Swap(i, i - 1);
        }

        private void DrawDownButton(int i)
        {
            if (GUILayout.Button("˅", EditorStyles.miniButtonMid, GUILayout.MaxWidth(20)))
                Swap(i, i + 1);
        }

        private void DrawRemovalButton(int i)
        {
            if (GUILayout.Button("x", EditorStyles.miniButtonRight, GUILayout.MaxWidth(20)))
                toRemove.Add(i);
        }

        private void Swap(int src, int dst)
        {
            if (0 > src || 0 > dst || list.Count <= src || list.Count <= dst)
                return;
            var tmp = list[dst];
            list[dst] = list[src];
            list[src] = tmp;
        }

        private void ClearQueuedRemovalIndeces()
        {
            for (var i = toRemove.Count - 1; i >= 0; i--)
                RemoveFromList(toRemove[i]);
            CleanUpAfterRemoval();
        }

        private void RemoveFromList(int removalIndex)
        {
            var so = list[removalIndex];
            list.RemoveAt(removalIndex);
            if (!list.Contains(so))
                ScriptableObject.DestroyImmediate(so, true);
        }

        private void CleanUpAfterRemoval()
        {
            if (0 < toRemove.Count)
            {
                RefreshAsset(target as ScriptableObject);
                toRemove.Clear();
            }
        }

        private void DrawListFooter()
        {
            EditorGUI.indentLevel--;
            using (var row = new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Hide", EditorStyles.miniButtonLeft, GUILayout.MaxWidth(80)))
                    HandleHideClicked();
                if (GUILayout.Button("Show", EditorStyles.miniButtonRight, GUILayout.MaxWidth(80)))
                    HandleShowClicked();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("+", EditorStyles.miniButton, GUILayout.MaxWidth(80)))
                {
                    ScriptableObjectTypeSelectionDropDown.ShowDropDownForSubtype(
                        typeof(T), GetButtonRect(-1), CreateInstanceFromSelectedType
                    );
                }
                CacheLastButtonRect(-1);
            }
        }

        private void HandleHideClicked()
        {
            areHidden = true;
            foreach (var item in list)
            {
                item.hideFlags = HideFlags.HideInHierarchy;
                RefreshAsset(item);
            }
        }

        private void HandleShowClicked()
        {
            areHidden = false;
            foreach (var item in list)
            {
                item.hideFlags = HideFlags.None;
                RefreshAsset(item);
            }
        }

        private Action<Type> ReplaceInstanceFromSelectedType(int i)
        {
            return (type) =>
            {
                ScriptableObject.DestroyImmediate(list[i], true);

                var so = CreateAsset(type);
                list[i] = so;
                RefreshAsset(so);
            };
        }

        private void CreateInstanceFromSelectedType(Type type)
        {
            var so = CreateAsset(type);
            list.Add(so);
            RefreshAsset(so);
        }

        private T CreateAsset(Type type)
        {
            var so = ScriptableObject.CreateInstance(type) as T;
            so.name = type.Name;
            if (areHidden)
                so.hideFlags = HideFlags.HideInHierarchy;
            AssetDatabase.AddObjectToAsset(so, target);
            return so;
        }

        private void RefreshAsset(ScriptableObject so)
        {
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(so));
        }
    }
}
