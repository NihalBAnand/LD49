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
    public int enemies;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab);
        player.transform.localScale = new Vector3(4, 4);
        enemies = 0;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        
        if (Mathf.RoundToInt(playerPos.x)%20 ==0 && enemies ==0 )
        {
            enemySpawn();
            enemies += 1; 
        }
        // Temporary vector
        Vector3 temp = GameObject.Find("Player(Clone)").transform.position;
        temp.z = temp.z - 15;
        // Assign value to Camera position
        transform.position = temp;
        if (Mathf.RoundToInt(playerPos.x) % 20 != 0)
        { 
            enemies = 0;
        }

    }

    

    public void enemySpawn()
    {
        float randx = Random.Range(-5f, 5f);
        float randy = Random.Range(-5f, 5f);
        Vector3 spawnpos = new Vector3(player.transform.position.x + randx, player.transform.position.y + randy, 0);
        foreach (GameObject g in objs)
        {
            while (Vector3.Distance(g.transform.position, spawnpos) < 1)
            {
                spawnpos.x += 1f;
                spawnpos.y += 3f;
            }
        }

        GameObject temp = Instantiate(enemyPrefab);
        temp.transform.position = spawnpos;
    }
    
}
