using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using TMPro;

public class SenseiStickCntrl : MonoBehaviour
{
    public GameObject gmTut, blurb;

    public float speed, limit;

    Rigidbody2D rbody;

    bool arrived;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        arrived = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!arrived)
        {
            if (rbody.velocity.x < limit && rbody.velocity.x > -limit)
            {
                rbody.AddForce(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            rbody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stop")
        {
            Destroy(collision.gameObject);
            arrived = true;

            this.GetComponent<Rigidbody2D>().simulated = false;
            this.GetComponent<BoxCollider2D>().enabled = false;

            blurb.GetComponent<Image>().enabled = true;

            gmTut.GetComponent<GameMasterTutorial>().state++;
            gmTut.GetComponent<GameMasterTutorial>().setDiaOption(0);

            this.gameObject.GetComponent<TutSenseiAnimControl>().arrived = true;
        }
    }
}
