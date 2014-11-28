using strange.extensions.mediation.impl;

namespace AST.GameOver
{
    public class GameOverViewMediator : Mediator
    {
        [Inject]
        public GameOverView view { private get; set; }

        [Inject]
        public PopSceneSignal signal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnContinueClicked.AddListener(HandleContinueClicked);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnContinueClicked.RemoveListener(HandleContinueClicked);
        }

        private void HandleContinueClicked()
        {
            signal.Dispatch();
        }
    }
}
