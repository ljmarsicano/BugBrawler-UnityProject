using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUICntrl : MonoBehaviour
{
    public GameObject UI, player;
    public int highscore;

    private TextMeshProUGUI dialouge;
    private ScoreCollector scoreDet;
    private int comboTmp, playerHealth;
    private GameObject scoreDisp, combDisp, h1, h2, h3;

    private void Awake()
    {
        scoreDet = transform.GetChild(0).gameObject.GetComponent<ScoreCollector>();
        scoreDisp = UI.transform.GetChild(1).gameObject;
        combDisp = UI.transform.GetChild(2).gameObject;
        h1 = UI.transform.GetChild(3).gameObject;
        h2 = UI.transform.GetChild(4).gameObject;
        h3 = UI.transform.GetChild(5).gameObject;
        dialouge = UI.transform.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>();

        dialouge.SetText("");
        PlayerPrefs.SetInt("GameScore", 0);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Debug"))
        {
            Debug.Log(PlayerPrefs.GetInt("highscore").ToString() + " and " + PlayerPrefs.GetInt("GameScore").ToString());
        }

        comboTmp = player.GetComponent<PlayerStrike>().combo;
        playerHealth = player.GetComponent<PlayerHealth>().health;

        scoreDisp.GetComponent<TextMeshProUGUI>().SetText(scoreDet.score.ToString());
        combDisp.GetComponent<TextMeshProUGUI>().SetText(comboTmp.ToString());

        if (comboTmp >= 10)
        {
            UI.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Bold;
            UI.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            UI.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().fontStyle = TMPro.FontStyles.Normal;
            UI.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().color = new Color(255, 255, 255, 255);
        }

        if (playerHealth == 2)
        {
            h1.SetActive(false);
        }
        else if (playerHealth == 1)
        {
            h2.SetActive(false);
        }
        else if (playerHealth == 0)
        {
            PlayerPrefs.SetInt("GameScore", scoreDet.score);
            h3.SetActive(false);
        }

        if (PlayerPrefs.GetInt("highscore") <= scoreDet.score)
        {
            PlayerPrefs.SetInt("highscore", scoreDet.score);
        }
        highscore = PlayerPrefs.GetInt("highscore");
    }

    public void setDialouge(string dialougeText)
    {
        dialouge.SetText(dialougeText);
    }
}