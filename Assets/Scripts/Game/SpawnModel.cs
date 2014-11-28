using System;

namespace AST.Game
{
    [Serializable]
    public class SpawnModel
    {
        [NonSerialized]
        public float spawnTimer = float.MaxValue;
        [NonSerialized]
        public float spawnSuccessOffset = 0f;

        public float initialMinSpawnDelay;
        public float initialMaxSpawnDelay;
        public float spawnDelayDecrementOnSuccess;
        public float minSpawnDelay;
        public float spawnHeight;
        public float deathHeight;
        public float minSpawnX;
        public float maxSpawnX;
        public float minFallTime;
        public float maxFallTime;
    }
}
