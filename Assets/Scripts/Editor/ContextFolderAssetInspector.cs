using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using strange.extensions.context.impl;

namespace AST
{
    public class ContextFolderAssetInspector : AssetInspector
    {
        private string report = "";

        public void OnEnable(DefaultAsset target)
        {
            report = "";
            var paths = GetPathsForAssetsInDirectory(target);
            foreach (var path in paths)
                CheckAndProcessContextPath(path);
        }

        public void OnInspectorGUI(DefaultAsset target)
        {
            EditorGUILayout.TextArea(report);
        }

        public bool IsValid(DefaultAsset target)
        {
            return AssetDatabase.IsValidFolder(AssetDatabase.GetAssetPath(target))
                && 0 < GetPathsForAssetsInDirectory(target).Count(IsContext);
        }

        private IEnumerable<string> GetPathsForAssetsInDirectory(DefaultAsset target)
        {
            return AssetDatabase.FindAssets("", new string[] { AssetDatabase.GetAssetPath(target) })
                .Select<string, string>(AssetDatabase.GUIDToAssetPath)
                .Where((path) => Path.GetDirectoryName(path) == AssetDatabase.GetAssetPath(target));
        }

        private bool IsContext(string path)
        {
            return Path.GetFileNameWithoutExtension(path).EndsWith("Context");
        }

        private void CheckAndProcessContextPath(string path)
        {
            if (IsContext(path))
            {
                var lines = File.ReadAllLines(path);
                GenerateSignalReport(lines);
                GenerateViewReport(lines);
            }
        }

        private void GenerateSignalReport(string[] lines)
        {
            report += "Signals:\n";
            foreach (var line in lines)
                report += GenerateReportLineForBinderType("commandBinder", line);
        }

        private void GenerateViewReport(string[] lines)
        {
            report += "Views:\n";
            foreach (var line in lines)
                report += GenerateReportLineForBinderType("mediationBinder", line);
        }

        private string GenerateReportLineForBinderType(string binderName, string line)
        {
            line = line.Trim();
            if (line.StartsWith(binderName))
            {
                line = line.Replace(binderName + ".Bind<", "");
                var i = line.IndexOf(">");
                line = line.Substring(0, i);
                return "    " + line + "\n";
            }
            return "";
        }
    }
}
