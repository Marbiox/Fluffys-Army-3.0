using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
        EventManager.AddListener(EventName.pauseMenuClosed,PauseMenuClosed);
    }

    public void BackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        EventInvokerUtils.Invoke(EventName.pauseMenuClosed);
    }
    public void QuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
    }

    void PauseMenuClosed()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
