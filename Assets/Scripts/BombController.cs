using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public string bombType;
    public float range;
    public int damage;
    public GameObject explosionPrefab;
    public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play(bombType);
        if (GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).x < 0 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).x > 1 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).y < 0 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).y > 1)
        {
            GameObject explode = Instantiate(explosionPrefab);
            explode.transform.position = gameObject.transform.position;
            if (bombType == "Rocket")
            {
                explode.transform.localScale = new Vector3(.7f, .7f, 1);
            }
            else if (bombType == "C4")
            {
                explode.transform.localScale = new Vector3(4.5f, 4.5f, 1);
            }
            explode.GetComponent<ExplosionController>().damage = damage;
            Destroy(gameObject);
        }
        switch (bombType) {
            case "Dynamite":
                range = Random.Range(3.5f, 6f);
                damage = (int)Random.Range(40, 61);
                break;
            case "Grenade":
                range = Random.Range(4.5f, 9f);
                damage = (int)Random.Range(20, 41);
                break;
            case "Rocket":
                range = Random.Range(4.5f, 9f);
                damage = (int)Random.Range(100, 121);
                break;
            case "C4":
                range = -1;
                damage = 500;
                break;
        }
        if (Vector3.Distance(gameObject.transform.position, playerPos) > range)
        {
            GameObject explode = Instantiate(explosionPrefab);
            explode.transform.position = gameObject.transform.position;
            if (bombType == "Rocket")
            {
                explode.transform.localScale = new Vector3(.7f, .7f, 1);
            }
            else if (bombType == "C4")
            {
                explode.transform.localScale = new Vector3(4.5f, 4.5f, 1);
            }
            explode.GetComponent<ExplosionController>().damage = damage;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explode = Instantiate(explosionPrefab);
        explode.transform.position = gameObject.transform.position;
        if (bombType == "Rocket")
        {
            explode.transform.localScale = new Vector3(.7f, .7f, 1);
        }
        else if (bombType == "C4")
        {
            explode.transform.localScale = new Vector3(4.5f, 4.5f, 1);
        }
        explode.GetComponent<ExplosionController>().damage = damage;
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
