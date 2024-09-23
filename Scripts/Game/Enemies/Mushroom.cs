using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{

    protected override void Start()
    {
        speed = ConfigurationUtils.MushroomSpeed;
        health = ConfigurationUtils.MushroomHealth;
        base.Start();
    }
    protected override void Update()
    {
        //if (moveTimer.Finished)
        transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0));
        base.Update();
    }
}
