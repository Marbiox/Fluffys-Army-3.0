using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBoss : MonoBehaviour
{

    int health;

    float edgeLeft;
    float edgeRight;
    float halfWidth;

    bool idle = false;
    bool falling = true;

    Animator _animator;

    Timer idleTimer;
    [SerializeField] float idleDuration;

    [SerializeField] float fallHeight;

    Timer timeLeft;

    void Start()
    {
        health = ConfigurationUtils.BossHealth;

        _animator = GetComponent<Animator>();

        halfWidth = GetComponent<SpriteRenderer>().size.x / 2;
        edgeLeft = ScreenUtils.ScreenLeft + halfWidth;
        edgeRight = ScreenUtils.ScreenRight - halfWidth;

        idleTimer = gameObject.AddComponent<Timer>();
        idleTimer.Duration = idleDuration;

        timeLeft = gameObject.AddComponent<Timer>();
        timeLeft.Duration = ConfigurationUtils.BossTime;
        timeLeft.Run();

        transform.position = new Vector2(0, fallHeight);
    }

    void Update()
    {
        EventInvokerUtils.Invoke(EventName.updateTimeLeft, (int)(timeLeft.TotalSeconds - timeLeft.ElapsedSeconds + .8f));
        if (timeLeft.Finished)
        {
            Destroy(gameObject);
        }
        if (idleTimer.Finished && idle)
        {
            idle = false;
            falling = true;
            transform.position = new Vector2(Random.Range(edgeLeft + .5f, edgeRight - .5f), fallHeight);
        }

        _animator.SetBool("Idle", idle);
        _animator.SetBool("Falling", falling);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            falling = false;
            idle = true;
            idleTimer.Run();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            EventInvokerUtils.Invoke(EventName.updateHealthBar, health);
        }
        if (health == 0)
        {
            EventInvokerUtils.Invoke(EventName.addScore, 3000);
            Destroy(gameObject);
        }
    }
}
