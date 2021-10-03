using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector3 movement;
    string direction = "Down";

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 0);
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //Player movement
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            direction = "Up";
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            direction = "Down";
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = "Right";
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = "Left";
        }
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.Play("Player_Idle_" + direction);
        }
        else if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.Play("Player_" + direction);
        }
        rb.transform.Translate(movement * speed * Time.deltaTime);
    }
}
