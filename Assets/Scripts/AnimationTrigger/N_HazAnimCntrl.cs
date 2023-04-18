using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N_HazAnimCntrl : MonoBehaviour
{
    public Animator animator;

    public HazTest nHazCode;

    bool travLeft;

    int jumpIndex;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        nHazCode = GetComponent<HazTest>();
    }

    void Update()
    {
        travLeft = nHazCode.travelingLeft;
        jumpIndex = nHazCode.jmpIndex;

        if (jumpIndex <= 1)
        {
            if (travLeft)
            {
                animator.SetFloat("XInput", 0);
            }
            else
            {
                animator.SetFloat("XInput", 1);
            }
        }

        if (jumpIndex == 2)
        {
            animator.SetBool("FirstHit", true);
        }

        if (jumpIndex == 3)
        {
            animator.SetBool("FirstHit", false);
            if (travLeft)
            {
                animator.SetFloat("XInput", 0);
            }
            else
            {
                animator.SetFloat("XInput", 1);
            }
            animator.SetBool("HitGround", true);
        }
    }
}
