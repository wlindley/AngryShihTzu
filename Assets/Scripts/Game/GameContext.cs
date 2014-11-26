﻿using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.Game
{
    public class GameContext : BaseContext
    {
        public GameContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<SpawnModel>().ToSingleton();

            commandBinder.Bind<GameStartSignal>().To<GameStartupCommand>();
            commandBinder.Bind<GameUpdateSignal>().To<DecrementSpawnTimerCommand>();

            mediationBinder.Bind<GameView>().To<GameViewMediator>();
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<GameStartSignal>();
        }
    }
}
