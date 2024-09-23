using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConfiguration : MonoBehaviour
{
    float sawSpeed = 1;
    int sawSpawnMin = 1;
    int sawSpawnMax = 2;
    float sawSpawnFrequency = 5;
    float enemySpawnTimeMin = 5;
    float enemySpawnTimeMax = 8;
    float mushroomSpeed = 5;
    float rabbitSpeed = 3;
    float snailSpeed = 2;
    int mushroomHealth = 1;
    int rabbitHealth = 1;
    int snailHealth = 2;
    int bossHealth = 35;
    float bossTime = 130;

    public float SawSpeed
    {
        get{ return sawSpeed; }
    }
    public int SawSpawnMin
    {
        get { return sawSpawnMin; }
    }
    public int SawSpawnMax
    {
        get { return sawSpawnMax; }
    }
    public float SawSpawnFrequency
    {
        get { return sawSpawnFrequency; }
    }
    public float EnemySpawnTimeMin
    {
        get { return enemySpawnTimeMin; }
    }
    public float EnemySpawnTimeMax
    {
        get { return enemySpawnTimeMax; }
    }
    public float MushroomSpeed
    {
        get { return mushroomSpeed; }
    }
    public float RabbitSpeed
    {
        get { return rabbitSpeed; }
    }
    public float SnailSpeed
    {
        get { return snailSpeed; }
    }
    public int MushroomHealth
    {
        get { return mushroomHealth; }
    }
    public int RabbitHealth
    {
        get { return rabbitHealth; }
    }
    public int SnailHealth
    {
        get { return snailHealth; }
    }
    public int BossHealth
    {
        get { return bossHealth; }
    }
    public float BossTime
    {
        get { return bossTime; }
    }

    void Start()
    {
        EventManager.AddListener(EventName.levelIncrease, LevelIncrease);
    }

    void LevelIncrease(int level)
    {
        switch (level)
        {
            case 2:
                LevelTwoConfiguration();
                break;
            case 3:
                LevelThreeConfiguration();
                break;
            case 4:
                LevelFourConfiguration();
                break;
            case 5:
                LevelFiveConfiguration();
                break;
            case 6:
                LevelSixConfiguration();
                break;
            case 7:
                LevelSevenConfiguration();
                break;
            case 8:
                LevelEightConfiguration();
                break;
            case 9:
                LevelNineConfiguration();
                break;
            case 10:
                LevelTenConfiguration();
                break;
            case 11:
                LevelElevenConfiguration();
                break;
            case 12:
                LevelTwelveConfiguration();
                break;
            case 13:
                LevelThirteenConfiguration();
                break;
            case 14:
                LevelFourteenConfiguration();
                break;
            case 15:
                LevelFifteenConfiguration();
                break;
            case 16:
                LevelSixteenConfiguration();
                break;
            case 17:
                LevelSeventeenConfiguration();
                break;
            case 18:
                LevelEighteenConfiguration();
                break;
            case 19:
                LevelNineteenConfiguration();
                break;
            case 20:
                LevelTwentyConfiguration();
                break;

               
        }
    }

    void LevelTwoConfiguration()
    {
        sawSpeed = 1.2f;
        sawSpawnMin = 1;
        sawSpawnMax = 3;
        sawSpawnFrequency = 5;
        enemySpawnTimeMin = 5;
        enemySpawnTimeMax = 7;
        mushroomSpeed = 5;
        rabbitSpeed = 3;
        snailSpeed = 2;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 2;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelThreeConfiguration()
    {
        sawSpeed = 1.3f;
        sawSpawnMin = 2;
        sawSpawnMax = 3;
        sawSpawnFrequency = 4.5f;
        enemySpawnTimeMin = 5;
        enemySpawnTimeMax = 6;
        mushroomSpeed = 5.5f;
        rabbitSpeed = 3;
        snailSpeed = 2;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 2;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelFourConfiguration()
    {
        sawSpeed = 1.4f;
        sawSpawnMin = 2;
        sawSpawnMax = 4;
        sawSpawnFrequency = 4;
        enemySpawnTimeMin = 4;
        enemySpawnTimeMax = 6;
        mushroomSpeed = 6;
        rabbitSpeed = 3;
        snailSpeed = 2f;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 2;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelFiveConfiguration()
    {
        sawSpeed = 1.5f;
        sawSpawnMin = 3;
        sawSpawnMax = 4;
        sawSpawnFrequency = 3.8f;
        enemySpawnTimeMin = 4;
        enemySpawnTimeMax = 5;
        mushroomSpeed = 6;
        rabbitSpeed = 3;
        snailSpeed = 2;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 3;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelSixConfiguration()
    {
        sawSpeed = 1.7f;
        sawSpawnMin = 3;
        sawSpawnMax = 5;
        sawSpawnFrequency = 3.6f;
        enemySpawnTimeMin = 3;
        enemySpawnTimeMax = 5;
        mushroomSpeed = 6;
        rabbitSpeed = 4;
        snailSpeed = 1.5f;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 3;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelSevenConfiguration()
    {
        sawSpeed = 1.8f;
        sawSpawnMin = 3;
        sawSpawnMax = 5;
        sawSpawnFrequency = 3.5f;
        enemySpawnTimeMin = 2.5f;
        enemySpawnTimeMax = 4;
        mushroomSpeed = 6;
        rabbitSpeed = 4;
        snailSpeed = 1.5f;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 3;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelEightConfiguration()
    {
        sawSpeed = 1.9f;
        sawSpawnMin = 3;
        sawSpawnMax = 5;
        sawSpawnFrequency = 3.4f;
        enemySpawnTimeMin = 2.3f;
        enemySpawnTimeMax = 4;
        mushroomSpeed = 6;
        rabbitSpeed = 4;
        snailSpeed = 1.3f;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 4;
        bossHealth = 35;
        bossTime = 130;
    }
    void LevelNineConfiguration()
    {
        sawSpeed = 2;
        sawSpawnMin = 3;
        sawSpawnMax = 6;
        sawSpawnFrequency = 3.3f;
        enemySpawnTimeMin = 2.2f;
        enemySpawnTimeMax = 3.5f;
        mushroomSpeed = 6;
        rabbitSpeed = 4;
        snailSpeed = 1.2f;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 4;
        bossHealth = 50;
        bossTime = 130;
    }
    void LevelTenConfiguration()
    {
        sawSpeed = 2.1f;
        sawSpawnMin = 3;
        sawSpawnMax = 6;
        sawSpawnFrequency = 3.2f;
        enemySpawnTimeMin = 2;
        enemySpawnTimeMax = 3.5f;
        mushroomSpeed = 7;
        rabbitSpeed = 5;
        snailSpeed = 1;
        mushroomHealth = 1;
        rabbitHealth = 1;
        snailHealth = 5;
        bossHealth = 50;
        bossTime = 130;
    }
    void LevelElevenConfiguration()
    {
        sawSpeed = 2.2f;
        sawSpawnMin = 4;
        sawSpawnMax = 7;
        sawSpawnFrequency = 3.1f;
        enemySpawnTimeMin = 2;
        enemySpawnTimeMax = 3.3f;
        mushroomSpeed = 7.2f;
        rabbitSpeed = 5.1f;
        snailSpeed = 1;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 50;
        bossTime = 130;
    }
    void LevelTwelveConfiguration()
    {
        sawSpeed = 2.3f;
        sawSpawnMin = 4;
        sawSpawnMax = 7;
        sawSpawnFrequency = 3;
        enemySpawnTimeMin = 2;
        enemySpawnTimeMax = 3.2f;
        mushroomSpeed = 7.4f;
        rabbitSpeed = 5.2f;
        snailSpeed = .9f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 50;
        bossTime = 130;
    }
    void LevelThirteenConfiguration()
    {
        sawSpeed = 2.5f;
        sawSpawnMin = 4;
        sawSpawnMax = 7;
        sawSpawnFrequency = 2.9f;
        enemySpawnTimeMin = 2;
        enemySpawnTimeMax = 3;
        mushroomSpeed = 7.6f;
        rabbitSpeed = 5.3f;
        snailSpeed = .9f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 50;
        bossTime = 130;
    }
    void LevelFourteenConfiguration()
    {
        sawSpeed = 2.6f;
        sawSpawnMin = 4;
        sawSpawnMax = 7;
        sawSpawnFrequency = 2.8f;
        enemySpawnTimeMin = 1.9f;
        enemySpawnTimeMax = 3;
        mushroomSpeed = 7.8f;
        rabbitSpeed = 5.4f;
        snailSpeed = .8f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 100;
        bossTime = 130;
    }
    void LevelFifteenConfiguration()
    {
        sawSpeed = 2.7f;
        sawSpawnMin = 4;
        sawSpawnMax = 8;
        sawSpawnFrequency = 2.7f;
        enemySpawnTimeMin = 1.8f;
        enemySpawnTimeMax = 3;
        mushroomSpeed = 8f;
        rabbitSpeed = 5.5f;
        snailSpeed = .8f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 6;
        bossHealth = 100;
        bossTime = 130;
    }
    void LevelSixteenConfiguration()
    {
        sawSpeed = 2.8f;
        sawSpawnMin = 5;
        sawSpawnMax = 8;
        sawSpawnFrequency = 2.6f;
        enemySpawnTimeMin = 1.5f;
        enemySpawnTimeMax = 2.8f;
        mushroomSpeed = 8.2f;
        rabbitSpeed = 5.6f;
        snailSpeed = .7f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 100;
        bossTime = 130;
    }
    void LevelSeventeenConfiguration()
    {
        sawSpeed = 2.9f;
        sawSpawnMin = 5;
        sawSpawnMax = 8;
        sawSpawnFrequency = 2.5f;
        enemySpawnTimeMin = 1.4f;
        enemySpawnTimeMax = 2.6f;
        mushroomSpeed = 8.4f;
        rabbitSpeed = 5.7f;
        snailSpeed = .7f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 5;
        bossHealth = 100;
        bossTime = 130;
    }
    void LevelEighteenConfiguration()
    {
        sawSpeed = 3f;
        sawSpawnMin = 5;
        sawSpawnMax = 9;
        sawSpawnFrequency = 2.5f;
        enemySpawnTimeMin = 1.3f;
        enemySpawnTimeMax = 2.4f;
        mushroomSpeed = 8.6f;
        rabbitSpeed = 5.8f;
        snailSpeed = .6f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 6;
        bossHealth = 100;
        bossTime = 130;
    }
    void LevelNineteenConfiguration()
    {
        sawSpeed = 3.1f;
        sawSpawnMin = 6;
        sawSpawnMax = 9;
        sawSpawnFrequency = 2.4f;
        enemySpawnTimeMin = 1.2f;
        enemySpawnTimeMax = 2.2f;
        mushroomSpeed = 8.9f;
        rabbitSpeed = 5.9f;
        snailSpeed = .6f;
        mushroomHealth = 1;
        rabbitHealth = 2;
        snailHealth = 6;
        bossHealth = 150;
        bossTime = 130;
    }
    void LevelTwentyConfiguration()
    {
        sawSpeed = 3.2f;
        sawSpawnMin = 7;
        sawSpawnMax = 9;
        sawSpawnFrequency = 2.3f;
        enemySpawnTimeMin = 1;
        enemySpawnTimeMax = 2;
        mushroomSpeed = 9;
        rabbitSpeed = 6;
        snailSpeed = .5f;
        mushroomHealth = 1;
        rabbitHealth = 3;
        snailHealth = 7;
        bossHealth = 150;
        bossTime = 130;
    }
}
