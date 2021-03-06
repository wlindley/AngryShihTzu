﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AST
{
    public class ScriptableObjectCreationWindow : EditorWindow
    {
        private Type[] scriptableObjectTypes = new Type[0];
        private TypeFinder typeFinder = TypeFinder.GetInstance();
        private ScriptableObjectHelper helper = ScriptableObjectHelper.GetInstance();
        private Vector2 scrollPos = new Vector2();

        void Awake()
        {
            var assembly = Assembly.GetAssembly(typeof(AssemblyMarker));
            scriptableObjectTypes = typeFinder.FindTypesInAssemblyWhere(assembly, helper.IsTypeScriptableObject);
            titleContent = new GUIContent("Create Scriptable Object Asset");
        }

        void OnGUI()
        {
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            DrawTypeButtons();
            GUILayout.EndScrollView();
        }

        private void DrawTypeButtons()
        {
            foreach (var type in scriptableObjectTypes)
                if (GUILayout.Button(type.Name))
                    HandleButtonClicked(type);
        }

        private void HandleButtonClicked(Type type)
        {
            helper.CreateScriptableObjectInstance(type);
            Close();
        }

        [MenuItem("Assets/Create/ScriptableObject")]
        public static void ShowScriptableObjectCreator()
        {
            var window = ScriptableObject.CreateInstance<ScriptableObjectCreationWindow>();
            window.ShowUtility();
        }
    }
}
