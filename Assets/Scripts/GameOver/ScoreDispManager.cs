using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDispManager : MonoBehaviour
{
    public GameObject HighScoreDisplay, ScoreDisplay;

    private void Awake()
    {
        HighScoreDisplay.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
        ScoreDisplay.GetComponent<TextMeshProUGUI>().text = "Score: " + PlayerPrefs.GetInt("GameScore").ToString();
    }
}
