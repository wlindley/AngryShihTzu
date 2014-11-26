using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.Menu
{
    public class MenuContext : BaseContext
    {
        public MenuContext(MonoBehaviour contextView) : base(contextView) { }

        protected override void mapBindings()
        {
            base.mapBindings();
            commandBinder.Bind<MenuStartSignal>().To<MenuStartupCommand>();
        }

        protected override Signal getStartSignal()
        {
            return injectionBinder.GetInstance<MenuStartSignal>();
        }
    }
}
