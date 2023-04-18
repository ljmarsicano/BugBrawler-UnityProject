using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOarrowManager : MonoBehaviour
{
    public GameObject rArrow, mArrow;

    private bool left;

    private void Awake()
    {
        rArrow.SetActive(true);
        mArrow.SetActive(false);
        left = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right"))
        {
            if (left)
            {
                left = !left;
                rArrow.SetActive(false);
                mArrow.SetActive(true);
            }
            else
            {
                left = !left;
                rArrow.SetActive(true);
                mArrow.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Select"))
        {
            if (left)
            {
                SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.MainStageRand);
            }
            else
            {
                SceneManagerSF.instance.LoadMainMenu();
            }
        }
    }
}
