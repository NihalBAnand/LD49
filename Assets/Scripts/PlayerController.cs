using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //Player movement
        if (Input.GetAxisRaw("Vertical") > 0)
        {

        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {

        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {

        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {

        }
        rb.transform.Translate(movement * speed * Time.deltaTime);
    }
}
