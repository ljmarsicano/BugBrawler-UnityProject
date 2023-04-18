using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazTest : MonoBehaviour
{
    public float speed, limit, jump;
    public bool travelingLeft;

    private bool pulsed, unlock, changed, isChild;
    private float xHit;
    public int jmpIndex;
    private Transform ray;
    private Rigidbody2D rbody;

    private GameObject parent;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        pulsed = false;
        unlock = false;
        changed = false;
        isChild = false;
        jmpIndex = 0;

        parent = null;
        ray = transform.GetChild(0);
    }

    private void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if (parent == null)
        {
            isChild = false;
        }

        if (unlock && !isChild)
        {
            if (x > xHit || x < -xHit)
            {
                transform.position = new Vector3(x, -1.5f, z);
            }
            else
            {
                transform.position = new Vector3(x, -((x / (xHit / 2f)) * (x / (xHit / 2f))) + 4, z);
            }
        }
        else if (isChild)
        {
            if (!travelingLeft)
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
        int layerMask = 1 << 7;

        RaycastHit2D touchFloor = Physics2D.Raycast(ray.position, transform.TransformDirection(Vector2.down), 0.1f, layerMask);
        Debug.DrawRay(ray.position, transform.TransformDirection(Vector2.down * 0.1f), Color.red);

        if (!isChild)
        {
            if (!pulsed && this.gameObject.GetComponent<HazHealth>().hit)
            {
                pulsed = true;

                //Parabola
                unlock = true;
                xHit = Mathf.Abs(transform.position.x);

            }
            else if (rbody.velocity.x < limit && rbody.velocity.x > -limit)
            {
                rbody.AddForce(Vector2.right * speed * Time.deltaTime);
            }

            if (touchFloor.collider != null && jmpIndex == 0)
            {
                //first touch when spawning in the air
                jmpIndex = 1;
            }
            if (touchFloor.collider == null && jmpIndex == 1)
            {
                //Leaving the floor
                jmpIndex = 2;

                limit *= 2;
                speed *= 2;

            }
            if (jmpIndex == 2 && !changed && touchFloor.collider != null)
            {
                //Second touch after traveling over the player
                rbody.velocity = Vector2.zero;
                changed = true;
                speed = -speed;
                unlock = false;
                travelingLeft = !travelingLeft;
                jmpIndex = 3;

                limit /= 2;
                speed /= 2;
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
