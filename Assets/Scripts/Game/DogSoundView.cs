using strange.extensions.mediation.impl;
using UnityEngine;

namespace AST.Game
{
    public class DogSoundView : View
    {
        [Range(0f, 1f)]
        public float goatChance;

        protected override void Start()
        {
            base.Start();
            PlayBark();
        }

        void Update()
        {
            if (!audio.isPlaying)
                GameObject.Destroy(gameObject);
        }

        private void PlayBark()
        {
            var soundClip = GetSound();
            audio.clip = soundClip;
            audio.Play();
        }

        private AudioClip GetSound()
        {
            if (Random.Range(0f, 1f) < goatChance)
                return GetGoatSound();
            return GetDogSound();
        }

        private AudioClip GetGoatSound()
        {
            return Resources.Load<AudioClip>("Sounds/goat_" + Random.Range(0, 2).ToString("D2"));
        }

        private AudioClip GetDogSound()
        {
            return Resources.Load<AudioClip>("Sounds/dog_" + Random.Range(0, 14).ToString("D2"));
        }
    }
}
