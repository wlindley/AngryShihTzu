using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

namespace AST.GameOver
{
    public class GameOverView : View
    {
        public Text scoreLabel;

        public Signal OnContinueClicked = new Signal();

        [Inject]
        public ScoreModel scoreModel { private get; set; }

        public void HandleContinueClicked()
        {
            OnContinueClicked.Dispatch();
        }

        protected override void Start()
        {
            base.Start();
            scoreLabel.text = "Score: " + scoreModel.score;
        }
    }
}
