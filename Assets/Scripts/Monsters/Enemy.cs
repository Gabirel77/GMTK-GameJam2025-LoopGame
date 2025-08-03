using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    private Player jogador;
    public float speed = 1.75f;
    private Vector2 movement;

    private void Awake()
    {
        jogador = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogador.isDead = true;
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            SceneController.instance.NextLevel();
        }
    }
    void Update()
    {
        Vector3 scale = transform.localScale;
        
        if(player.transform.position.x>transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        else 
        {   
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(speed * Time.deltaTime*-1, 0, 0);
        }
    }
}
