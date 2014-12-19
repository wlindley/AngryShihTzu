using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

namespace AST.GameOver
{
    public class LinkButtonView : View
    {
        public Text buttonLabel;

        public Signal OnClicked = new Signal();

        public void SetLabel(string text)
        {
            buttonLabel.text = text;
        }

        public void HandleClick()
        {
            OnClicked.Dispatch();
        }
    }
}
