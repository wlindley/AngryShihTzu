using strange.extensions.command.impl;

namespace AST.Game
{
    public class DecrementSpawnDelayOffsetCommand : Command
    {
        [Inject]
        public SpawnModel model { private get; set; }

        public override void Execute()
        {
            model.spawnSuccessOffset -= model.spawnDelayDecrementOnSuccess;
        }
    }
}
