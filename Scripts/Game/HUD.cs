using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gemComboText;
    bool pauseMenuActive;
    int gemCombo = 0;

    void Start()
    {
        EventManager.AddListener(EventName.pauseMenuClosed, PauseMenuClosed);
        EventManager.AddListener(EventName.levelIncrease,UpdateLevelText);
        EventManager.AddListener(EventName.gameOver, GameOver);
        EventManager.AddListener(EventName.gemCollected, GemCollected);
        EventManager.AddListener(EventName.gemComboEnded, GemComboEnded);
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
    void GemCollected() {
        gemCombo++;
        gemComboText.text = "Gem Combo: " + gemCombo;
    }
    void GemComboEnded() {
        gemCombo = 0;
        gemComboText.text = "Gem Combo: " + gemCombo;
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
