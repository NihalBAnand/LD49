using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTargeterController : MonoBehaviour
{
    public Vector3 mousePos;
    new public Camera camera;
    public float mouseAngle;
    public Vector3 playerPos;
    public GameObject bombPrefab;
    public float bombSpeed;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform.parent.gameObject.transform.position;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        StartCoroutine(ShootPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        //Set constants - player position and mouse position (relative to player)
        playerPos = gameObject.transform.parent.gameObject.transform.position;
        mousePos = GameObject.Find("Player(Clone)").transform.position - playerPos;
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        //Get angle between player and boss and convert to 360
        mouseAngle = Vector3.Angle(mousePos, playerPos);
        Vector2 direction = mousePos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;

        //Set position of weapon with TRIG (suck it, anish)
        gameObject.transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)) * 3f + playerPos;
    }
    private IEnumerator ShootPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GameObject newBomb = Instantiate(bombPrefab);
            newBomb.transform.position = gameObject.transform.position;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            newBomb.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - player.transform.position) * -100);
            string[] bombTypes = { "Dynamite", "Grenade" };
            newBomb.GetComponent<BombController>().bombType = bombTypes[0];
            newBomb.GetComponent<BombController>().explosionPrefab = explosionPrefab;
            newBomb.GetComponent<BombController>().playerPos = gameObject.transform.position;
            newBomb.GetComponent<BombController>().fromBoss = true;
            Physics2D.IgnoreCollision(explosionPrefab.GetComponent<CircleCollider2D>(), bombPrefab.GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(explosionPrefab.transform.GetChild(0).GetComponent<CircleCollider2D>(), bombPrefab.GetComponent<BoxCollider2D>());
            Physics2D.IgnoreCollision(newBomb.GetComponent<BoxCollider2D>(), GameObject.Find("ColideTiles").GetComponent<Collider2D>());
            //Physics2D.IgnoreCollision(newBomb.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
