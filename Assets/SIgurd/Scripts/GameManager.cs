using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject loseScreen;
    public GameObject winScreen;

    public bool isPlayerDead;
    public void Start()
    {
        Instance = this;
    }

    public void Update()
    {
        if(isPlayerDead)
            loseScreen.SetActive(true);
        if(isPlayerDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
