using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    public class LoadGameCommand : Command
    {
        [Inject]
        public SceneStack sceneStack { private get; set; }

        public override void Execute()
        {
            sceneStack.Push(new SceneStackElement("Game", null));
            Application.LoadLevelAdditive("Game");
        }
    }
}
