using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreMenu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScore1;
    [SerializeField] TextMeshProUGUI highScore2;
    [SerializeField] TextMeshProUGUI highScore3;
    [SerializeField] TextMeshProUGUI highScore4;
    [SerializeField] TextMeshProUGUI highScore5;

    void Start()
    {
        highScore1.text = "HighScore 1: " + PlayerPrefs.GetInt(ScoreName.highScore1.ToString());
        highScore2.text = "HighScore 2: " + PlayerPrefs.GetInt(ScoreName.highScore2.ToString());
        highScore3.text = "HighScore 3: " + PlayerPrefs.GetInt(ScoreName.highScore3.ToString());
        highScore4.text = "HighScore 4: " + PlayerPrefs.GetInt(ScoreName.highScore4.ToString());
        highScore5.text = "HighScore 5: " + PlayerPrefs.GetInt(ScoreName.highScore5.ToString());
    }

    public void BackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClicked, AudioTypes.SoundEffect);
        Destroy(gameObject);
    }
}
