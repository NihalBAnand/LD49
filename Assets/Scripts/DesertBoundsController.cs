using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBoundsController : MonoBehaviour
{
    public bool DoneOnce;
    public bool inDesert;
    // Start is called before the first frame update
    void Start()
    {
        DoneOnce = false;
        inDesert = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss Fight").GetComponent<BossFight>().started && GameObject.Find("Boss Fight").GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            Debug.Log("WHAAAAAT");

            if (!GetComponent<AudioSource>().isPlaying && inDesert) GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            inDesert = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Stop();
            inDesert = false;
        }
    }
}
