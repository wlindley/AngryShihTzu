﻿using strange.extensions.context.impl;
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

            commandBinder.Bind<LoadGameSignal>().To<LoadGameCommand>();
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
