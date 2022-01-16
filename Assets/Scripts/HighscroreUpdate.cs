using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscroreUpdate : MonoBehaviour
{
    void Start()
    {
        var highscore = PlayerPrefs.GetInt("HighScore." + DateTime.Today.ToShortDateString());
        if (highscore > 0)
        {
            GetComponent<TextMeshProUGUI>().SetText("High score: " + (int) highscore + " pts");
        }
        else
        {
            GetComponent<TextMeshProUGUI>().SetText("No high score for today!");
        }
    }
    
    void Update()
    {
        
    }
}
