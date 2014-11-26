using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST.Game
{
    public class GameStartupCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { private get; set; }

        [Inject]
        public SceneStack sceneStack { private get; set; }

        public override void Execute()
        {
            
        }
    }
}
