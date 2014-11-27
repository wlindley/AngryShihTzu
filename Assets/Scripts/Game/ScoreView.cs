using strange.extensions.mediation.impl;
using UnityEngine.UI;
using UnityEngine;

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
            LeanTween.textColor(scoreLabel.gameObject, Color.yellow, .15f).setLoopPingPong().setLoopCount(4);
        }
    }
}
