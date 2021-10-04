using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStart : MonoBehaviour
{
    // Start is called before the first frame update
    public bool qStart;
    void Start()
    {
        qStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player(Clone)")
        {
            qStart = true;
        }
    }
}
