using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertBoundsController : MonoBehaviour
{
    public bool DoneOnce;
    public bool inDesert;
    public GameObject[] objs;
    public GameObject objPrefab;
    // Start is called before the first frame update
    void Start()
    {
        objs = GameObject.FindGameObjectsWithTag("Object");
        DoneOnce = false;
        inDesert = false;
        for (int i = 0; i < 70; i++)
        {
            Debug.Log("BRAIN");
            objSpawn();
        }
    }


    // Update is called once per frame
    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Object");

        if (GameObject.Find("Boss Fight").GetComponent<BossFight>().started && GameObject.Find("Boss Fight").GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
        }
        else
        {

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
    public void objSpawn()
    {

        float randx = Random.Range(-30f, 30f);
        float randy = Random.Range(-20f, 20f);
        Vector3 DesertBounds = new Vector3(-39.373f, 18.2322f, 0);
        Vector3 spawnpos = new Vector3(DesertBounds.x + randx, DesertBounds.y + randy, 0);
        foreach (GameObject g in objs)
        {
            while (Vector3.Distance(DesertBounds, spawnpos) < 1)
            {
                spawnpos.x += 1f;
                spawnpos.y += -3f;
            }
        }

        GameObject temp = Instantiate(objPrefab);
        temp.transform.position = spawnpos;
    }
}
