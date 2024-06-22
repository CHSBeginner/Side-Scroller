using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpForce = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    private Animator animator;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void SpriteFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            SpriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            SpriteRenderer.flipX = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            Debug.Log("Jump!");
            PlayJump();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalinput * speed * Time.deltaTime, 0f, 0f));
        SpriteFlip(horizontalinput);

       
    }

    #region Animationhandler
    private void PlayWalk()
    {
        animator.SetTrigger("GoWalk");
    }

    private void PlayJump()
    {
        animator.SetTrigger("GoJump");
    }
    #endregion
}
