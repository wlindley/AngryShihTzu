using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Menu
{
    public class MenuViewMediator : Mediator
    {
        [Inject]
        public MenuView view { private get; set; }

        [Inject]
        public LoadGameSignal signal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnStartClicked.AddListener(HandleStartClicked);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnStartClicked.RemoveListener(HandleStartClicked);
        }

        private void HandleStartClicked()
        {
            signal.Dispatch();
        }
    }
}
