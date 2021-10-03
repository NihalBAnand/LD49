using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Vector3 movement;
    string direction = "Down";

    public int health = 100;
    public int chaos = 0;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = 100;
        StartCoroutine(DecreaseChaos());
    }

    // Update is called once per frame
    void Update()
    {
        if (chaos >= 100) chaos = 100;
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
        rb.MovePosition(gameObject.transform.position + (movement * speed * Time.deltaTime));
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyController>().damage);
        }
    }

    private IEnumerator DecreaseChaos()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            if (chaos > 0) chaos--;
            Debug.Log(chaos);
        }
    }
}
