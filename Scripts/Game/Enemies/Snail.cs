using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Enemy
{
    protected override void Start()
    {
        speed = ConfigurationUtils.SnailSpeed;
        health = ConfigurationUtils.SnailHealth;
        base.Start();
    }
    protected override void Update()
    {
        //if (moveTimer.Finished)
        transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0));
        base.Update();
    }
}
