using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeManager : MonoBehaviour
{

    public float startingTime;
    private float countingTime;

    private TextMeshProUGUI theText;


    public GameObject timeOutScreen;




    void Start()
    {
        theText = gameObject.GetComponent<TextMeshProUGUI>();
        countingTime = startingTime;

    }


    void Update()
    {



        if(countingTime >= 0)
        {
            countingTime -= Time.deltaTime;

        }


        if (Mathf.Round(countingTime) <= 0)
        {
            

            timeOutScreen.SetActive(true);
            // NextLevel();
            Invoke("NextLevel", 3f);

        }


        if (countingTime == 0)
        {
            ThiefScore.thiefScore += 1;
        }



        theText.text = "" + Mathf.Round(countingTime);




    }

    public void AddPoint()
    {
        ThiefScore.thiefScore += 1;
    }    
    
    public void ResetTime()
    {
        countingTime = startingTime;
    }

    void NextLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
        // ThiefScore.thiefScore += 1;


    }
}
