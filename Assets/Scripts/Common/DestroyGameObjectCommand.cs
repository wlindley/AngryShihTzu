using strange.extensions.command.impl;
using UnityEngine;

namespace AST
{
    public class DestroyGameObjectCommand : Command
    {
        [Inject]
        public GameObject target { private get; set; }

        public override void Execute()
        {
            GameObject.Destroy(target);
        }
    }
}
