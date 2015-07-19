using UnityEditor;

namespace AST
{
    public interface AssetInspector
    {
        bool IsValid(DefaultAsset target);
        void OnEnable(DefaultAsset target);
        void OnInspectorGUI(DefaultAsset target);
    }
}
