using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace AST.Main
{
    public class MainContextRoot : ContextView
    {
        void Start()
        {
            context = new MainContext(this);
        }
    }
}