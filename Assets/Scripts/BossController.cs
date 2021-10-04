using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject player;
    public int health;
    public Sprite blank;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.transform.GetChild(0).GetComponent<Animator>().Play("Boss");
        gameObject.GetComponentInChildren<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, Time.deltaTime);
        if (health <= 0)
        {
            gameObject.transform.GetChild(0).GetComponent<Animator>().StopPlayback();
            GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 0);
            GetComponent<ParticleSystem>().Play();
            var main = gameObject.GetComponent<ParticleSystem>().main;
            float delay = main.startLifetime.constant;
            Destroy(gameObject, delay);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
