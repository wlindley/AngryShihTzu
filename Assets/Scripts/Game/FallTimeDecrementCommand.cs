using strange.extensions.command.impl;

namespace AST.Game
{
    public class FallTimeDecrementCommand : Command
    {
        [Inject]
        public SpawnModel model { private get; set; }

        public override void Execute()
        {
            model.fallTimeOffset -= model.fallTimeDecrementOnSpawn;
        }
    }
}
