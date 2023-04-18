using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class Fixer : MonoBehaviour
{
    public List<string> timeIn;
    public List<char> dirIn;

    private float tmp;

    private void Awake()
    {
        timeIn = new List<string>();
        dirIn = new List<char>();
        TextToArray();

        for (int i = 0 ; i < 407 ; i++)
        {
            tmp = float.Parse(timeIn[i]) - 10f;
            WriteString(dirIn[i].ToString() + tmp.ToString());
        }
    }

    void TextToArray()
    {
        string strIn;
        string path = "Assets/Resources/DontStop.txt";

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

    void WriteString(string input)
    {
        string path = "Assets/Resources/Nu.txt";

        //Write some text to the .txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(input);
        writer.Close();
    }
}
