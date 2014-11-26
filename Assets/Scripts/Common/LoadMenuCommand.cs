using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    class LoadMenuCommand : Command
    {
        [Inject]
        public SceneStack sceneStack { private get; set; }

        public override void Execute()
        {
            sceneStack.Push("Menu");
            Application.LoadLevelAdditive("Menu");
        }
    }
}