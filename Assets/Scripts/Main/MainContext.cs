using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

namespace AST.Main
{
    public class MainContext : BaseContext
    {
        public MainContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<MainStartSignal>().To<MainStartupCommand>();
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<MainStartSignal>();
        }
    }
}