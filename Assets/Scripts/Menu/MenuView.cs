using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.Menu
{
    public class MenuView : View
    {
        public Signal OnStartClick = new Signal();

        public void HandleClick()
        {
            OnStartClick.Dispatch();
        }
    }
}
