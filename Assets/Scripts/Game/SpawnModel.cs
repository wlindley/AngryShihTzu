using System;

namespace AST.Game
{
    [Serializable]
    public class SpawnModel
    {
        [NonSerialized]
        public float spawnTimer;

        public float minSpawnDelay;
        public float maxSpawnDelay;
    }
}
