using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = 3;
        enemiesKilled = 0;
    }

    void Update()
    {
        
    }

    public void PlayerDamaged()
    {
        if (health > 0)
        {
            health--;
            playerIsHurt = true;
        }
    }
}
