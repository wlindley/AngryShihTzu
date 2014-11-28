using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace AST.GameOver
{
    public class GameOverView : View
    {
        public Signal OnContinueClicked = new Signal();

        public void HandleContinueClicked()
        {
            OnContinueClicked.Dispatch();
        }

        protected override void Start()
        {
            base.Start();
        }
    }
}
