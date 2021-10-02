using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().Play("Explosion");
        StartCoroutine(OnCompleteAttackAnimation());
    }
    IEnumerator OnCompleteAttackAnimation()
    {
        while (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            
            yield return null;

        Destroy(gameObject);
    }
}

