using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST.Main
{
    class MainStartupCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }

        public override void Execute()
        {
            Application.LoadLevelAdditive("Menu");
        }
    }
}