using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBarController : MonoBehaviour
{
    public int selected;
    public Sprite itemSelected;
    public Sprite itemNormal;
    // Start is called before the first frame update
    void Start()
    {
        selected = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selected = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameObject.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Image>().sprite.texture.name != "Empty_Image")
        {
            selected = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && gameObject.transform.GetChild(2).GetChild(0).gameObject.GetComponent<Image>().sprite.texture.name != "Empty_Image")
        {
            selected = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && gameObject.transform.GetChild(3).GetChild(0).gameObject.GetComponent<Image>().sprite.texture.name != "Empty_Image")
        {
            selected = 4;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            if (selected < 4 && gameObject.transform.GetChild(selected).GetChild(0).gameObject.GetComponent<Image>().sprite.texture.name != "Empty_Image")
            {
                selected += 1;
            }
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            if (selected > 1 && gameObject.transform.GetChild(selected - 1).GetChild(0).gameObject.GetComponent<Image>().sprite.texture.name != "Empty_Image")
            {
                selected -= 1;
            }
        }

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject Go = gameObject.transform.GetChild(i).gameObject;
            if (Go.name.Contains(selected.ToString())) {
                Go.GetComponent<Image>().sprite = itemSelected;
            }
            else
            {
                Go.GetComponent<Image>().sprite = itemNormal;
            }
        }
    }
}
