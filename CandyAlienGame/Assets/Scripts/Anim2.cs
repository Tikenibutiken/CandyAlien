using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Anim2 : MonoBehaviour
{
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Animator SlimeBob_5;
    public Animator Stage2;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        SlimeBob_5 = GetComponent<Animator>();

        // Rename Animator controllers method names to avoid naming conflicts
        Stage2.SetFloat("MoveSpeed", 0);
        Stage2.SetFloat("JumpSpeed", 0);
        Stage2.SetFloat("VerticalSpeed", 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            SlimeBob_5.SetTrigger("is_jumping");
        }

        //Animation
        if (dirX != 0)
            SlimeBob_5.SetBool("is_walking", true);
        else
            SlimeBob_5.SetBool("is_walking", false);

        //Sprite Flipping
        if (dirX == -1)
        {
            sprite.flipX = true;
        }
        else if (dirX == 1)
        {
            sprite.flipX = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}

public class AnimatorController : MonoBehaviour
{
    public Animator SlimeBob_5;
    public Animator Stage2;

    [SerializeField] private Movement movementScript;

    // Start is called before the first frame update
    void Start()
    {
        // Rename Movement script method names to avoid naming conflicts
        movementScript.Stage2 = Stage2;
        movementScript.SlimeBob_5 = SlimeBob_5;
        Stage2.SetFloat("MoveSpeed", 0);
        Stage2.SetFloat("JumpSpeed", 0);
        Stage2.SetFloat("VerticalSpeed", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveSpeed = Input.GetAxisRaw("Horizontal");
        float jumpSpeed = Input.GetAxisRaw("Jump");
        Stage2.SetFloat("MoveSpeed", Mathf.Abs(moveSpeed));
        Stage2.SetFloat("JumpSpeed", jumpSpeed);
        Stage2.SetFloat("VerticalSpeed", movementScript.rb.velocity.y);
    }
}