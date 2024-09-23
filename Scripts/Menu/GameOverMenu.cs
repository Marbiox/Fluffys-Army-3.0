using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score; 

    void Start()
    {
        score.text = ScoreManager.GetScore().ToString();
        Time.timeScale = 0;
    }

    public void RestartButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Gameplay);
    }
    public void QuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
    }
}
