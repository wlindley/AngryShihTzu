using UnityEngine;
using System;

namespace AST
{
    public class PolymorphicListEditorAttribute : PropertyAttribute
    {
        private Type baseType;
        public Type BaseType { get { return baseType; } }

        public PolymorphicListEditorAttribute(Type baseType)
        {
            this.baseType = baseType;
            if (!baseType.IsSubclassOf(typeof(ScriptableObject)))
                throw new ArgumentException("Specified base type must be a subclass of ScriptableObject");
        }
    }
}
