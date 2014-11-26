﻿using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace AST.Game
{
    public class GameView : View
    {
        public Signal OnEndGameClicked = new Signal();

        public void HandleEndGameClicked()
        {
            OnEndGameClicked.Dispatch();
        }
    }
}