using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        MenuManager.GoToMenu(MenuName.Gameplay);
    }
    public void HelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        MenuManager.GoToMenu(MenuName.Help);
    }
    public void QuitButtonOnClickEvent()
    {
        Application.Quit();
    }
    public void HighScoreButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        MenuManager.GoToMenu(MenuName.HighScore);
    }
}
