using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    public static int totalScore;

    // Start is called before the first frame update
    void Start()
    {
    totalScore = 0;
    
        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + totalScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.GetComponent<TextMeshProUGUI>().SetText("Score: " + totalScore.ToString());
    }
}
