using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.UI;

namespace AST.Game
{
    public class SpawnCommand : Command
    {
        [Inject]
        public ReparentSpawnedObjectSignal reparentSignal { private get; set; }

        [Inject]
        public SpawnModel spawnModel { private get; set; }

        public override void Execute()
        {
            var obj = InstantiatePrefab();
            InitializeObject(obj.GetComponent<Image>());
            reparentSignal.Dispatch(obj);
        }

        private static GameObject InstantiatePrefab()
        {
            var prefab = Resources.Load<GameObject>("Prefabs/DogImage");
            return GameObject.Instantiate(prefab) as GameObject;
        }

        private void InitializeObject(Image image)
        {
            image.sprite = Resources.Load<Sprite>("Images/" + Random.Range(0, 16).ToString("D2"));
            var pos = image.rectTransform.position;
            pos.y = spawnModel.spawnHeight;
            pos.x = Random.Range(spawnModel.minSpawnX, spawnModel.maxSpawnX);
            image.rectTransform.position = pos;

            LeanTween.move(image.rectTransform, new Vector2(pos.x, spawnModel.deathHeight), Random.Range(spawnModel.minFallTime, spawnModel.maxFallTime));
        }
    }
}
