using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    
    [SerializeField] private Audio[] audios; 
    public enum SoundName
    {
        BGM,
        BORED,
        EAT1,
        EAT2,
        BUTTON,
        SAD,
        SHOWER,
        PLAYING
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Play(SoundName.BGM);
    }

    public void Play(SoundName name)
    {
        Audio audio = GetAudio(name);
        if (audio.audioSource == null)
        {
            audio.audioSource = gameObject.AddComponent<AudioSource>();
            
            audio.audioSource.clip = audio.clip;
            audio.audioSource.loop = audio.loop;

        }
        
        audio.audioSource.Play();
    }

    public Audio GetAudio(SoundName name)
    {
        return Array.Find(audios, s => s.soundName == name);
    }
}
