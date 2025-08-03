using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Player player;
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        Debug.Log("Estado do jogador: " + player.isDead);
        if (player.isDead == false)
        {

            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            transitionAnim.SetTrigger("Start");
            
        }
        else
        {
            transitionAnim.SetTrigger("End");
            yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            transitionAnim.SetTrigger("Start");
            player.isDead = false;
        }

    }
}
