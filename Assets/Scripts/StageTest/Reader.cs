using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Reader : MonoBehaviour
{
    public List<string> timeIn;
    public List<char> dirIn;
    private float timer;
    public float roundedTimer;
    private string currTimeFound;

    private void Awake()
    {
        timer = 0;
        currTimeFound = "0.00";
        timeIn = new List<string>();
        dirIn = new List<char>();
        TextToArray();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        roundedTimer = (Mathf.Round((timer * 100))) / 100;

        if (timeIn.Contains(roundedTimer.ToString()) && roundedTimer.ToString() != currTimeFound)
        {
            currTimeFound = roundedTimer.ToString();
            int ind = timeIn.IndexOf(roundedTimer.ToString());
            Debug.Log(dirIn[ind] + " at " + timeIn[ind]);
        }
    }

    void TextToArray()
    {
        string strIn;
        string path = "Assets/Resources/Beats.txt";

        //Read the text from directly from the test.txt file
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
