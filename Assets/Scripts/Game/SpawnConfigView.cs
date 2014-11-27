using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace AST.Game
{
    public class SpawnConfigView : View
    {
        public SpawnModel spawnConfig = new SpawnModel();

        public Signal OnUpdated = new Signal();

        void Update()
        {
            OnUpdated.Dispatch();
        }
    }
}
