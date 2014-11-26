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
            sceneStack.Push(new SceneStackElement("Menu", null));
            Application.LoadLevelAdditive("Menu");
        }
    }
}