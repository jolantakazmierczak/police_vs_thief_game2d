using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CopScore : MonoBehaviour
{

    public static int copScore = 0;

    private TextMeshProUGUI theText;

    void Start()
    {
        theText = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        theText.text = "" + copScore;

    }
}
