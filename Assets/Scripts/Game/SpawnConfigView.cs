using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace AST.Game
{
    public class SpawnConfigView : View
    {
        public float SpawnDelay = 5f;

        public Signal OnUpdated = new Signal();

        void Update()
        {
            OnUpdated.Dispatch();
        }
    }
}
