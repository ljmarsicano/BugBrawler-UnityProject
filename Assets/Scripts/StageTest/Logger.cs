using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

//This class functions to create txt documents that control the finite levels
public class Logger : MonoBehaviour
{
    private float timer;

    private void Awake()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float roundedTimer = (Mathf.Round((timer * 100))) / 100;

        //Indicate a normal enemy to spawn on the left
        if (Input.GetButtonDown("Left"))
        {
            WriteString("L" + roundedTimer.ToString());
        }

        //Indicate a normal enemy to spawn on the right
        if (Input.GetButtonDown("Right"))
        {
            WriteString("R" + roundedTimer.ToString());
        }

        //Indicate the beginning of the song
        if (Input.GetKeyDown(KeyCode.P))
        {
            WriteString("P" + roundedTimer.ToString());
        }

        //Indicate the end of the level, and to spawn the final enemy
        if (Input.GetKeyDown(KeyCode.L))
        {
            WriteString("L" + roundedTimer.ToString());
        }
    }

    void WriteString(string input)
    {
        string path = "Assets/Resources/Stage1.txt";

        //Write some text to the .txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(input);
        writer.Close();
    }
}
