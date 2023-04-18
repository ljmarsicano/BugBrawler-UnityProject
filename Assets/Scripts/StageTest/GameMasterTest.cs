using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class GameMasterTest : MonoBehaviour
{
    public GameObject leftSpawn, rightSpawn, enemy;
    public string songName;
    public float enemySpeed, velocityLimit;


    public List<string> timeIn;
    public List<char> dirIn;

    private AudioManager audMan;

    private string currTimeFound;
    
    private float timer, roundedTimer;

    private void Awake()
    {
        timer         = 0;
        roundedTimer  = 0;
        currTimeFound = "0.00";
        audMan = this.gameObject.GetComponent<AudioManager>();
        TextToArray();
    }

    void Update()
    {
        timer += Time.deltaTime;
        roundedTimer = (Mathf.Round((timer * 100))) / 100;

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
            Debug.Log("SPAWNED");
        }
    }

    void TextToArray()
    {
        string strIn;
        string path = "Assets/Resources/" + songName;

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
