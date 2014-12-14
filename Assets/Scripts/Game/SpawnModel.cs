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

        public GameObject prefabToSpawn;

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

        [Header("Horizontal motion")]
        [Range(0f, 1f)]
        public float chanceOfZigZagging;
        public float minZigDelta;
        public float maxZigDelta;
        public float minZigFrequency;
        public float maxZigFrequency;
    }
}
