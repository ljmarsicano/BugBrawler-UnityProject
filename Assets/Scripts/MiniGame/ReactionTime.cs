using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTime : MonoBehaviour
{
    public float timer, target, sliceTarget;

    private SpriteRenderer go, ready;

    private float goTimer, goTarget, finTimer, finTarget, readyTarget, sliceTime;

    private bool timerDone, goActive, win, finActivate, attackDone;

    private void Awake()
    {
        timerDone = false;
        goActive = false;
        win = false;
        finActivate = false;
        attackDone = false;

        //Target is refering to what the timer is set to hit
        timer = 0;
        readyTarget = Random.Range(0f, 5f) + target;
        goTimer = 0;
        goTarget = 1;
        finTimer = 0;
        finTarget = 5;

        go    = this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        ready = this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();

        go.enabled = false;
        ready.enabled = true;
    }

    void Update()
    {
        timer += Time.deltaTime;

        //The 'Ready!?' Portion is over, enable the 'GO!' portion
        if (timer > readyTarget && !timerDone)
        {
            ready.enabled = false;
            go.enabled = true;
            goActive = true;
            timerDone = true;
            timer = 0;
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
            if (Input.GetButtonDown("Select"))
            {
                sliceTime = timer;
                Debug.Log(sliceTime);
                attackDone = true;
            }
            if (timer > 5)
            {
                win = false;
                attackDone = true;
            }
        }


        //Game is finished, determine results are a win or loss, then wait a moment to go to the next screen
        if (!finActivate && attackDone && sliceTime <= sliceTarget)
        {
            Debug.Log("You win!");
            win = true;
            finActivate = true;
        }
        if (!finActivate && attackDone && sliceTime > sliceTarget)
        {
            Debug.Log("You lose!");
            win = false;
            finActivate = true;
        }

        if (finActivate && finTimer < finTarget)
        {
            finTimer += Time.deltaTime;
        }
        else if (finActivate && finTimer >= finTarget)
        {
            if (win)
            {
                Debug.Log("Move on to win screen");
            }
            else
            {
                Debug.Log("Move on to losing screen");
            }
        }
    }
}
