using strange.extensions.command.impl;

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
                model.spawnTimer += model.spawnDelay;
            }
        }

        private void SpawnModel()
        {
            spawnSignal.Dispatch();
        }
    }
}
