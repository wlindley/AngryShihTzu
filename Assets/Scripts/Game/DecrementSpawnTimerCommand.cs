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
            model.SpawnTimer -= timeDelta;
            if (model.SpawnTimer <= 0f)
            {
                SpawnModel();
                model.SpawnTimer += model.SpawnDelay;
            }
        }

        private void SpawnModel()
        {
            spawnSignal.Dispatch();
        }
    }
}
