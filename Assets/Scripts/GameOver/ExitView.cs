using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.GameOver
{
    public class ExitView : View
    {
        public void HandleClicked()
        {
            Application.Quit();
        }
    }
}
