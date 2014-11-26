using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST.Game
{
    public class GameStartupCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { private get; set; }

        public override void Execute()
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.parent = contextView.transform;
            LeanTween.move(obj, new Vector3(10, 10, obj.transform.position.z), 5f);
            LeanTween.rotateLocal(obj, new Vector3(180f, 270f, 90f), 1f).setLoopPingPong();
        }
    }
}
