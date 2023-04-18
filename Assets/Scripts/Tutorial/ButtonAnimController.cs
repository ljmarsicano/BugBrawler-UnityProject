using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimController : MonoBehaviour
{
    Animator animator;
    public float state;

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        animator.SetFloat("ButtonState", state);
    }
}
