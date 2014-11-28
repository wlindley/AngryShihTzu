using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.impl;

namespace AST.Menu
{
    public class MenuContextRoot : ContextView
    {
        void Awake()
        {
            context = new MenuContext(this);
        }
    }
}
