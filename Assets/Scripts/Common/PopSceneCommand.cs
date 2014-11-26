using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    public class PopSceneCommand : Command
    {
        [Inject]
        public SceneStack sceneStack { private get; set; }

        public override void Execute()
        {
            sceneStack.Pop();
            Application.LoadLevelAdditive(sceneStack.Peek());
        }
    }
}
