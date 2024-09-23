using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] GameObject warning;
    //float moveTimerDuration = 3;
    bool right;
    protected float speed;
    protected float halfEnemyHeight;

    //protected Timer moveTimer;
    SpriteRenderer _spriteRenderer;

    float halfEnemyWidth;
    //bool warningDestroyed = false;
    protected int direction = 1;

    //Timer invinsibilityTimer;
    protected int health;

    protected virtual void Start()
    {
        //sets components
        _spriteRenderer = GetComponent<SpriteRenderer>();
        halfEnemyWidth = _spriteRenderer.size.x / 2;
        halfEnemyHeight = _spriteRenderer.size.y / 2;
        //moveTimer = gameObject.AddComponent<Timer>();
        //moveTimer.Duration = moveTimerDuration;
        //moveTimer.Run();
        //right = Random.Range(0, 2) == 1;
        //invinsibilityTimer = gameObject.AddComponent<Timer>();
        //invinsibilityTimer.Duration = 3.5f;
        //invinsibilityTimer.Run();

        //get dimensions
        //float halfWarningHeight = warning.GetComponent<SpriteRenderer>().size.y / 2 + .2f;
        //float halfWarningWidth = warning.GetComponent<SpriteRenderer>().size.x / 2 + .2f;
        float height = ConfigurationUtils.GroundPosition.y + ConfigurationUtils.HalfGroundColliderHeight;

        //change position based on direction
        if (right)
        {
            transform.position = new Vector2(9.6f, height + halfEnemyHeight);
            //warning = Instantiate(warning, new Vector2(ScreenUtils.ScreenRight - halfWarningWidth, height + halfWarningHeight), Quaternion.identity);
        }
        else
        {
            transform.position = new Vector2(-9.6f, height + halfEnemyHeight);
            //warning = Instantiate(warning, new Vector2(ScreenUtils.ScreenLeft + halfWarningWidth, height + halfWarningHeight), Quaternion.identity);
        }
        //changes sprite based on position
        if (right)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
        //changes direction based on position
        if (right)
        {
            direction = -1;
        }
    }

    protected virtual void Update()
    {
        /*if (moveTimer.Finished)
        {
            if (!warningDestroyed)
            {
                Destroy(warning);
            }
        }*/
        if (right && transform.position.x + halfEnemyWidth < ScreenUtils.ScreenLeft)
        {
            Destroy(gameObject);
        }
        if (!right && transform.position.x - halfEnemyWidth > ScreenUtils.ScreenRight)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Bullet" && invinsibilityTimer.Finished)
        {
            health -= 1;
        }*/
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
        }
        if (health == 0)
        {
            EventInvokerUtils.Invoke(EventName.addScore, 100);
            Destroy(gameObject);
        }
    }

    public void setDirection(bool isRight) {
        if (isRight) right = true;
        else right = false;
    }
}
