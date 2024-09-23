using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    void Awake()
    {
        if (!AudioManager.Initialized)
        {
            AudioSource soundEffectAudioSource = gameObject.AddComponent<AudioSource>();
            AudioSource musicAudioSource = gameObject.AddComponent<AudioSource>();
            musicAudioSource.loop = true;
            AudioManager.Initialize(soundEffectAudioSource, musicAudioSource);
            DontDestroyOnLoad(soundEffectAudioSource);
            DontDestroyOnLoad(musicAudioSource);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
