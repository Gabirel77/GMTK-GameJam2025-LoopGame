using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    private float speed = 3.2f;
    public Vector2 movement;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 6;

    
    // Update is called once per frame
    void Update()
    {
        float moveHorizontally = Input.GetAxis("Horizontal");
        movement.x = moveHorizontally * speed * Time.deltaTime;
        transform.Translate(movement);
        
        if (Input.GetButtonDown("Jump")&& GetIsGrounded())
        {
            Jump();
        }
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.8f, LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        //adiciona impulso ao rigidbody pra pular
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
