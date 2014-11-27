using strange.extensions.mediation.impl;

namespace AST.Game
{
    public class SpawnConfigViewMediator : Mediator
    {
        [Inject]
        public SpawnConfigView view { private get; set; }

        [Inject]
        public SpawnModel spawnModel { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnUpdated.AddListener(HandleViewUpdated);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnUpdated.RemoveListener(HandleViewUpdated);
        }

        private void HandleViewUpdated()
        {
            var modelType = spawnModel.GetType();
            foreach (var f in modelType.GetFields())
            {
                if (!f.IsNotSerialized)
                    f.SetValue(spawnModel, f.GetValue(view.spawnConfig));
            }
        }
    }
}
