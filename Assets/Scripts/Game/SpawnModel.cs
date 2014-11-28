using System;
using UnityEngine;

namespace AST.Game
{
    [Serializable]
    public class SpawnModel
    {
        [NonSerialized]
        public float spawnTimer = float.MaxValue;
        [NonSerialized]
        public float spawnDelayOffset = 0f;
        [NonSerialized]
        public float fallTimeOffset = 0f;

        [Header("Spawn timing")]
        public float initialMinSpawnDelay;
        public float initialMaxSpawnDelay;
        public float spawnDelayDecrementOnSuccess;
        public float minSpawnDelay;

        [Header("Spawn location")]
        public float spawnHeight;
        public float deathHeight;
        public float minSpawnX;
        public float maxSpawnX;

        [Header("Fall speed")]
        public float initialMinFallTime;
        public float initialMaxFallTime;
        public float fallTimeDecrementOnSpawn;
        public float minFallTime;
    }
}
