using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;
    Animator animator;

    [SerializeField]
    float maxVel;
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
    void Update()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //transform.Translate(Vector2.right * axis.x * moveSpeed * Time.deltaTime);
        spriteRenderer.flipX = axis.x < 0 ? true : axis.x > 0 ? false : spriteRenderer.flipX; 
        rigidBody2D.AddForce(Vector2.right * axis.x * moveSpeed, ForceMode2D.Impulse);
        Vector2 currentVelocity = rigidBody2D.velocity;
        rigidBody2D.velocity = new Vector2(Mathf.Clamp(currentVelocity.x, -maxVel, maxVel), currentVelocity.y);
        animator.SetFloat("axisX", Mathf.Abs(axis.x));
    }
}
