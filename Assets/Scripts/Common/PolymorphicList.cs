using System;
using System.Collections.Generic;
using UnityEngine;

namespace AST
{
    public abstract class PolymorphicList<T> : ScriptableObject
    {
        public List<T> list = new List<T>();
    }
}
