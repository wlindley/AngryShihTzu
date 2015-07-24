using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AST
{
    public class ScriptableObjectTypeSelectionDropDown : EditorWindow
    {
        private TypeFinder typeFinder = TypeFinder.GetInstance();
        private Vector2 scrollPos = new Vector2();

        private Type rootType = typeof(ScriptableObject);
        private Action<Type> selectionCallback;

        private const float RowWidth = 150f;
        private const float RowHeight = 22f;

        void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            DrawSubtypeButtons(GetSubtypes());
            DrawCancelButton();

            GUILayout.EndScrollView();
        }

        private float GetHeight()
        {
            var numSubTypes = Math.Min(GetSubtypes().Length + 1, 10);
            return numSubTypes * RowHeight;
        }

        private Type[] GetSubtypes()
        {
            var assembly = Assembly.GetAssembly(typeof(AssemblyMarker));
            return typeFinder.FindTypesInAssemblyWhere(assembly,
                (type) => !type.IsAbstract && (type.IsSubclassOf(rootType) || type == rootType)
            );
        }

        private void DrawSubtypeButtons(Type[] subtypes)
        {
            foreach (var type in subtypes)
                if (GUILayout.Button(type.Name))
                    HandleButtonClicked(type);
        }

        private void DrawCancelButton()
        {
            if (GUILayout.Button("Cancel"))
                Close();
        }

        private void HandleButtonClicked(Type type)
        {
            selectionCallback(type);
            Close();
        }

        public static void ShowDropDownForSubtype(Type type, Rect area, Action<Type> selectionCallback)
        {
            var window = ScriptableObject.CreateInstance<ScriptableObjectTypeSelectionDropDown>() as ScriptableObjectTypeSelectionDropDown;
            window.rootType = type;
            window.selectionCallback = selectionCallback;
            window.ShowAsDropDown(area, new Vector2(RowWidth, window.GetHeight()));
        }
    }
}
