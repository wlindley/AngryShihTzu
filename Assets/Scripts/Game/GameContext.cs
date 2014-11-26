using strange.extensions.context.impl;
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

            commandBinder.Bind<GameStartSignal>().To<GameStartupCommand>();
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<GameStartSignal>();
        }
    }
}
