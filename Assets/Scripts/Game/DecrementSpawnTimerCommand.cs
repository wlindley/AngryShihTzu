using strange.extensions.command.impl;
using UnityEngine;

namespace AST.Game
{
    public class DecrementSpawnTimerCommand : Command
    {
        [Inject]
        public float timeDelta { private get; set; }

        [Inject]
        public SpawnModel model { private get; set; }

        [Inject]
        public SpawnSignal spawnSignal { private get; set; }

        public override void Execute()
        {
            model.spawnTimer -= timeDelta;
            if (model.spawnTimer <= 0f)
            {
                SpawnModel();
                model.spawnTimer += getRandomSpawnTime();
            }
        }

        private float getRandomSpawnTime()
        {
            return Random.Range(model.minSpawnDelay, model.maxSpawnDelay);
        }

        private void SpawnModel()
        {
            spawnSignal.Dispatch();
        }
    }
}
