using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;
    private Player jogador;
    private void Awake()
    {
        jogador = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jogador.isDead = true;
            Debug.Log("Player is:" +  jogador.isDead);
            //player.SetActive(false); se eu usar isso nao consigo acessar os isDead do player mais
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Collider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            SceneController.instance.NextLevel(); 
        }
    }

}
