using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class GameUpdateView : View
    {
        [Inject]
        public GameUpdateSignal updateSignal { private get; set; }

        void Update()
        {
            updateSignal.Dispatch(Time.deltaTime);
        }
    }
}
