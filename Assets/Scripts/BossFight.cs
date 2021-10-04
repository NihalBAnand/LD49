using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject bossPrefab;

    public AudioClip intro;
    public AudioClip loop;
    public AudioClip finale;
    public AudioClip ambient;

    public AudioSource source;
    public bool started;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        started = false;
        player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player(Clone)");
        if (started)
        {
            if (GameObject.Find("Boss(Clone)") == null)
            {
                source.loop = false;
                source.Stop();
                source.PlayOneShot(finale);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !started)
        {
            player.transform.GetChild(1).gameObject.SetActive(false);
            started = true;
            GameObject boss = Instantiate(bossPrefab);
            boss.transform.position = transform.position;
            source.PlayOneShot(intro);
            source.loop = false;
            StartCoroutine(PlayLoop());
        }
    }

    private IEnumerator PlayLoop()
    {
        while (source.isPlaying)
        {
            yield return null;
        }
        source.PlayOneShot(loop);
        source.loop = true;
        
    }
    private IEnumerator PlayAmbient()
    {
        while (source.isPlaying)
        {
            yield return null;
        }
        source.PlayOneShot(ambient);
        source.loop = true;
    }
}
