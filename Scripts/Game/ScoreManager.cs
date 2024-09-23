using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static float score = 0;
    int scoreMultiplier = 1;
    bool gameOver = false;

    void Start()
    {
        score = 0;
        EventManager.AddListener(EventName.levelIncrease, UpdateScoreMultiplier);
        EventManager.AddListener(EventName.gameOver, GameOver);
        EventManager.AddListener(EventName.addScore, AddScore);
    }

    void Update()
    {
        if (!gameOver)
        {
            score += Time.deltaTime * scoreMultiplier * 30;
        }    
    }

    void UpdateScoreMultiplier(int level)
    {
        scoreMultiplier = level;
    }
    void GameOver()
    {
        gameOver = true;
    }
    public static int GetScore()
    {
        return (int)score;
    }
    void AddScore(int bonus)
    {
        score += bonus * scoreMultiplier;
    }
}
