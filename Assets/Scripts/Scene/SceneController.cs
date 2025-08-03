using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Player player;
    public AudioSource soundtrack;
    public AudioClip[] musicTracks;
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;
    private void Awake()
    {
        soundtrack.clip = musicTracks[0];
        soundtrack.Play();
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
        if (SceneManager.GetActiveScene().buildIndex < 3 && soundtrack.clip != musicTracks[0])
        {
            soundtrack.clip = musicTracks[0];
            soundtrack.Play();
        }
        /*if (SceneManager.GetActiveScene().buildIndex >=3 && SceneManager.GetActiveScene().buildIndex < 12 && soundtrack.clip != musicTracks[1])
        {
            soundtrack.clip = musicTracks[1];
            soundtrack.Play();
        }*/
        if (SceneManager.GetActiveScene().buildIndex >= 12 && soundtrack.clip != musicTracks[2])
        {
            soundtrack.clip = musicTracks[2];
            soundtrack.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex >= 23 && soundtrack.clip != musicTracks[3])
        {
            soundtrack.clip = musicTracks[3];
            soundtrack.Play();
        }


        player = GameObject.Find("Player").GetComponent<Player>();
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
