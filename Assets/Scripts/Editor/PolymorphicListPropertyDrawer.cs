using UnityEngine;
using UnityEditor;

namespace AST
{
   // [CustomPropertyDrawer(typeof(PolymorphicListEditorAttribute))]
    public class PolymorphicListPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Debug.Log(property);
        }
    }
}
