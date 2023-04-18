using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameMasterAllStages : MonoBehaviour
{
    public GameObject leftSpawn, rightSpawn, enemy;
    public List<string> timeIn;
    public List<char> dirIn;

    public string songName;
    public float enemySpeed, velocityLimit, songDelay;

    private AudioManager audMan;

    private string currTimeFound;
    private float timer, roundedTimer, songTimer;
    private bool songStarted, waiting;

    private void Awake()
    {
        timer = 0;
        songTimer = 0;
        roundedTimer = 0;
        currTimeFound = "0.00";
        songStarted = false;
        waiting = true;
        audMan = this.gameObject.GetComponent<AudioManager>();
        TextToArray();
    }

    void Update()
    {
        timer += Time.deltaTime;
        roundedTimer = (Mathf.Round((timer * 100))) / 100;

        if (!songStarted && !waiting && songTimer < songDelay)
        {
            songTimer += Time.deltaTime;
        }
        else if (!songStarted && !waiting && songTimer > songDelay)
        {
            songStarted = true;
            audMan.Play(songName);
        }

        if (timeIn.Contains(roundedTimer.ToString()) && roundedTimer.ToString() != currTimeFound)
        {
            GameObject nuEnemy;

            currTimeFound = roundedTimer.ToString();
            int ind = timeIn.IndexOf(roundedTimer.ToString());
            if (dirIn[ind] == 'L')
            {
                //spawn left
                nuEnemy = Instantiate(enemy, leftSpawn.transform.position, Quaternion.identity);
                nuEnemy.GetComponent<Haz>().speed = enemySpeed;
                nuEnemy.GetComponent<Haz>().limit = velocityLimit;
            }
            else if (dirIn[ind] == 'R')
            {
                //spawn right
                nuEnemy = Instantiate(enemy, rightSpawn.transform.position, Quaternion.identity);
                nuEnemy.GetComponent<Haz>().speed = -enemySpeed;
                nuEnemy.GetComponent<Haz>().limit = velocityLimit;
            }
            else if (dirIn[ind] == 'P')
            {
                Debug.Log("BEGIN");
            }
            waiting = false;
        }
    }

    void TextToArray()
    {
        string strIn;
        string path = "Assets/Resources/" + songName + ".txt";

        StreamReader reader = new StreamReader(path);

        strIn = reader.ReadLine();

        while (strIn != null)
        {
            dirIn.Add(strIn[0]);
            timeIn.Add(strIn.Substring(1, strIn.Length - 1));
            strIn = reader.ReadLine();
        }

        reader.Close();
    }
}
