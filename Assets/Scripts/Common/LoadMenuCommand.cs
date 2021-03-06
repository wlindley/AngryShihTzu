using strange.extensions.command.impl;

namespace AST
{
    class LoadMenuCommand : Command
    {
        [Inject]
        public LevelLoader levelLoader { private get; set; }

        public override void Execute()
        {
            levelLoader.LoadLevel("Menu");
        }
    }
}