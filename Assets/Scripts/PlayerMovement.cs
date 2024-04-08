using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public Transform groundCheck;
    public Transform firePoint;
    public LayerMask groundLayer;
    public Animator animator;
    public GameObject bulletPrefab;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public AudioSource jumpAudio;
    public AudioSource runAudio;

    void Update()
    {
        rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
        animator.SetBool("isMoving", Math.Abs(horizontal) > 0f);
        animator.SetBool("hasJumped", !IsGrounded());

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpingPower);
            OnJumpAudio();
        }

        if (context.canceled && rigidBody.velocity.y > 0f)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0, 180f, 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }

    public void OnJumpAudio()
    {
        jumpAudio.Play();
    }

    public void OnMoveAudio()
    {
        runAudio.Play();
    }

}
