using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public GameObject arrowPlay, arrowLevel, arrowSetting, arrowQuit;

    private GameObject[] arrows;

    private int current, menuOptions;

    private void Awake()
    {
        menuOptions = 4;
        current = 0;

        arrows = new GameObject[menuOptions];

        arrows[0] = arrowPlay;
        arrows[1] = arrowLevel;
        arrows[2] = arrowSetting;
        arrows[3] = arrowQuit;

        arrows[0].SetActive(true);
        arrows[1].SetActive(false);
        arrows[2].SetActive(false);
        arrows[3].SetActive(false);
    }

    private void next()
    {
        arrows[current].SetActive(false);

        if (current == menuOptions - 1)
        {
            current = 0;
        }
        else
        {
            current++;
        }

        arrows[current].SetActive(true);
    }

    private void last()
    {
        arrows[current].SetActive(false);

        if (current == 0)
        {
            current = menuOptions - 1;
        }
        else
        {
            current--;
        }

        arrows[current].SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Down"))
        {
            next();
        }
        
        if (Input.GetButtonDown("Up"))
        {
            last();
        }

        if (Input.GetButtonDown("Select"))
        {
            switch (current)
            {
                case 0:
                    SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.MainStageRand);
                    break;
                case 1:
                    SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.LevelSelect);
                    break;
                case 2:
                    Debug.Log("Settings");
                    break;
                case 3:
                    Debug.Log("Quit");
                    break;
                default:
                    Debug.Log("Default");
                    break;
            }
        }
    }
}
