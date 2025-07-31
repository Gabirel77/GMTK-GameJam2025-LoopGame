using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public float speed = 5.5f;
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float jumpForce = 6;
    
    // Update is called once per frame
    void Update()
    {
        float moveHorizontally = Input.GetAxis("Horizontal");
        movement.x = moveHorizontally * speed * Time.deltaTime;
        transform.Translate(movement);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        //adiciona impulso ao rigidbody pra pular
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
