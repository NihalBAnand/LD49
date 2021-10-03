using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject objPrefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Object");
    }

    // Update is called once per frame
    void Update()
    {
        //update list of objs
        objs = GameObject.FindGameObjectsWithTag("Object");
    }

    public void objSpawn()
    {
        
        float randx = Random.Range(-.5f, .5f);
        float randy = Random.Range(-.5f, .5f);
        Vector3 spawnpos = new Vector3(player.transform.x + randx, player.transform.y + randy, 0);
        foreach (GameObject g in objs)
        {
            while (Vector3.Distance(g.transform.position, spawnpos) < 1)
            {
                spawnpos.x += .2f;
                spawnpos.y += -.3f;
            }
        }

        GameObject temp = Instantiate(objPrefab);
        temp.transform.position = spawnpos;
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Console.Log("agdfskljagljkfd");
            objSpawn();
        }
    }
}
