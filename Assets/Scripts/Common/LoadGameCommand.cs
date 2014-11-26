using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    public class LoadGameCommand : Command
    {
        public override void Execute()
        {
            Application.LoadLevelAdditive("Game");
        }
    }
}
