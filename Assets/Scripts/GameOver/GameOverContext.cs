using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.GameOver
{
    public class GameOverContext : BaseContext
    {
        public GameOverContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<GameOverStartSignal>();

            mediationBinder.Bind<GameOverView>().To<GameOverViewMediator>();

#if UNITY_WEBPLAYER || UNITY_EDITOR
            mediationBinder.Bind<ExitView>().To<DeletingMediator>();
#endif
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<GameOverStartSignal>();
        }
    }
}
