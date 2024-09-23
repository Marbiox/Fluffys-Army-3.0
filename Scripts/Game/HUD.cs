using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    bool pauseMenuActive;

    void Start()
    {
        EventManager.AddListener(EventName.pauseMenuClosed, PauseMenuClosed);
        EventManager.AddListener(EventName.levelIncrease,UpdateLevelText);
        EventManager.AddListener(EventName.gameOver, GameOver);
        levelText.text = "Level " + 1;
    }

    void Update()
    {
        scoreText.text = "Score " + ScoreManager.GetScore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuActive)
            {
                AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
                MenuManager.GoToMenu(MenuName.Pause);
                pauseMenuActive = true;
            }
            else
            {
                EventInvokerUtils.Invoke(EventName.pauseMenuClosed);
            }
        }
    }

    void UpdateLevelText(int level)
    {
        levelText.text = "Level " + level;
    }
    public void PauseButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        if (!pauseMenuActive)
        {
            MenuManager.GoToMenu(MenuName.Pause);
            pauseMenuActive = true;
        }
    }
    void PauseMenuClosed()
    {
        pauseMenuActive = false;
    }
    void GameOver()
    {
        MenuManager.GoToMenu(MenuName.GameOver);
    }
}
