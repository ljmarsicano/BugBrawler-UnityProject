using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutSenseiAnimControl : MonoBehaviour
{
    Animator animator;
    public bool arrived, suprise;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        arrived = false;
        suprise = false;
    }

    void Update()
    {
        if (arrived)
        {
            animator.SetBool("Arrived", true);
            arrived = false;
        }

        if (suprise)
        {
            animator.SetBool("Suprise", true);
            suprise = false;
        }
    }
}
