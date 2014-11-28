using strange.extensions.command.impl;

namespace AST.Game
{
    public class SaveScoreCommand : Command
    {
        [Inject]
        public GameModel gameModel { private get; set; }

        [Inject]
        public ScoreModel scoreModel { private get; set; }

        public override void Execute()
        {
            scoreModel.score = gameModel.score;
        }
    }
}
