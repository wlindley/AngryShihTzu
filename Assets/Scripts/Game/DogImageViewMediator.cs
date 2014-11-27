using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class DogImageViewMediator : Mediator
    {
        [Inject]
        public DogImageView view { private get; set; }

        [Inject]
        public TargetHitSignal hitSignal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnClicked.AddListener(HandleClicked);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnClicked.RemoveListener(HandleClicked);
        }

        private void HandleClicked()
        {
            hitSignal.Dispatch(view.gameObject);
        }
    }
}
