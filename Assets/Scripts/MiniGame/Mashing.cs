using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mashing : MonoBehaviour
{
    public float timer, target, targetEnemy, targetEnemyDesp;

    private SpriteRenderer go, ready;

    public int score;

    private float goTimer, goTarget, finTimer, finTarget;

    private bool timerDone, goActive, win, finActivate;

    private void Awake()
    {
        timerDone = false;
        goActive = false;
        win = false;
        finActivate = false;

        //Target is refering to what the timer is set to hit
        timer = 0;
        goTimer = 0;
        goTarget = 1;
        finTimer = 0;
        finTarget = 5;
        score = 20;

        go = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        ready = this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();

        go.enabled = false;
        ready.enabled = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        //The 'Ready!?' Portion is over, enable the 'GO!' portion
        if (timer > target && !timerDone)
        {
            ready.enabled = false;
            go.enabled = true;
            goActive = true;
            timerDone = true;
        }

        //This is happening during the active game phase, just letting go sit there
        if (goActive == true && goTimer < goTarget)
        {
            goTimer += Time.deltaTime;
        }
        else
        {
            go.enabled = false;
            goActive = false;
        }

        //Game is active, begin whatever it is
        if (timerDone)
        {
            if (score < 35 && timer > targetEnemy)
            {
                timer = 0;
                score--;
            }
            else if (score >= 35 && timer > targetEnemyDesp)
            {
                timer = 0;
                score--;
            }

            if (Input.GetButtonDown("Select"))
            {
                score++;
            }
        }


        //Game is finished, wait a moment to go to the next screen
        if (score <= 0 && !finActivate)
        {
            Debug.Log("You Lose!");
            win = false;
            finActivate = true;
        }
        if (score >= 40 && !finActivate)
        {
            Debug.Log("You win!");
            win = true;
            finActivate = true;
        }

        if (finActivate && finTimer < finTarget)
        {
            finTimer += Time.deltaTime;
        }
        else
        {
            if (win)
            {
                Debug.Log("Move on to win screen");
            }
            else
            {
                Debug.Log("Move on to lsoing screen");
            }
        }
    }
}
