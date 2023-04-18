using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    public Animator animator;

    public int state;
    public bool facingRight, waiting;
    public float waitEnd, waitCurr;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        state = 0;
        waitEnd = 1;
        waitCurr = 0;
    }

    void Update()
    {
        waitClock();

       if (Input.GetButtonDown("Left"))
       {
            switch (state)
            {
                //Idle
                case 0:
                    animator.SetBool("Attack", true);
                    animator.SetFloat("XInput", 0);
                    state = 1;
                    facingRight = false;

                    waiting = true;
                    waitCurr = 0;

                    break;
                //Attacking
                case 1:
                    break;
                //IdleProne
                case 2:
                    if (!facingRight)
                    {
                        animator.SetBool("ProneAttack", true);
                        state = 3;
                    }
                    else
                    {
                        animator.SetBool("SwitchAttack", true);
                        //animator.SetFloat("XInput", 0);
                        facingRight = false;
                        state = 4;
                    }

                    waiting = true;
                    waitCurr = 0;

                    break;
                //ProneAttack
                case 3:
                    break;
                //GettingUp
                case 4:
                    break;
                //SwitchAttack
                case 5:
                    break;
                default:
                    break;
            }
       }

       if (Input.GetButtonDown("Right"))
       {
            switch (state)
            {
                case 0:
                    animator.SetBool("Attack", true);
                    animator.SetFloat("XInput", 1);
                    state = 1;
                    facingRight = true;

                    waiting = true;
                    waitCurr = 0;

                    break;
                case 1:
                    break;
                case 2:
                    if (facingRight)
                    {
                        animator.SetBool("ProneAttack", true);
                        state = 3;
                    }
                    else
                    {
                        animator.SetBool("SwitchAttack", true);
                        //animator.SetFloat("XInput", 1);
                        facingRight = true;
                        state = 4;
                    }

                    waiting = true;
                    waitCurr = 0;

                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        switch (state)
        {
            case 0:
                waiting = false;
                break;
            case 1:
                state = 2;
                break;
            case 2:
                break;
            case 3:
                state = 2;
                break;
            case 4:
                state = 2;
                break;
            case 5:
                state = 0;
                break;
            default:
                break;
        }
    }

    public void waitClock()
    {
        if (waiting)
        {
            if (waitCurr > waitEnd)
            {
                //send to next state
                animator.SetBool("Waited", true);
                state = 5;
                waiting = false;
            }
            else
            {
                waitCurr += Time.deltaTime;
            }
        }
    }
    
}
