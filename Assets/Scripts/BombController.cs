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
    public bool fromBoss = false;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(GameObject.Find("Boss Fight").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("Desert Bounds").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("Jungle Bounds").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GameObject.Find("Time Trial").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play(bombType);
        if (GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).x < 0 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).x > 1 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).y < 0 || GameObject.Find("Main Camera").GetComponent<Camera>().WorldToViewportPoint(transform.position).y > 1)
        {
            GameObject explode = Instantiate(explosionPrefab);
            Physics2D.IgnoreCollision(explode.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(explode.transform.GetChild(0).GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            explode.transform.position = gameObject.transform.position;
            if (bombType == "Rocket")
            {
                explode.transform.localScale = new Vector3(.9f, .9f, 1);
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
                Vector3 dir = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float dangle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(dangle - 90, Vector3.forward);
                break;
            case "C4":
                range = -1;
                damage = 500;
                break;
        }
        if (Vector3.Distance(gameObject.transform.position, playerPos) > range)
        {
            GameObject explode = Instantiate(explosionPrefab);
            Physics2D.IgnoreCollision(explode.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(explode.transform.GetChild(0).GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            explode.transform.position = gameObject.transform.position;
            if (bombType == "Rocket")
            {
                explode.transform.localScale = new Vector3(5 * .7f, 5 * .7f, 1);
            }
            else if (bombType == "C4")
            {
                explode.transform.localScale = new Vector3(5 * 4.5f, 5 * 4.5f, 1);
            }
            explode.GetComponent<ExplosionController>().damage = damage;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Explosion" && collision.tag != "ExplosionPeriphery")
        {
            GameObject explode = Instantiate(explosionPrefab);
            Physics2D.IgnoreCollision(explode.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(explode.transform.GetChild(0).GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
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

   
}
