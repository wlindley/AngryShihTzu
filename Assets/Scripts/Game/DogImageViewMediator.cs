using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class DogImageViewMediator : Mediator
    {
        [Inject]
        public DogImageView view { private get; set; }

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
            GameObject.Destroy(view.gameObject);
        }
    }
}
