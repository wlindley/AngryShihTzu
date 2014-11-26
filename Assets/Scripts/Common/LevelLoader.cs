using UnityEngine;

namespace AST
{
    public class LevelLoader
    {
        [Inject]
        public SceneStack sceneStack { private get; set; }

        public void LoadLevel(string levelName)
        {
            sceneStack.Push(levelName);
            Application.LoadLevelAdditive(levelName);
        }
    }
}
