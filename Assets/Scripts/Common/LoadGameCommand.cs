using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    public class LoadGameCommand : Command
    {
        [Inject]
        public LevelLoader levelLoader { private get; set; }

        public override void Execute()
        {
            levelLoader.LoadLevel("Game");
        }
    }
}
