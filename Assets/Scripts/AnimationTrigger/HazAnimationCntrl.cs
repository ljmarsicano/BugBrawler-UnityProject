using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazAnimationCntrl : MonoBehaviour
{
    public Animator animator;

    public Haz hazScript;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hazScript = GetComponent<Haz>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hazScript.speed < 0)
        {
            //traveling left
            animator.SetFloat("XInput", 0);
        }
        else
        {
            //traveling right
            animator.SetFloat("XInput", 1);
        }


    }
}
