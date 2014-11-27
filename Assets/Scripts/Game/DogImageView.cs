using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace AST.Game
{
    public class DogImageView : View
    {
        public Signal OnClicked = new Signal();

        public void HandleClicked()
        {
            OnClicked.Dispatch();
        }
    }
}
