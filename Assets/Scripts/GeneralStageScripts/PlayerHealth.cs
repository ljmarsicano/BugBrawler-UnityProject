using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public bool hit;
    public GameObject indicator;

    private float timer, immuneTime;

    private void Awake()
    {
        hit = false;
        immuneTime = .5f;
        indicator.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    void Update()
    {
        if (health <= 0)
        {
            SceneManagerSF.instance.LoadScene(SceneManagerSF.Scene.GameOver);
            Destroy(this.gameObject);
        }

        if (hit && timer >= immuneTime)
        {
            hit = false;
            indicator.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }
        else if (hit && timer < immuneTime)
        {
            timer += Time.deltaTime;
        }
    }

    public void Damage(int damage)
    {
        if (!hit)
        {
            health -= damage;
            hit = true;
            timer = 0;
            indicator.GetComponent<SpriteRenderer>().color = new Color(255,0,0);
        }
    }
}
