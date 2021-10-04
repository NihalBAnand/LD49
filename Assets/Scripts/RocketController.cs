using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RocketController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("ItemSlot3").transform.GetChild(0).gameObject.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
            Destroy(gameObject);
        }
    }
}
