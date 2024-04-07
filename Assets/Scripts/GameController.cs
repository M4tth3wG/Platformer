using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public int health = 3;
    public int enemiesKilled = 0;
    
    private bool playerIsHurt = false;

    private void Awake()
    {
        if (instance == null)
        {
            health = 3;
            enemiesKilled = 0;
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerIsHurt = false;
    }

    public void PlayerDamaged()
    {
        if (health > 0 && !playerIsHurt)
        {
            health--;
            playerIsHurt = true;
        }

        if (health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
