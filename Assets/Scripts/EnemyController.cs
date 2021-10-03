using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health;
    public float defense;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        GetComponent<Animator>().Play("Alieeen");
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player(Clone)").transform.position, 3 * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= (int) (damage / defense);
    }

}
