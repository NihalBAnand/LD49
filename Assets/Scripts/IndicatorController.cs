using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DesertBoss;
    public float mouseAngle;
    public GameObject Player;
    public Vector3 temp;


    
    void Start()
    {
        DesertBoss = GameObject.FindGameObjectWithTag("DesertBossFight");
        Player = GameObject.FindGameObjectWithTag("Player");
    }   

    // Update is called once per frame
    void Update()
    {
        //Get angle between mouse and player and convert to 360
        mouseAngle = Vector3.Angle(DesertBoss.transform.position, Player.transform.position);
        Vector2 direction = DesertBoss.transform.position - Player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;

        //Set position of weapon with TRIG (suck it, anish)
        gameObject.transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle)) * 3f + Player.transform.position;

        Vector3 dir = DesertBoss.transform.position - transform.position;
        float dangle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(dangle - 90, Vector3.forward);

    }
}
