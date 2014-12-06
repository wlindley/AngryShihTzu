using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.GameOver
{
    public class DeletingMediator : Mediator
    {
        [Inject]
        public ExitView View { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            GameObject.Destroy(View.gameObject);
        }
    }
}
