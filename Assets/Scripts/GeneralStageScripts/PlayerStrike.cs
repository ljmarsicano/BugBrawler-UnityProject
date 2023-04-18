using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAKE CHARACTER IMMUNE WHEN MOVING
public class PlayerStrike : MonoBehaviour
{
    public float speed,pTimeMax, bTimeMax, cTimeMax;
    public int combo;
    public GameObject penaltyInd, blastBox, mainCam, scoreDetector, endGame, levelCanvas;

    private float pTime, bTime, cTime;
    private bool rightPressed, leftPressed, blastPressed, penalty, blasted, cam;
    private Rigidbody2D rbody;
    private Transform rayRight, rayLeft;
    private ScoreCollector scoreCollector;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        combo = 0;
        rightPressed = false;
        leftPressed  = false;
        penalty = false;
        penaltyInd.GetComponent<SpriteRenderer>().enabled = false;
        blastBox.GetComponent<SpriteRenderer>().enabled = false;
        blastBox.GetComponent<BoxCollider2D>().enabled = false;
        scoreCollector = scoreDetector.GetComponent<ScoreCollector>();

        rayRight = transform.GetChild(0);
        rayLeft = transform.GetChild(1);
    }

    void Update()
    {
        if (Input.GetButtonDown("Left") && !leftPressed)
        {
            leftPressed = true;
        }

        if (Input.GetButtonDown("Right") && !rightPressed)
        {
            rightPressed = true;
        }

        if (Input.GetButtonDown("Jump") && !blastPressed)
        {
            blastPressed = true;
        }

        PenaltyTimer();
        BlastTimer();
        CamTimer();
    }

    private void FixedUpdate()
    {
        //rbody.velocity = Vector2.zero;
        rbody.position = new Vector3(0,-0.24f,0);
        int layerMask = 1 << 6;

        RaycastHit2D hitRight = Physics2D.Raycast(rayRight.position, transform.TransformDirection(Vector2.right), 3.5f, layerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayLeft.position, transform.TransformDirection(Vector2.left), 3.5f, layerMask);
        Debug.DrawRay(rayRight.position, transform.TransformDirection(Vector2.right*3.5f), Color.red);
        Debug.DrawRay(rayLeft.position, transform.TransformDirection(Vector2.left*3.5f), Color.red);

        //Striking left
        if (leftPressed && hitLeft.collider != null)
        {
            //Sucessful hit
            if (hitLeft.collider.gameObject.tag == "Enemy")
            {
                leftPressed = false;
                cam = true;

                hitLeft.collider.gameObject.GetComponent<HazHealth>().Damage(1);
                cTime = 0;
                mainCam.GetComponent<Camera>().orthographicSize = 5.2f;
                combo++;
            }
            //Hit the last enemy of the level, time to Instantiate in the minigame and disable the player strike controls
            if (hitLeft.collider.gameObject.tag == "LastEnemy")
            {
                Instantiate(endGame, this.gameObject.transform.position, Quaternion.identity);
                levelCanvas.GetComponent<Canvas>().enabled = false;
                this.enabled = false;
            }
        }
        //Missed, incur a penalty
        else if (leftPressed && hitLeft.collider == null)
        {
            leftPressed = false;
            penalty = true;
            penaltyInd.GetComponent<SpriteRenderer>().enabled = true;

            pTime = 0;
            combo = 0;

            if (scoreCollector.score > 0)
            {
                scoreCollector.score--;
            }
        }

        //Striking right
        if (rightPressed && hitRight.collider != null)
        {
            //Hit a valid enemy
            if (hitRight.collider.gameObject.tag == "Enemy")
            {
                rightPressed = false;
                cam = true;

                hitRight.collider.gameObject.GetComponent<HazHealth>().Damage(1);
                cTime = 0;
                mainCam.GetComponent<Camera>().orthographicSize = 5.2f;
                combo++;
            }
            //Hit the last enemy of the level, time to Instantiate in the minigame and disable the player strike controls
            if (hitRight.collider.gameObject.tag == "LastEnemy")
            {
                Instantiate(endGame, this.gameObject.transform.position, Quaternion.identity);
                levelCanvas.GetComponent<Canvas>().enabled = false;
                this.enabled = false;
            }
        }
        //Missed, incur a penalty
        else if (rightPressed && hitRight.collider == null)
        {
            rightPressed = false;
            penalty = true;
            penaltyInd.GetComponent<SpriteRenderer>().enabled = true;

            pTime = 0;
            combo = 0;

            if (scoreCollector.score > 0)
            {
                scoreCollector.score--;
            }
        }

        //Blast Functionality
        if (blastPressed && combo >= 10)
        {
            bTime = 0;
            combo = 0;
            blasted = true;
            blastPressed = false;
            blastBox.GetComponent<SpriteRenderer>().enabled = true;
            blastBox.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (blastPressed && combo < 10)
        {
            blastPressed = false;
        }
    }

    private void PenaltyTimer()
    {
        if (penalty && pTime < pTimeMax)
        {
            pTime += Time.deltaTime;
        }
        else if (penalty && pTime >= pTimeMax)
        {
            penalty = false;
            penaltyInd.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void BlastTimer()
    {
        if (blasted && bTime < bTimeMax)
        {
            bTime += Time.deltaTime;
        }
        else if (blasted && bTime >= bTimeMax)
        {
            blasted = false;
            blastBox.GetComponent<SpriteRenderer>().enabled = false;
            blastBox.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void CamTimer()
    {
        if (cam && cTime < cTimeMax)
        {
            cTime += Time.deltaTime;

        }
        else if (cam && cTime >= cTimeMax)
        {
            cam = false;
            mainCam.GetComponent<Camera>().orthographicSize = 5.0f;
        }

        if (!cam)
        {
            mainCam.GetComponent<Camera>().orthographicSize = 5.0f;
        }
    }
}
