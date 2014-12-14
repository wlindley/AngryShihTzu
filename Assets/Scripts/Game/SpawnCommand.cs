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
            InitializeObject(obj);
            reparentSignal.Dispatch(obj);
        }

        private GameObject InstantiatePrefab()
        {
            return GameObject.Instantiate(spawnModel.prefabToSpawn) as GameObject;
        }

        private void InitializeObject(GameObject go)
        {
            go.GetComponent<SpriteRenderer>().sprite = GetRandomImage();
            var pos = PositionObject(go);
            AnimateObject(go, pos);
        }

        private Sprite GetRandomImage()
        {
            return Resources.Load<Sprite>("Images/" + Random.Range(0, 16).ToString("D2"));
        }

        private Vector3 PositionObject(GameObject go)
        {
            var pos = go.transform.position;
            pos.y = spawnModel.spawnHeight;
            pos.x = Random.Range(spawnModel.minSpawnX, spawnModel.maxSpawnX);
            go.transform.position = pos;
            return pos;
        }

        private void AnimateObject(GameObject go, Vector3 pos)
        {
            SetupVerticalMovement(go, pos);
            SetupHorizontalMotion(go, pos);
        }

        private void SetupVerticalMovement(GameObject go, Vector3 pos)
        {
            var fallTime = GetFallTime();
            LeanTween.moveY(go, spawnModel.deathHeight, fallTime).setOnComplete(HandleEscaped);
        }

        private void SetupHorizontalMotion(GameObject go, Vector3 pos)
        {
            if (Random.value < spawnModel.chanceOfZigZagging)
                LeanTween.moveX(go, pos.x + GetHorizontalAmplitude(pos), GetHorizontalFrequency() * .5f).setLoopPingPong();
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
