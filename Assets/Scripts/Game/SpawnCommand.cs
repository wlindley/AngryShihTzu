using strange.extensions.command.impl;
using UnityEngine;

namespace AST.Game
{
    public class SpawnCommand : Command
    {
        public override void Execute()
        {
            Debug.Log("Spawning");
        }
    }
}
