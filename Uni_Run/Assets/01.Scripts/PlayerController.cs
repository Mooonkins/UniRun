using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    public AudioClip deathClip;
    private Rigidbody2D playerRgd;
    private Animator animator;
    private AudioSource playerAudio;

    void Start()
    {
        
        playerRgd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
 
    void Update()
    {
        if (isDead) return;        
        else
        {
            if (Input.GetMouseButtonDown(0) && jumpCount < 2)
            {
                jumpCount++;

                playerRgd.velocity = Vector2.zero;
                playerRgd.AddForce(new Vector2(0, jumpForce));
                playerAudio.Play();
            }
            else if (Input.GetMouseButtonUp(0) && playerRgd.velocity.y > 0)
            {
                playerRgd.velocity = playerRgd.velocity * 0.5f;
            }
            animator.SetBool("Grounded", isGrounded);
        }
    }
    private void Die()
    {
        animator.SetTrigger("Die");
        
        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRgd.velocity = Vector2.zero;

        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Dead") && !isDead)
        {
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
