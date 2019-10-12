using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForce;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;
    Animator animator;
    AudioSource audioSource;

    [SerializeField]
    float maxVel;

    Vector2 axis;
    bool btnJump;

    [SerializeField]
    float rayDistance;
    
    [SerializeField]
    LayerMask groundLayer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //Gamemanager.instance.Player = this;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Move
        rigidBody2D.AddForce(Vector2.right * axis.x * moveSpeed, ForceMode2D.Impulse);
        Vector2 currentVelocity = rigidBody2D.velocity;
        rigidBody2D.velocity = new Vector2(Mathf.Clamp(currentVelocity.x, -maxVel, maxVel), currentVelocity.y);

        //grounding
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            -transform.up, 
            rayDistance,
            groundLayer
        );

        if(hit.collider)
        {
            //jumping
            if(btnJump)
            {
                rigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                animator.SetTrigger("jump");
            }
        }
        animator.SetBool("grounding", hit.collider);
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

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * rayDistance);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("coin"))
        {
            Coin coin = collider2D.gameObject.GetComponent<Coin>();
            Gamemanager.instance.GetScore.AddPoints(coin.Points);
            Destroy(collider2D.gameObject);
            audioSource.PlayOneShot(Gamemanager.instance.CoinSound, 7f);
        }   
        if(collider2D.gameObject.CompareTag("death"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("level01");
        } 
        if(collider2D.gameObject.CompareTag("end"))
        {
            Debug.Log("Level ended");
        }
    }
}
