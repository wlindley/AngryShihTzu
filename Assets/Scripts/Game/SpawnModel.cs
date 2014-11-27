using System;

namespace AST.Game
{
    [Serializable]
    public class SpawnModel
    {
        [NonSerialized]
        public float SpawnTimer;

        public float SpawnDelay;
    }
}
