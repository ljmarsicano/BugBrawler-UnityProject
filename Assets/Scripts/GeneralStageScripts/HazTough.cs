using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazTough : MonoBehaviour
{
    public float speed, limit, stunMax;
    public bool travelingLeft, pulsed, stunned;

    private float stunnedTimer, tempSpeed;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        pulsed = false;
    }

    private void Update()
    {
        if (stunned && stunnedTimer < stunMax)
        {
            stunnedTimer += Time.deltaTime;
            speed = 0;
        }
        else if (stunned && stunnedTimer > stunMax)
        {
            stunned = false;
            speed = tempSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (!pulsed && this.gameObject.GetComponent<HazHealth>().hit)
        {
            //pulse once to the opposite side
            pulsed = true;
            rbody.velocity = Vector2.zero;

            stunned = true;
            stunnedTimer = 0;
            tempSpeed = speed;
        }
        else if (rbody.velocity.x < limit && rbody.velocity.x > -limit && !stunned)
        {
            rbody.AddForce(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().Damage(1);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.tag == "Enemy")
            {
                if (transform.position.y > other.gameObject.transform.position.y)
                {
                    //become child of other
                }
                else if (Mathf.Abs(transform.position.x) > Mathf.Abs(other.gameObject.transform.position.x))
                {
                    //become child of other
                }
            }
        }
    }
}
