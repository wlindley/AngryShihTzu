using System.Collections.Generic;
using UnityEngine;

namespace AST
{
    public struct SceneStackElement
    {
        public string sceneName;
        public GameObject contextView;

        public SceneStackElement(string sceneName, GameObject contextView)
        {
            this.sceneName = sceneName;
            this.contextView = contextView;
        }
    }

    public class SceneStack : Stack<SceneStackElement> { }
}
