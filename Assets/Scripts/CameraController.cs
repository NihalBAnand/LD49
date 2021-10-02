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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
