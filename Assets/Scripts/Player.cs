using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;
    Animator animator;

    [SerializeField]
    float maxVel;

    Vector2 axis;
    bool btnJump;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rigidBody2D.AddForce(Vector2.right * axis.x * moveSpeed, ForceMode2D.Impulse);
        Vector2 currentVelocity = rigidBody2D.velocity;
        rigidBody2D.velocity = new Vector2(Mathf.Clamp(currentVelocity.x, -maxVel, maxVel), currentVelocity.y);
        //jumping
        if(btnJump)
        {
            rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        btnJump = Input.GetButtonDown("Jump");
    }

    void LateUpdate()
    {
        spriteRenderer.flipX = axis.x < 0 ? true : axis.x > 0 ? false : spriteRenderer.flipX;
        animator.SetFloat("axisX", Mathf.Abs(axis.x));
    }
}
