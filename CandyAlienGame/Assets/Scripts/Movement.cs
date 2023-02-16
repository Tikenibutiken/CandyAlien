using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    public Animator SlimeBob_5;




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

    }
    private void Update()
    {
        Move();
    }
    // Update is called once per frame
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
        if (dirX != 0) SlimeBob_5.SetBool("is_walking", true);
        else SlimeBob_5.SetBool("is_walking", false);

        //Sprite Flipping
        if (dirX == -1)
            sprite.flipX = true;
        else if (dirX == 1)
            sprite.flipX = false;


    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }



    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public float jumpSpeed = 8f;
        private float direction = 0f;
        private Rigidbody2D player;

        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask groundLayer;
        private bool isTouchingGround;

        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal");

            if (direction > 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
            }
            else if (direction < 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
          
            
            
            
            }
        }


    }
}