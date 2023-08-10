using System;
using UnityEngine;

namespace _Project.Audio
{
    [Serializable]
    public class Audio
    {
        public AudioManager.SoundName soundName;
        public AudioClip clip;
        public bool loop;
        [HideInInspector] public AudioSource audioSource;
    }
}