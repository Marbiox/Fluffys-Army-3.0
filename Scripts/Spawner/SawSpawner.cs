using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawSpawner : MonoBehaviour
{

    [SerializeField] GameObject saw;

    List<Vector2> spawnPositions = new List<Vector2>();
    List<Vector2> openPositions = new List<Vector2>();

    [SerializeField] GameObject gem;

    int gemQueue = 0;

    Timer spawnTimer;
    Timer rowTimer;
    float rowTimerDuration;

    float sawHeight;
    void Start()
    {
        sawHeight = saw.GetComponent<SpriteRenderer>().size.y;

        //set spawnTimer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = ConfigurationUtils.SawSpawnFrequency;
        spawnTimer.Run();

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
        for (int i = 0; i < amount; i++)
        {
            spawnPositions.Add(spawnPlace);
            spawnPlace.x += length;
        }
    }

    void Update()
    {
        if (rowTimer.Finished) {
            gemQueue += 1;
            openPositions.Clear();
            openPositions.AddRange(spawnPositions);
            rowTimerDuration = sawHeight / ConfigurationUtils.SawSpeed;
            if (spawnTimer.Finished) {
                SpawnSaws();
                spawnTimer.Duration = ConfigurationUtils.SawSpawnFrequency;
                spawnTimer.Run();
                rowTimerDuration += .5f;
            }
            while (gemQueue > 0)
            {
                int index = Random.Range(0, openPositions.Count);
                Vector2 location = openPositions[index];
                Instantiate(gem,location,Quaternion.identity);
                openPositions.RemoveAt(index);
                gemQueue--;
            }
            rowTimer.Duration = rowTimerDuration;
            rowTimer.Run();
        }
    }

    void SpawnSaws()
    {
        int amount = Random.Range(ConfigurationUtils.SawSpawnMin, ConfigurationUtils.SawSpawnMax);
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, openPositions.Count);
            Vector2 location = openPositions[index];
            Instantiate(saw,location,Quaternion.identity);
            openPositions.RemoveAt(index);
        }
    }

    void AddToGemQueue(int amount) {
        gemQueue += amount;
    }

}
