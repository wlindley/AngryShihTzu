using strange.extensions.mediation.impl;

namespace AST.Game
{
    public class GameViewMediator : Mediator
    {
        [Inject]
        public GameView view { private get; set; }

        [Inject]
        public PopSceneSignal signal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();

            view.OnEndGameClicked.AddListener(HandleEndGameClicked);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            view.OnEndGameClicked.RemoveListener(HandleEndGameClicked);
        }

        private void HandleEndGameClicked()
        {
            signal.Dispatch();
        }
    }
}
