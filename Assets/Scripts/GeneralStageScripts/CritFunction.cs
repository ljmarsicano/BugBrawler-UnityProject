using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritFunction : MonoBehaviour
{
    public bool crit;

    private void Awake()
    {
        crit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Crit")
        {
            crit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Crit")
        {
            crit = false;
        }
    }
}
