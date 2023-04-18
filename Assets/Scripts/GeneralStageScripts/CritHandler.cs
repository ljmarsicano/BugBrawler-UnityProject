using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritHandler : MonoBehaviour
{
    public GameObject critObjR, critObjL, critIndObj, scoreDetector;

    BoxCollider2D critR, critL;

    CritFunction critFuncR, critFuncL;

    SpriteRenderer critInd;

    ScoreCollector scoreCollector;

    public float timer, target;

    bool crit;

    private void Awake()
    {
        critInd = critIndObj.GetComponent<SpriteRenderer>();
        critR   = critObjR.GetComponent<BoxCollider2D>();
        critL   = critObjL.GetComponent<BoxCollider2D>();
        critFuncR = critObjR.GetComponent<CritFunction>();
        critFuncL = critObjL.GetComponent<CritFunction>();
        scoreCollector = scoreDetector.GetComponent<ScoreCollector>();

        timer = 0;
        crit = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Right"))
        {
            if (critFuncR.crit == true)
            {
                crit = true;
                critInd.enabled = true;
                timer = 0;
                scoreCollector.score++;
            }
        }

        if (Input.GetButtonDown("Left"))
        {
            if (critFuncL.crit == true)
            {
                crit = true;
                critInd.enabled = true;
                timer = 0;
                scoreCollector.score++;
            }
        }

        if (crit && timer < target)
        {
            timer += Time.deltaTime;
        }
        else if (crit && timer > target)
        {
            timer = 0;
            crit = false;
            critInd.enabled = false;
        }
        else
        {
            critInd.enabled = false;
        }
    }
}
