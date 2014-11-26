using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST
{
    public class UnloadCurrentSceneCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { private get; set; }

        public override void Execute()
        {
            GameObject.Destroy(contextView);
        }
    }
}
