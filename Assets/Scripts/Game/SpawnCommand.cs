using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.UI;

namespace AST.Game
{
    public class SpawnCommand : Command
    {
        [Inject]
        public ReparentSpawnedObjectSignal reparentSignal { private get; set; }

        public override void Execute()
        {
            var obj = InstantiatePrefab();
            SetRandomImage(obj.GetComponent<Image>());
            reparentSignal.Dispatch(obj);
        }

        private static GameObject InstantiatePrefab()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/DogImage");
            return GameObject.Instantiate(prefab) as GameObject;
        }

        private void SetRandomImage(Image image)
        {
            image.sprite = Resources.Load<Sprite>("Images/" + Random.Range(0, 16).ToString("D2"));
        }
    }
}
