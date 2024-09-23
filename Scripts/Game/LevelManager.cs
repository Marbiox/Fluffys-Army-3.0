using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int level = 1;
    Timer levelTimer;

    void Start()
    {
        levelTimer = gameObject.AddComponent<Timer>();
        levelTimer.Duration = 30;
        levelTimer.Run();
    }

    void Update()
    {
        if (levelTimer.Finished && level < 20)
        {
            level++;
            EventInvokerUtils.Invoke(EventName.levelIncrease, level);
            if (level == 5)
            {
                levelTimer.Duration = 30;
            }
            levelTimer.Run();
        }
    }
}
