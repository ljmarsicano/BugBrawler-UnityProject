using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazDeathAnim : MonoBehaviour
{
    public Animator animator;
    public bool travLeft;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
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

    void kill()
    {
        Destroy(this.gameObject);
    }
}
