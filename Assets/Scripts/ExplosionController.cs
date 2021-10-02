using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().Play("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Debug.Log("Test");
            Destroy(gameObject);
        }
    }
    
}

