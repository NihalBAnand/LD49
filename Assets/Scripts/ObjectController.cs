using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int health;
    public int defense;
    // Start is called before the first frame update
    void Start()
    {
        if (defense <= 0)
        {
            defense = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage / defense;
    }
}
