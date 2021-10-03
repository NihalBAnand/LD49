using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public int health;
    public int defense;
    public Sprite blank;
    // Start is called before the first frame update
    void Start()
    {
        if (defense <= 0)
        {
            defense = 1;
        }
        var main = gameObject.GetComponent<ParticleSystem>().main;
        Color32 color = AverageColorFromTexture(gameObject.GetComponent<SpriteRenderer>().sprite.texture);
        color.a = 255;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<ParticleSystem>().Play();
            var main = gameObject.GetComponent<ParticleSystem>().main;
            float delay = main.startLifetime.constant;
            GetComponent<SpriteRenderer>().sprite = blank;
            Destroy(gameObject, delay);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage / defense;
    }

    Color32 AverageColorFromTexture(Texture2D tex)
    {

        Color32[] texColors = tex.GetPixels32();

        int total = texColors.Length;

        float r = 0;
        float g = 0;
        float b = 0;

        for (int i = 0; i < total; i++)
        {

            r += texColors[i].r;

            g += texColors[i].g;

            b += texColors[i].b;

        }

        return new Color32((byte)(r / total), (byte)(g / total), (byte)(b / total), 0);

    }
}
