using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public string bombType;
    public GameObject explosionPrefab;
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
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explode = Instantiate(explosionPrefab);
        explode.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
