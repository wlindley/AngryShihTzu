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

            injectionBinder.Bind<SpawnModel>().ToSingleton();
            injectionBinder.Bind<GameModel>().ToSingleton();

            commandBinder.Bind<GameStartSignal>().To<GameStartupCommand>();
            commandBinder.Bind<GameUpdateSignal>().To<DecrementSpawnTimerCommand>();
            commandBinder.Bind<SpawnSignal>().To<SpawnCommand>();
            commandBinder.Bind<ReparentSpawnedObjectSignal>();
            commandBinder.Bind<TargetHitSignal>().To<DecrementSpawnDelayOffsetCommand>().To<IncrementScoreCommand>().To<DestroyGameObjectCommand>().InSequence();
            commandBinder.Bind<TargetEscapedSignal>().To<SaveScoreCommand>().To<GameOverCommand>().InSequence();
            commandBinder.Bind<ScoreUpdatedSignal>();

            mediationBinder.Bind<GameView>().To<GameViewMediator>();
            mediationBinder.Bind<SpawnConfigView>().To<SpawnConfigViewMediator>();
            mediationBinder.Bind<DogImageView>().To<DogImageViewMediator>();
            mediationBinder.Bind<ScoreView>().To<ScoreViewMediator>();
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<GameStartSignal>();
        }
    }
}
