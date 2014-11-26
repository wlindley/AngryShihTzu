using strange.extensions.command.impl;
using UnityEngine;

namespace AST.Game
{
    public class SpawnCommand : Command
    {
        [Inject]
        public ReparentSpawnedObjectSignal reparentSignal { private get; set; }

        public override void Execute()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/DogImage");
            var obj = GameObject.Instantiate(prefab) as GameObject;
            reparentSignal.Dispatch(obj);
        }
    }
}
