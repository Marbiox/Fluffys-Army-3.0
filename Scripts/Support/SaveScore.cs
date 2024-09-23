using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{

    bool saved = false;

    void Start()
    {
        EventManager.AddListener(EventName.gameOver, SavaScore);
    }

    void SavaScore()
    {
        if (!saved)
        {
            int currentScore = ScoreManager.GetScore();
            int highScore1 = PlayerPrefs.GetInt(ScoreName.highScore1.ToString(), 0);
            int highScore2 = PlayerPrefs.GetInt(ScoreName.highScore2.ToString(), 0);
            int highScore3 = PlayerPrefs.GetInt(ScoreName.highScore3.ToString(), 0);
            int highScore4 = PlayerPrefs.GetInt(ScoreName.highScore4.ToString(), 0);
            int highScore5 = PlayerPrefs.GetInt(ScoreName.highScore5.ToString(), 0);


            int temp1;
            int temp2;

            if (currentScore > highScore1)
            {
                temp1 = highScore1;
                highScore1 = currentScore;
                temp2 = highScore2;
                highScore2 = temp1;
                temp1 = highScore3;
                highScore3 = temp2;
                temp2 = highScore4;
                highScore4 = temp1;
                highScore5 = temp2;
            }
            else if (currentScore > highScore2)
            {
                temp1 = highScore2;
                highScore2 = currentScore;
                temp2 = highScore3;
                highScore3 = temp1;
                temp1 = highScore4;
                highScore4 = temp2;
                highScore5 = temp1;
            }
            else if (currentScore > highScore3)
            {
                temp1 = highScore3;
                highScore3 = currentScore;
                temp2 = highScore4;
                highScore4 = temp1;
                highScore5 = temp2;
            }
            else if (currentScore > highScore4)
            {
                temp1 = highScore4;
                highScore4 = currentScore;
                highScore5 = temp1;
            }
            else if (currentScore > highScore5)
            {
                highScore5 = currentScore;
            }

            PlayerPrefs.SetInt(ScoreName.highScore1.ToString(), highScore1);
            PlayerPrefs.SetInt(ScoreName.highScore2.ToString(), highScore2);
            PlayerPrefs.SetInt(ScoreName.highScore3.ToString(), highScore3);
            PlayerPrefs.SetInt(ScoreName.highScore4.ToString(), highScore4);
            PlayerPrefs.SetInt(ScoreName.highScore5.ToString(), highScore5);
            saved = true;
        }
    }

}
