using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_HazAnimCntrl : MonoBehaviour
{
    public Animator animator;
    HazTough hazCode;
    public bool pulsed, goingLeft, stunned;

    private void Awake()
    {
        animator  = GetComponent<Animator>();
        hazCode   = GetComponent<HazTough>();

        pulsed    = false;
        stunned   = false;
        goingLeft = false;
    }

    private void Update()
    {
        pulsed    = hazCode.pulsed;
        stunned   = hazCode.stunned;
        goingLeft = hazCode.travelingLeft;

        //These can probably be optimized, if it effects performance, optimize it
        if (goingLeft)
        {
            animator.SetFloat("XInput", 0);
        }
        else
        {
            animator.SetFloat("XInput", 1);
        }

        if (pulsed)
        {
            animator.SetBool("FirstHit", true);
        }
        else
        {
            animator.SetBool("FirstHit", false);
        }

        if (stunned)
        {
            animator.SetBool("StunDone", false);
        }
        else
        {
            animator.SetBool("StunDone", true);
        }
    }
}
