using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class MainContext : MVCSContext {
	public MainContext(MonoBehaviour contextView) : base(contextView) {}

	protected override void addCoreComponents()
	{
		base.addCoreComponents();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}

	public override void Launch ()
	{
		base.Launch();
		var signal = injectionBinder.GetInstance<MainStartSignal>();
		signal.Dispatch();
	}

	protected override void mapBindings ()
	{
		base.mapBindings();
		commandBinder.Bind<MainStartSignal>().To<MainStartupCommand>();
	}
}