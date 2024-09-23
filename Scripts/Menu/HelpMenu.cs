using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void BackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Destroy(gameObject);
    }
}
