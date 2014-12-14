using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace AST.Game
{
    public class MouseInputView : View
    {
        public Signal<GameObject> OnMouseInput = new Signal<GameObject>();

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var target = GetMouseTarget();
                if (null != target)
                    OnMouseInput.Dispatch(target);
            }
        }

        private GameObject GetMouseTarget()
        {
            var hitInfo = Physics2D.Raycast(Camera.main.transform.position, Input.mousePosition);
            if (null != hitInfo.collider)
                return hitInfo.collider.gameObject;
            return null;
        }
    }
}
