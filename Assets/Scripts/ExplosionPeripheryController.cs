using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPeripheryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.transform.parent.gameObject.GetComponent<ExplosionController>().PeripheryContact(collision);
    }
}
