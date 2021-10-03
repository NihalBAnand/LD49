using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Instantiate(playerPrefab);
        player.transform.localScale = new Vector3(4, 4);

    }

    // Update is called once per frame
    void Update()
    {
        
        // Temporary vector
        Vector3 temp = GameObject.Find("Player(Clone)").transform.position;
        temp.z = temp.z - 15;
        // Assign value to Camera position
        transform.position = temp;
    }

 
    
}
