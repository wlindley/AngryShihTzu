using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    class LoadMenuCommand : Command
    {
        public override void Execute()
        {
            Application.LoadLevelAdditive("Menu");
        }
    }
}