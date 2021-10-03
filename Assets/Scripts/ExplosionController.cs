using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().Play("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            collision.gameObject.GetComponent<ObjectController>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }

    public void PeripheryContact(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            collision.gameObject.GetComponent<ObjectController>().TakeDamage(damage / 3);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage / 3);
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage / 3);
        }
    }
}

