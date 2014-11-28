using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace AST.Game
{
    public class GameStartupCommand : Command
    {
        [Inject]
        public SpawnModel spawnModel { private get; set; }

        public override void Execute()
        {
            spawnModel.spawnTimer = 1f;
            spawnModel.spawnDelayOffset = 0f;
            spawnModel.fallTimeOffset = 0f;
        }
    }
}
