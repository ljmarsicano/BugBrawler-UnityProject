using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazHealth : MonoBehaviour
{
    public GameObject deathDrop;
    public int health;
    public bool hit, killed;

    private void Awake()
    {
        hit = false;
        killed = false;
    }

    void Update()
    {
        GameObject hazDeath;
        if (health <= 0)
        {
            if (!killed)
            {
                hazDeath = Instantiate(deathDrop, transform.position, Quaternion.identity);

                //Specifically if the enemy hazHealth is attached to is a Enemy (normal)
                if (this.gameObject.name == "Enemy")
                {
                    if (GetComponent<Haz>().speed < 0)
                    {
                        hazDeath.GetComponent<HazDeathAnim>().travLeft = true;
                    }
                    else
                    {
                        hazDeath.GetComponent<HazDeathAnim>().travLeft = false;
                    }
                }

                //Specifically if the enemy hazHealth is attach to a tough enemy
                if(this.gameObject.name == "EnemyTough")
                {
                    if (GetComponent<HazTough>().travelingLeft)
                    {
                        hazDeath.GetComponent<THazDeathAnim>().travLeft = true;
                    }
                    else
                    {
                        hazDeath.GetComponent<THazDeathAnim>().travLeft = false;
                    }
                    
                }

                //Specifically if the enemy hazHealth is attached to is a nimble enemy
                if(this.gameObject.name == "TestEnemy")
                {
                    if (GetComponent<HazTest>().travelingLeft)
                    {
                        hazDeath.GetComponent<NHazDeathAnim>().travLeft = true;
                    }
                    else
                    {
                        hazDeath.GetComponent<NHazDeathAnim>().travLeft = false;
                    }
                }
            }

            killed = true;

            Destroy(this.gameObject);
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        hit = true;
    }
}
