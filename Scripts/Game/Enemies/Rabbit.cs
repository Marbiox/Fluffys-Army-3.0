using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : Enemy
{
    //jump support
    [SerializeField] LayerMask ground;
    bool isGrounded = false;
    RaycastHit2D groundCheck;
    float groundCheckLength;
    [SerializeField] float jump;
    Rigidbody2D _rigidbody2D;

    protected override void Start()
    {
        speed = ConfigurationUtils.RabbitSpeed;
        health = ConfigurationUtils.RabbitHealth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        base.Start();
        groundCheckLength = halfEnemyHeight + .04f;
    }
    protected override void Update()
    {
        groundCheck = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, ground);
        //if (moveTimer.Finished)
        transform.Translate(new Vector2(speed * Time.deltaTime * direction, 0));
        IsGroundedCheck();
        base.Update();
    }
    void FixedUpdate()
    {
        /*if (isGrounded && moveTimer.Finished)
        {
            _rigidbody2D.velocity = new Vector2(0, jump);
        }*/
        if (isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(0, jump);
        }
    }

    void IsGroundedCheck()
    {
        if (groundCheck.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
