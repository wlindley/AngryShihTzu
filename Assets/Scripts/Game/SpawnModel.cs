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
        public float spawnHeight;
        public float deathHeight;
        public float minSpawnX;
        public float maxSpawnX;
        public float minFallTime;
        public float maxFallTime;
    }
}
