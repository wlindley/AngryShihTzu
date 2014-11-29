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
            return Resources.Load<AudioClip>("Sounds/dog_00");
        }
    }
}
