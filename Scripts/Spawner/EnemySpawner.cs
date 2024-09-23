using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyTypes;
    [SerializeField] GameObject ChickenBoss;
    [SerializeField] GameObject warning;
    [SerializeField] GameObject bossWarning;
    GameObject warningInstance;
    GameObject bossWarningInstance;
    Timer spawnTimer;
    float spawnTime;
    Timer warningTimer;
    Timer bossWarningTimer;
    float warningDuration = 3;
    float bossWarnigDuration = 5;
    float halfWarningHeight;
    float halfWarningWidth;
    float groundHeight;
    int enemyIndex;

    bool enemyRight = false;

    void Start()
    {
        spawnTime = Random.Range(ConfigurationUtils.EnemySpawnTimeMin, ConfigurationUtils.EnemySpawnTimeMax);
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnTime;
        spawnTimer.Run();
        EventManager.AddListener(EventName.levelIncrease, LevelIncrease);

        warningTimer = gameObject.AddComponent<Timer>();
        warningTimer.Duration = warningDuration;
        bossWarningTimer = gameObject.AddComponent<Timer>();
        bossWarningTimer.Duration = bossWarnigDuration;
        halfWarningHeight = warning.GetComponent<SpriteRenderer>().size.y / 2 + .2f;
        halfWarningWidth = warning.GetComponent<SpriteRenderer>().size.x / 2 + .2f;
        groundHeight = ConfigurationUtils.GroundPosition.y + ConfigurationUtils.HalfGroundColliderHeight;
    }
    void Update()
    {
        if (spawnTimer.Finished) {
            enemyIndex = Random.Range(0, EnemyTypes.Length);
            spawnTime = Random.Range(ConfigurationUtils.EnemySpawnTimeMin, ConfigurationUtils.EnemySpawnTimeMax);
            spawnTimer.Duration = spawnTime;
            spawnTimer.Run();
            //Instantiate(EnemyTypes[enemyIndex]);
            enemyRight = Random.Range(0, 2) == 1;
            warningTimer.Run();
            //Debug.Log("Ground Height: " + groundHeight + "warning height: " + halfWarningHeight);
            if (enemyRight){
                warningInstance = Instantiate(warning, new Vector2(ScreenUtils.ScreenRight - halfWarningWidth, groundHeight + halfWarningHeight), Quaternion.identity);
            }
            else{
                warningInstance = Instantiate(warning, new Vector2(ScreenUtils.ScreenLeft + halfWarningWidth, groundHeight + halfWarningHeight), Quaternion.identity);
            }
        }
        
        if (warningTimer.Finished) {
            Destroy(warningInstance);
            warningTimer.Reset();
            GameObject enemyInstance = Instantiate(EnemyTypes[enemyIndex]);
            enemyInstance.GetComponent<Enemy>().setDirection(enemyRight);
        }

        if (bossWarningTimer.Finished) {
            Destroy(bossWarningInstance);
            bossWarningTimer.Reset();
            EventInvokerUtils.Invoke(EventName.bossSpawned);
            Instantiate(ChickenBoss);
        }
    }

    void LevelIncrease(int level)
    {
        if (level % 5 == 0) {
            bossWarningTimer.Run();
            bossWarningInstance = Instantiate(bossWarning, new Vector2(0, ScreenUtils.ScreenTop - 2), Quaternion.identity);
        }
    }
}
