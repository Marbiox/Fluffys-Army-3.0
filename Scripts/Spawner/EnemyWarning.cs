using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarning : MonoBehaviour
{

    Timer lifespan;
    [SerializeField] float lifespanDuration = 3;

    void Start() {
        lifespan = gameObject.AddComponent<Timer>();
        lifespan.Duration = lifespanDuration;
        lifespan.Run();
    }

    void Update() {
        if (lifespan.Finished) {
            Destroy(gameObject);
        }
    }
}
