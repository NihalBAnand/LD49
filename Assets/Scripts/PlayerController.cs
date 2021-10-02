using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.transform.Translate(new Vector3(0, speed, 0));
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.transform.Translate(new Vector3(0, -speed, 0));
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.transform.Translate(new Vector3(speed, 0, 0));
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.transform.Translate(new Vector3(-speed, 0, 0));
        }
    }
}
