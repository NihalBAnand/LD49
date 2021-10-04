using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleBoundsController : MonoBehaviour
{
    public bool inJungle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inJungle && !GetComponent<AudioSource>().isPlaying) GetComponent<AudioSource>().Play();
        if (!inJungle) GetComponent<AudioSource>().Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inJungle = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            inJungle = false;
    }
}
