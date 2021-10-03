using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public GameObject[] objs;
    public GameObject objPrefab;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab);
        player.transform.localScale = new Vector3(4, 4);
        objs = GameObject.FindGameObjectsWithTag("Object");

    }

    // Update is called once per frame
    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Object");
        if (Input.GetKeyDown("space"))
        {
            objSpawn();
        }
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
    
}
