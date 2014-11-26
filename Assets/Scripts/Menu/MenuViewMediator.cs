using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Menu
{
    public class MenuViewMediator : Mediator
    {
        [Inject]
        public MenuView view { private get; set; }

        [Inject]
        public LoadGameSignal loadGameSignal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnStartClick.AddListener(HandleStartClicked);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnStartClick.RemoveListener(HandleStartClicked);
        }

        private void HandleStartClicked()
        {
            loadGameSignal.Dispatch();
        }
    }
}
