using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public int health;
    public int maxHealth;
    public Sprite blank;

    public GameObject bombPrefab;
    public GameObject explosionPrefab;
    public GameObject rocketPrefab;
    public bool spawnedRocket;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 100;
        maxHealth = health;
        spawnedRocket = false;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.GetChild(1).GetComponent<Animator>().Play("Boss");
        gameObject.GetComponentInChildren<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime);
        if (health <= 0)
        {
            health = 0;
            gameObject.transform.GetChild(1).GetComponent<Animator>().StopPlayback();
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            GetComponent<ParticleSystem>().Play();
            var main = gameObject.GetComponent<ParticleSystem>().main;
            float delay = main.startLifetime.constant;
            if (!spawnedRocket)
            {
                GameObject gren = Instantiate(rocketPrefab);
                gren.transform.position = gameObject.transform.position;
                spawnedRocket = true;
            }
            Destroy(gameObject, delay);
        }

        GameObject.FindGameObjectWithTag("BossFightHealthBar").transform.localScale = new Vector3(health / (float)maxHealth, 1f, 1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    
}
