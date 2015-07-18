using UnityEditor;

namespace Assets.Scripts.Editor
{
    class SaveMenu
    {
        [MenuItem("File/Save Project and Scene %&s")]
        public static void SaveEverything()
        {
            EditorApplication.SaveAssets();
            EditorApplication.SaveScene();
        }
    }
}
