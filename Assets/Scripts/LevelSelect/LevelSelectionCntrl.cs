using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionCntrl : MonoBehaviour
{
    public GameObject canvas;

    public Image[,] selectors;

    public string sel;

    Image backSel;

    int row, col;

    private void Awake()
    {
        selectors = new Image[2, 8];
        backSel   = canvas.transform.GetChild(16).gameObject.GetComponent<Image>();
        row = 0;
        col = 0;
        fillSelectors();
        prepareSelectors();
        backSel.enabled = false;
        selectors[row, col].enabled = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Left"))
        {
            if (row != -1)
            {
                selectors[row, col].enabled = false;
                if (col != 0)
                {
                    col--;
                }
                else
                {
                    col = 7;
                }
                selectors[row, col].enabled = true;
            }
        }

        if (Input.GetButtonDown("Right"))
        {
            if (row != -1)
            {
                selectors[row, col].enabled = false;
                if (col != 7)
                {
                    col++;
                }
                else
                {
                    col = 0;
                }
                selectors[row, col].enabled = true;
            }
        }

        if (Input.GetButtonDown("Down"))
        {
            if (row != -1)
            {
                selectors[row, col].enabled = false;
                if (row != 1)
                {
                    row++;
                    selectors[row, col].enabled = true;
                }
                else
                {
                    row = -1;
                    backSel.enabled = true;
                }
            }
            else
            {
                backSel.enabled = false;
                row = 0;
                selectors[row, col].enabled = true;
            }
        }

        if (Input.GetButtonDown("Up"))
        {
            if (row != -1)
            {
                selectors[row, col].enabled = false;
                if (row != 0)
                {
                    row--;
                    selectors[row, col].enabled = true;
                }
                else
                {
                    row = -1;
                    backSel.enabled = true;
                }
            }
            else
            {
                backSel.enabled = false;
                row = 1;
                selectors[row, col].enabled = true;
            }
        }

        if (Input.GetButtonDown("Select"))
        {
            if (row != -1)
            {
                sel = row + "" + col;
                switch (sel)
                {
                    case "00":
                        SceneManagerSF.instance.LoadTutorial();
                        break;
                    case "01":
                        break;
                    case "02":
                        break;
                    case "03":
                        break;
                    case "04":
                        break;
                    case "05":
                        break;
                    case "06":
                        break;
                    case "07":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                    case "16":
                        break;
                    case "17":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.MainMenu);
            }
        }
    }

    void fillSelectors()
    {
        int f = 0;
        for (int i = 0 ; i < 2 ; i++)
        {
            for (int j = 0 ; j < 8 ; j++)
            {
                selectors[i, j] = canvas.transform.GetChild(f).gameObject.GetComponent<Image>();
                f++;
            }
        }
    }

    void prepareSelectors()
    {
        for(int i = 0; i < 2; i++)
        {
            for (int j = 0 ; j < 8 ; j++)
            {
                selectors[i, j].enabled = false;
            }
        }
    }
}
