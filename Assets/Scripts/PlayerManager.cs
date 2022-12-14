using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;

    private TimeManager theTime;
    void Awake()
    {
        isGameOver = false;

    }    
    
    void Start()
    {
        theTime = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            theTime.ResetTime();
            Invoke("NextLevel", 3f);

        }
    }


    void NextLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

}
