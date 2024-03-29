using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;

    public GameObject[] objs;
    public GameObject objPrefab;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab);
        player.transform.localScale = new Vector3(4, 4);

    }

    // Update is called once per frame
    void Update()
    {

        objs = GameObject.FindGameObjectsWithTag("Object");
        if (Input.GetKeyDown("space"))
        {
            objSpawn();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            enemySpawn();
        }

        // Temporary vector
        Vector3 temp = GameObject.Find("Player(Clone)").transform.position;
        temp.z = temp.z - 15;
        // Assign value to Camera position
        transform.position = temp;
    }


    public void objSpawn()
    {

        float randx = Random.Range(-.5f, .5f);
        float randy = Random.Range(-.5f, .5f);
        Vector3  mousePos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnpos = new Vector3(mousePos.x + randx, mousePos.y + randy, 0);
        foreach (GameObject g in objs)
        {
            while(Vector3.Distance(g.transform.position, spawnpos) < 1)
            {
                spawnpos.x += .2f;
                spawnpos.y += -.3f;
            }
        }
       
        GameObject temp = Instantiate(objPrefab);
        temp.transform.position = spawnpos;
    }

    public void enemySpawn()
    {
        float randx = Random.Range(-.5f, .5f);
        float randy = Random.Range(-.5f, .5f);
        Vector3 mousePos = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnpos = new Vector3(mousePos.x + randx, mousePos.y + randy, 0);
        foreach (GameObject g in objs)
        {
            while (Vector3.Distance(g.transform.position, spawnpos) < 1)
            {
                spawnpos.x += .2f;
                spawnpos.y += -.3f;
            }
        }

        GameObject temp = Instantiate(enemyPrefab);
        temp.transform.position = spawnpos;
    }

    
}
