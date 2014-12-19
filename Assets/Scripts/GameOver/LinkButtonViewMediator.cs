using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.GameOver
{
    public class LinkButtonViewMediator : Mediator
    {
        [Inject]
        public LinkButtonView view { private get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.OnClicked.AddListener(HandleClicked);

            view.SetLabel(GetButtonLabelForPlatform());
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.OnClicked.RemoveListener(HandleClicked);
        }

        private void HandleClicked()
        {
            var url = GetUrlForPlatform();
            Application.OpenURL(url);
        }

        private string GetUrlForPlatform()
        {
#if UNITY_WEBPLAYER
            return "http://www.walkerlindley.com/projects/angryshihtzus/AngryShihTzus.apk";
#endif
            return "http://www.walkerlindley.com/projects/angryshihtzus/";
        }

        private string GetButtonLabelForPlatform()
        {
#if UNITY_WEBPLAYER
            return "Get Android App";
#endif
            return "Play Online";
        }
    }
}
