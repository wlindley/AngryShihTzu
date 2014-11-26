using strange.extensions.context.impl;
using strange.extensions.command.impl;
using strange.extensions.command.api;
using strange.extensions.signal.impl;
using UnityEngine;
using System;

namespace AST
{
    public abstract class BaseContext : MVCSContext
    {
        public BaseContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<LoadMenuSignal>().To<UnloadCurrentSceneCommand>().To<LoadMenuCommand>().InSequence();
            commandBinder.Bind<LoadGameSignal>().To<UnloadCurrentSceneCommand>().To<LoadGameCommand>().InSequence();
            commandBinder.Bind<PopSceneSignal>().To<UnloadCurrentSceneCommand>().To<PopSceneCommand>().InSequence();
        }

        public override void Launch()
        {
            base.Launch();
            var signal = getStartSignal();
            if (null == signal)
                throw new Exception("No start signal bound for context");
            signal.Dispatch();
        }

        protected abstract Signal getStartSignal();
    }
}
