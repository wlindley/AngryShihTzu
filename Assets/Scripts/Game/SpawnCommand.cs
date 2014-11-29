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
        public TargetEscapedSignal escapeSignal { private get; set; }

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
            image.sprite = GetRandomImage();
            var pos = PositionObject(image);
            AnimateObject(image, pos);
        }

        private Sprite GetRandomImage()
        {
            return Resources.Load<Sprite>("Images/" + Random.Range(0, 16).ToString("D2"));
        }

        private Vector3 PositionObject(Image image)
        {
            var pos = image.rectTransform.position;
            pos.y = spawnModel.spawnHeight;
            pos.x = Random.Range(spawnModel.minSpawnX, spawnModel.maxSpawnX);
            image.rectTransform.position = pos;
            return pos;
        }

        private void AnimateObject(Image image, Vector3 pos)
        {
            SetupVerticalMovement(image, pos);
            SetupHorizontalMotion(image, pos);
        }

        private void SetupVerticalMovement(Image image, Vector3 pos)
        {
            var fallTime = GetFallTime();
            LeanTween.move(image.rectTransform, new Vector2(pos.x, spawnModel.deathHeight), fallTime).setOnComplete(HandleEscaped);
        }

        private void SetupHorizontalMotion(Image image, Vector3 pos)
        {
            if (Random.value < spawnModel.chanceOfZigZagging)
                LeanTween.moveX(image.gameObject, pos.x + GetHorizontalAmplitude(pos), GetHorizontalFrequency() * .5f).setLoopPingPong();
        }

        private float GetHorizontalAmplitude(Vector3 pos)
        {
            var horizDelta = Random.Range(spawnModel.minZigDelta, spawnModel.maxZigDelta);
            if (pos.x > spawnModel.minSpawnX + (.5f * (spawnModel.maxSpawnX - spawnModel.minSpawnX)))
                horizDelta *= -1f;
            return horizDelta;
        }

        private float GetHorizontalFrequency()
        {
            var horizFrequency = Random.Range(spawnModel.minZigFrequency, spawnModel.maxZigFrequency);
            return horizFrequency;
        }

        private float GetFallTime()
        {
            return Mathf.Max(
                Random.Range(spawnModel.initialMinFallTime, spawnModel.initialMaxFallTime) + spawnModel.fallTimeOffset,
                spawnModel.minFallTime);
        }

        private void HandleEscaped()
        {
            escapeSignal.Dispatch();
            LeanTween.pauseAll();
        }
    }
}
