using strange.extensions.command.impl;

namespace AST
{
    public class LoadGameOverCommand : Command
    {
        [Inject]
        public LevelLoader levelLoader { private get; set; }

        public override void Execute()
        {
            levelLoader.LoadLevel("GameOver");
        }
    }
}
