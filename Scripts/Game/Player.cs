using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //speed
    [Header("Movement")]
    [SerializeField]  float speed = 20;
    [SerializeField] float jump = 10;
    [SerializeField] float jumpLength = 1;

    //jumping support
    [Header("Ground Check")]
    [SerializeField]LayerMask ground;
    [SerializeField] bool isGrounded = false;
    RaycastHit2D groundCheck;
    float groundCheckLength;
    Timer jumpTimer;
    bool jumping = false;
    bool falling;


    //sound support
    Timer jumpSoundTimer;
    bool jumpTimerStarted;

    //animation support
    Animator _animator;

    //input detection
    float horizontal;
    float vertical;

    bool facingRight = true;
    float halfColliderHeight;
    float halfColliderWidth;

    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    void Start() {
        //gets components
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();

        halfColliderWidth = _spriteRenderer.size.x / 2;
        halfColliderHeight = _spriteRenderer.size.y / 2;

        //set jumpTimer
        jumpTimer = gameObject.AddComponent<Timer>();
        jumpTimer.Duration = jumpLength;

        //set jumpSoundTimer
        jumpSoundTimer = gameObject.AddComponent<Timer>();
        jumpSoundTimer.Duration = .3f;

        //sets goundCheck Raycast length
        groundCheckLength = halfColliderHeight / transform.localScale.y + .04f;
    }

    void Update() {
        //gets player input
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        groundCheck = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, ground);

        //checks if player can jump
        if (vertical == 0 && !isGrounded || jumpTimer.Finished && !isGrounded)
        {
            falling = true;
            jumping = false;
        }

        //calls check methods
        IsGroundedCheck();
        Clamp();

        //changes animation parameters
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
        _animator.SetBool("IsJumping", jumping);
        _animator.SetBool("IsFalling", falling);

        //checks if player should be flipped
        if (horizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontal < 0 && facingRight)
        {
            Flip();
        }
    }
    void FixedUpdate() {
        MoveCharacter();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Saw") {
            AudioManager.Play(AudioClipName.Died, AudioTypes.SoundEffect);
            EventInvokerUtils.Invoke(EventName.gameOver);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            AudioManager.Play(AudioClipName.Died, AudioTypes.SoundEffect);
            EventInvokerUtils.Invoke(EventName.gameOver);
            Destroy(gameObject);
        }
    }

    void MoveCharacter() {
        //horizontal movement
        _rigidbody2D.velocity = new Vector2(horizontal * speed,_rigidbody2D.velocity.y);

        if (isGrounded && vertical > 0 || !falling && vertical > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jump);
            if (!jumping && !falling)
            {
                jumpTimer.Run();
                jumping = true;
                if (jumpSoundTimer.Finished)
                {
                    AudioManager.Play(AudioClipName.Jump, AudioTypes.SoundEffect);
                    jumpSoundTimer.Run();
                }
                else if (!jumpTimerStarted)
                {
                    AudioManager.Play(AudioClipName.Jump, AudioTypes.SoundEffect);
                    jumpSoundTimer.Run();
                    jumpTimerStarted = true;
                }
            }
        }
    }

    void IsGroundedCheck() {
        if (groundCheck.collider != null)
        {
            isGrounded = true;
            jumping = false;
            falling = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    void Clamp() {
        if (transform.position.x - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            transform.position = new Vector2(ScreenUtils.ScreenLeft + halfColliderWidth, transform.position.y);
        }
        else if(transform.position.x + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            transform.position = new Vector2(ScreenUtils.ScreenRight - halfColliderWidth, transform.position.y);
        }
    }

    void Flip() {
        if (facingRight)
        {
            _spriteRenderer.flipX = true;
            facingRight = false;
        }
        else
        {
            _spriteRenderer.flipX = false;
            facingRight = true;
        }
    }
}
