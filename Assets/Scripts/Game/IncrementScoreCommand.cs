using strange.extensions.command.impl;

namespace AST.Game
{
    public class IncrementScoreCommand : Command
    {
        [Inject]
        public GameModel gameModel { private get; set; }

        [Inject]
        public ScoreUpdatedSignal scoreSignal { private get; set; }

        public override void Execute()
        {
            gameModel.score++;
            scoreSignal.Dispatch(gameModel.score);
        }
    }
}
