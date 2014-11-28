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
                SpawnObject();
                ResetTimer();
            }
        }

        private void ResetTimer()
        {
            model.spawnTimer += Mathf.Max(
                Random.Range(model.initialMinSpawnDelay, model.initialMaxSpawnDelay) + model.spawnSuccessOffset,
                model.minSpawnDelay);
            Debug.Log("Next spawn time: " + model.spawnTimer);
        }

        private void SpawnObject()
        {
            spawnSignal.Dispatch();
        }
    }
}
