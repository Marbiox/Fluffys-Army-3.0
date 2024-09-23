using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpawner : MonoBehaviour
{

    [SerializeField] GameObject saw;

    List<Vector2> spawnPositions = new List<Vector2>();
    List<Vector2> openPositions = new List<Vector2>();

    [SerializeField] GameObject gem;

    int gemCombo = 0;
    int gemQueue = 0;
    float gemSpawnSpeedMultiplier = 1;
    const float gemSpawnTime  = 5;

    Timer sawSpawnTimer;
    Timer gemSpawnTimer;
    Timer rowTimer;
    float rowTimerDuration;

    float sawHeight;
    void Start() {

        EventManager.AddListener(EventName.gemCollected, GemCollected);
        EventManager.AddListener(EventName.gemComboEnded, GemComboEnded);

        sawHeight = saw.GetComponent<SpriteRenderer>().size.y;

        //set spawnTimer
        sawSpawnTimer = gameObject.AddComponent<Timer>();
        sawSpawnTimer.Duration = ConfigurationUtils.SawSpawnFrequency;
        sawSpawnTimer.Run();

        //set gem spawn timer
        gemSpawnTimer = gameObject.AddComponent<Timer>();
        gemSpawnTimer.Duration = gemSpawnTime;
        gemSpawnTimer.Run();

        rowTimer = gameObject.AddComponent<Timer>();
        rowTimerDuration = sawHeight / ConfigurationUtils.SawSpeed;
        rowTimer.Duration = rowTimerDuration;
        rowTimer.Run();

        //sets variables
        float colliderWidth = saw.GetComponent<CircleCollider2D>().radius * 2;
        float colliderHeight = saw.GetComponent<CircleCollider2D>().radius * 2;
        float space = .1f;

        //creates spawnPlaces list
        float length = colliderWidth * transform.localScale.x + space;
        float worldWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int amount = (int)(worldWidth / length);
        float offset = (worldWidth - space) % length / (amount + 1);
        length += offset;
        Vector2 spawnPlace = new Vector2(ScreenUtils.ScreenLeft + colliderWidth / 2 + offset + space, ScreenUtils.ScreenTop + colliderHeight / 2);
        for (int i = 0; i < amount; i++) {
            spawnPositions.Add(spawnPlace);
            spawnPlace.x += length;
        }
    }

    void Update() {
        if (rowTimer.Finished) {
            openPositions.Clear();
            openPositions.AddRange(spawnPositions);
            rowTimerDuration = sawHeight / ConfigurationUtils.SawSpeed;
            if (sawSpawnTimer.Finished) {
                SpawnSaws();
                sawSpawnTimer.Duration = ConfigurationUtils.SawSpawnFrequency;
                sawSpawnTimer.Run();
                rowTimerDuration += .5f;
            }
            while (gemQueue > 0) {
                int index = Random.Range(0, openPositions.Count);
                Vector2 location = openPositions[index];
                Instantiate(gem,location,Quaternion.identity);
                openPositions.RemoveAt(index);
                gemQueue--;
            }
            rowTimer.Duration = rowTimerDuration;
            rowTimer.Run();
        }

        if (gemSpawnTimer.Finished) {
            gemQueue++;
            gemSpawnTimer.Run();
        }
    }

    void SpawnSaws() {
        int amount = Random.Range(ConfigurationUtils.SawSpawnMin, ConfigurationUtils.SawSpawnMax);
        for (int i = 0; i < amount; i++) {
            int index = Random.Range(0, openPositions.Count);
            Vector2 location = openPositions[index];
            Instantiate(saw,location,Quaternion.identity);
            openPositions.RemoveAt(index);
        }
    }

    void GemCollected() {
        gemCombo++;
        gemSpawnSpeedMultiplier *= 1 - .1f * Mathf.Pow(gemCombo, -.5f);
        gemSpawnTimer.Duration = gemSpawnTime * gemSpawnSpeedMultiplier;
    }

    void GemComboEnded() {
        gemSpawnSpeedMultiplier = 1;
        gemSpawnTimer.Duration = gemSpawnTime * gemSpawnSpeedMultiplier;
        gemCombo = 0;
    }
}
