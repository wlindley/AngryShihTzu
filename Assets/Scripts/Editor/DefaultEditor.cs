using UnityEditor;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace AST
{
    [CustomEditor(typeof(DefaultAsset))]
    public class DefaultEditor : Editor
    {
        List<AssetInspector> inspectors = new List<AssetInspector>();

        void OnEnable()
        {
            var asset = target as DefaultAsset;
            inspectors.Clear();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
                SearchAssemblyForObjectInspectors(asset, assembly);

            foreach (var inspector in inspectors)
                inspector.OnEnable(asset);
        }

        private void SearchAssemblyForObjectInspectors(DefaultAsset asset, Assembly assembly)
        {
            var types = assembly.GetTypes().Where(IsAssetInspector);
            foreach (var type in types)
                CreateAndAddInspector(asset, type);
        }

        private bool IsAssetInspector(Type type)
        {
            return type.GetInterfaces().Contains(typeof(AssetInspector));
        }

        private void CreateAndAddInspector(DefaultAsset asset, Type type)
        {
            var inspector = Activator.CreateInstance(type) as AssetInspector;
            if (inspector.IsValid(asset))
                inspectors.Add(inspector);
        }

        public override void OnInspectorGUI()
        {
            if (0 < inspectors.Count)
                DrawValidInspectors();
            else
                DrawDefaultInspector();
        }

        private void DrawValidInspectors()
        {
            var asset = target as DefaultAsset;
            foreach (var inspector in inspectors)
                inspector.OnInspectorGUI(asset);
        }
    }
}