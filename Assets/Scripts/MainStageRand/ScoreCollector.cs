using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public int score;

    private void Awake()
    {
        score = 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<HazHealth>().killed == true)
            {
                score++;
            }
        }
    }
}
