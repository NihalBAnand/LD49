using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeterController : MonoBehaviour
{
    public Vector3 mousePos;
    new public Camera camera;
    public float mouseAngle;
    public Vector3 playerPos;
    public GameObject bombPrefab;
    public float bombSpeed;
    public GameObject explosionPrefab;
    public GameObject itemBar;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform.parent.gameObject.transform.position;
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        itemBar = GameObject.Find("ItemBar");
    }

    // Update is called once per frame
    void Update()
    {
        //Set constants - player position and mouse position (relative to player)
        playerPos = gameObject.transform.parent.gameObject.transform.position;
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition) - playerPos;
        mousePos = new Vector3(mousePos.x, mousePos.y, 0);

        //Get angle between mouse and player and convert to 360
        mouseAngle = Vector3.Angle(mousePos, playerPos);
        Vector2 direction = mousePos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        
        //Set position of weapon with TRIG (suck it, anish)
        gameObject.transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)) * 1.5f + playerPos;
        
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBomb = Instantiate(bombPrefab);
            newBomb.transform.position = gameObject.transform.position;
            newBomb.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - playerPos) * bombSpeed);
            string[] bombTypes = { "Dynamite", "Grenade" };
            newBomb.GetComponent<BombController>().bombType = bombTypes[itemBar.GetComponent<ItemBarController>().selected - 1];
            newBomb.GetComponent<BombController>().explosionPrefab = explosionPrefab;
            newBomb.GetComponent<BombController>().playerPos = GameObject.Find("Player(Clone)").transform.position;
        }
    }
}
