using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject leftSpawn, rightSpawn;
    public GameObject enemy, enemyTough, enemyNimble;
    public float incrementer, maxTimeInterval, enemySpeed, velocityLimit;
    
    //The slowly incrementing difficulty modifier
    public float currentOffset;

    //Variables controlling the spawning on the right
    private float currTimeR, randoTimeR;
    private bool randomSetR;

    //Variables controlling the spawning on the left
    private float currTimeL, randoTimeL;
    private bool randomSetL;

    private void Awake()
    {
        currentOffset = 0;

        randomSetR = false;
        currTimeR = 0;

        randomSetL = false;
        currTimeL = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the spawn time faster as the game continues and maxes so 
        if (currentOffset < maxTimeInterval - 1)
        {
            currentOffset += incrementer;
        }

        rSpawnCntrl();
        lSpawnCntrl();
    }

    void rSpawnCntrl()
    {
        currTimeR += Time.deltaTime;

        if (randomSetR && currTimeR < randoTimeR)
        {
            //Still counting up to spawn
        }
        else if (randomSetR && currTimeR >= randoTimeR)
        {
            //Time to spawn TODO: add random choice between spawns
            spawnRight();
            randomSetR = false;
        }
        else
        {
            //Time to set the time at which the enemy will spawn
            currTimeR = 0;
            randomSetR = true;
            randoTimeR = Random.Range(.25f, maxTimeInterval - currentOffset);
        }
    }

    void lSpawnCntrl()
    {
        currTimeL += Time.deltaTime;

        if (randomSetL && currTimeL < randoTimeL)
        {
            //Still counting up to spawn
        }
        else if (randomSetL && currTimeL >= randoTimeL)
        {
            //Time to spawn TODO: add random choice between spawns
            spawnLeft();
            randomSetL = false;
        }
        else
        {
            //Time to set the time at which the enemy will spawn
            currTimeL = 0;
            randomSetL = true;
            randoTimeL = Random.Range(.25f, maxTimeInterval - currentOffset);
        }
    }

    private void spawnRight()
    {
        GameObject nuEnemy;

        float choice = Random.Range(0, 100);
        if (choice <= 80)
        {
            //Spawn Normal Enemy
            nuEnemy = Instantiate(enemy, rightSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<Haz>().speed = -enemySpeed;
            nuEnemy.GetComponent<Haz>().limit = velocityLimit + currentOffset;
        }
        else if (choice > 80 && choice <= 90)
        {
            //Spawn Tough Enemy
            nuEnemy = Instantiate(enemyTough, rightSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<HazTough>().speed = -enemySpeed;
            nuEnemy.GetComponent<HazTough>().limit = velocityLimit + currentOffset;
            nuEnemy.GetComponent<HazTough>().travelingLeft = true;
        }
        else if (choice > 90 && choice <= 100)
        {
            //Spawn Nimble Enemy
            nuEnemy = Instantiate(enemyNimble, rightSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<HazTest>().speed = -enemySpeed;
            nuEnemy.GetComponent<HazTest>().limit = velocityLimit + currentOffset;
            nuEnemy.GetComponent<HazTest>().travelingLeft = true;
        }
    }

    private void spawnLeft()
    {
        GameObject nuEnemy;

        float choice = Random.Range(0, 100);
        if (choice <= 80)
        {
            //Spawn Normal Enemy
            nuEnemy = Instantiate(enemy, leftSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<Haz>().speed = enemySpeed;
            nuEnemy.GetComponent<Haz>().limit = velocityLimit + currentOffset;
        }
        else if (choice > 80 && choice <= 90)
        {
            //Spawn Tough Enemy
            nuEnemy = Instantiate(enemyTough, leftSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<HazTough>().speed = enemySpeed;
            nuEnemy.GetComponent<HazTough>().limit = velocityLimit + currentOffset;
            nuEnemy.GetComponent<HazTough>().travelingLeft = false;
        }
        else if (choice > 90 && choice <= 100)
        {
            //Spawn Nimble Enemy
            nuEnemy = Instantiate(enemyNimble, leftSpawn.transform.position, Quaternion.identity);
            nuEnemy.GetComponent<HazTest>().speed = enemySpeed;
            nuEnemy.GetComponent<HazTest>().limit = velocityLimit + currentOffset;
            nuEnemy.GetComponent<HazTest>().travelingLeft = false;
            
        }
    }
}
