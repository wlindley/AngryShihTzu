using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace AST.Game
{
    public class ScoreView : View
    {
        private Text scoreLabel;

        protected override void Start()
        {
            base.Start();
            scoreLabel = GetComponent<Text>();
        }

        public void SetScore(int score)
        {
            scoreLabel.text = "Score: " + score;
        }
    }
}
