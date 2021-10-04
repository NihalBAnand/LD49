using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialController : MonoBehaviour
{
    public int timeLeft;
    public GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StartTimer());
        }
    }
    private IEnumerator StartTimer()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            GameObject.Find("Timer").GetComponent<Text>().text = (timeLeft / 60).ToString() + ":" + (timeLeft % 60).ToString();
            timeLeft -= 1;
        }
        GameObject.Find("Timer").SetActive(false);
        GameObject.Find("GoldPile").SetActive(false);
        GameObject gren = Instantiate(grenade);
        gren.transform.position = new Vector3(47.5f, 6.91f, 0);
    }

}
