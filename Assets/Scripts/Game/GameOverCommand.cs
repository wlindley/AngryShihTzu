using strange.extensions.command.impl;

namespace AST.Game
{
    public class GameOverCommand : Command
    {
        [Inject]
        public SpawnModel spawnModel { private get; set; }

        [Inject]
        public LoadGameOverSignal continueSignal { private get; set; }

        public override void Execute()
        {
            LeanTween.pauseAll();
            spawnModel.spawnTimer = float.MaxValue;
            continueSignal.Dispatch();
        }
    }
}
