using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

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
