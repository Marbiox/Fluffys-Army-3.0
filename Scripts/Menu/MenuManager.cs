using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Main:
                SceneManager.LoadScene("Main");
                break;
            case MenuName.Gameplay:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Help:
                Object.Instantiate(Resources.Load("HelpMenu"));
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.GameOver:
                Object.Instantiate(Resources.Load("GameOverMenu"));
                break;
            case MenuName.HighScore:
                Object.Instantiate(Resources.Load("HighScoreMenu"));
                break;


        }
    }
}
