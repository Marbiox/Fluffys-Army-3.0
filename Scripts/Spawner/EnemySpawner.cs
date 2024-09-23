using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyTypes;
    [SerializeField] GameObject ChickenBoss;
    [SerializeField] GameObject warning;
    [SerializeField] GameObject bossWarning;
    Timer spawnTimer;
    float spawnTime;

    List<(Timer, bool)> enemySpawnInformation = new List<(Timer, bool)> ();
    const float warningDuration = 3;
    Timer bossWarningTimer;
    const float bossWarnigDuration = 5;
    float halfWarningHeight;
    float halfWarningWidth;
    float groundHeight;
    int enemyIndex;

    bool enemyRight = false;

    void Start() {
        spawnTime = Random.Range(ConfigurationUtils.EnemySpawnTimeMin, ConfigurationUtils.EnemySpawnTimeMax);
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = spawnTime;
        spawnTimer.Run();
        EventManager.AddListener(EventName.levelIncrease, LevelIncrease);
        bossWarningTimer = gameObject.AddComponent<Timer>();
        bossWarningTimer.Duration = bossWarnigDuration;
        halfWarningHeight = warning.GetComponent<SpriteRenderer>().size.y / 2 + .2f;
        halfWarningWidth = warning.GetComponent<SpriteRenderer>().size.x / 2 + .2f;
        groundHeight = ConfigurationUtils.GroundPosition.y + ConfigurationUtils.HalfGroundColliderHeight;
    }
    void Update() {
        if (spawnTimer.Finished) {
            enemyIndex = Random.Range(0, EnemyTypes.Length);
            spawnTime = Random.Range(ConfigurationUtils.EnemySpawnTimeMin, ConfigurationUtils.EnemySpawnTimeMax);
            spawnTimer.Duration = spawnTime;
            spawnTimer.Run();
            //Instantiate(EnemyTypes[enemyIndex]);
            enemyRight = Random.Range(0, 2) == 1;
            //Debug.Log("Ground Height: " + groundHeight + "warning height: " + halfWarningHeight);
            if (enemyRight) {
                Instantiate(warning, new Vector2(ScreenUtils.ScreenRight - halfWarningWidth, groundHeight + halfWarningHeight), Quaternion.identity);
            }
            else {
                Instantiate(warning, new Vector2(ScreenUtils.ScreenLeft + halfWarningWidth, groundHeight + halfWarningHeight), Quaternion.identity);
            }
            Timer warningTimer = gameObject.AddComponent<Timer>();
            warningTimer.Duration = warningDuration;
            warningTimer.Run();
            enemySpawnInformation.Add((warningTimer, enemyRight));
        }
        
        for (int i = 0; i < enemySpawnInformation.Count; i++) {
            (Timer, bool) information = enemySpawnInformation[i];
            if (information.Item1.Finished) {
                GameObject enemyInstance = Instantiate(EnemyTypes[enemyIndex]);
                enemyInstance.GetComponent<Enemy>().setDirection(information.Item2);
                enemySpawnInformation.Remove(information);
                i--;
            }
        }

        if (bossWarningTimer.Finished) {
            bossWarningTimer.Reset();
            EventInvokerUtils.Invoke(EventName.bossSpawned);
            Instantiate(ChickenBoss);
        }
    }

    void LevelIncrease(int level) {
        if (level % 5 == 0) {
            bossWarningTimer.Run();
            Instantiate(bossWarning, new Vector2(0, ScreenUtils.ScreenTop - 2), Quaternion.identity);
        }
    }
}
