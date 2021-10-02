using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnCompleteAttackAnimation());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator OnCompleteAttackAnimation()
    {
        while (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            gameObject.GetComponent<Animator>().Play("Explosion");
            yield return null;
        }

        Destroy(gameObject);
    }
}

