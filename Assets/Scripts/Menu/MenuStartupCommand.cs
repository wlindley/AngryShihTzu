using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST.Menu
{
    class MenuStartupCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { private get; set; }

        [Inject]
        public SceneStack sceneStack { private get; set; }

        public override void Execute()
        {
            sceneStack.Push(new SceneStackElement("Menu", contextView));
        }
    }
}
