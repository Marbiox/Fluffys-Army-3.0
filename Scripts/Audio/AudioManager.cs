using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    //sets variables
    static bool initialized = false;
    static AudioSource soundEffectsAudioSource;
    static AudioSource musicAudioSource;
    static Dictionary<AudioClipName, AudioClip> audioClipNames = new Dictionary<AudioClipName, AudioClip>();

    //returns whether or not the script has been initialized
    public static bool Initialized
    {
        get { return initialized; }
    }

    //Initializes the script
    public static void Initialize(AudioSource soundEffectsSource, AudioSource musicSource)
    {
        initialized = true;
        soundEffectsAudioSource = soundEffectsSource;
        musicAudioSource = musicSource;
        audioClipNames.Add(AudioClipName.Died, Resources.Load<AudioClip>("DeathSoundEffect"));
        audioClipNames.Add(AudioClipName.ButtonClicked, Resources.Load<AudioClip>("ButtonClick"));
        audioClipNames.Add(AudioClipName.Jump, Resources.Load<AudioClip>("JumpSoundEffect"));
        audioClipNames.Add(AudioClipName.Music, Resources.Load<AudioClip>("GameMusic"));
        audioClipNames.Add(AudioClipName.Shoot, Resources.Load<AudioClip>("Shoot"));
    }

    //plays audioclip
    public static void Play(AudioClipName clip, AudioTypes type)
    {
        if (type == AudioTypes.SoundEffect)
        {
            soundEffectsAudioSource.PlayOneShot(audioClipNames[clip]);
        }
        else if (type == AudioTypes.Music)
        {
            musicAudioSource.PlayOneShot(audioClipNames[clip]);
        }
    }
}
