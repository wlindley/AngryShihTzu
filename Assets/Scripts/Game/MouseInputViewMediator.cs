using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class MouseInputViewMediator : Mediator
    {
        [Inject]
        public MouseInputView view { private get; set; }

        [Inject]
        public TargetHitSignal hitSignal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnMouseInput.AddListener(HandleMouseInput);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnMouseInput.RemoveListener(HandleMouseInput);
        }

        private void HandleMouseInput(GameObject obj)
        {
            hitSignal.Dispatch(obj);
        }
    }
}
