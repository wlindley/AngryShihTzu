using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class GameViewMediator : Mediator
    {
        [Inject]
        public GameView view { private get; set; }

        [Inject]
        public ReparentSpawnedObjectSignal reparentSignal { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            reparentSignal.AddListener(HandleReparentSpawnedObject);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            reparentSignal.RemoveListener(HandleReparentSpawnedObject);
        }

        private void HandleReparentSpawnedObject(GameObject obj)
        {
            if (null == obj.transform.parent)
                obj.transform.SetParent(view.transform, false);
        }
    }
}
