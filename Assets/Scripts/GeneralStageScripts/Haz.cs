using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haz : MonoBehaviour
{
    public float speed, limit;

    private bool isChild;

    private GameObject parent;

    private Rigidbody2D rbody;

    private void Awake()
    {
        isChild = false;
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (parent == null)
        {
            isChild = false;
        }
        if (isChild)
        {
            if (speed < 0)
            {
                transform.position = new Vector3(parent.transform.position.x + 1.2f, parent.transform.position.y, parent.transform.position.z);
            }
            else
            {
                transform.position = new Vector3(parent.transform.position.x - 1.2f, parent.transform.position.y, parent.transform.position.z);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isChild)
        {
            if (rbody.velocity.x < limit && rbody.velocity.x > -limit && !isChild)
            {
                rbody.AddForce(Vector2.right * speed * Time.deltaTime);
            }
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
            if (transform.position.y > other.gameObject.transform.position.y)
            {
                //become child of other
                parent = other.gameObject;
                isChild = true;
            }
            else if (Mathf.Abs(transform.position.x) > Mathf.Abs(other.gameObject.transform.position.x))
            {
                //become child of other
                parent = other.gameObject;
                isChild = true;
            }
        }
    }
}
