using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DesertBoss;
    
    void Start()
    {
        DesertBoss = GameObject.FindGameObjectWithTag("DesertBossFight");
    }   

    // Update is called once per frame
    void Update()
    {
          transform.LookAt(DesertBoss.transform);
    }
}
