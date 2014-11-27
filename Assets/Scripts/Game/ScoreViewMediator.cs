using strange.extensions.mediation.impl;

namespace AST.Game
{
    public class ScoreViewMediator : Mediator
    {
        [Inject]
        public ScoreView view { private get; set; }

        [Inject]
        public ScoreUpdatedSignal scoreSignal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            scoreSignal.AddListener(HandleScoreUpdated);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            scoreSignal.RemoveListener(HandleScoreUpdated);
        }

        private void HandleScoreUpdated(int score)
        {
            view.SetScore(score);
        }
    }
}
