using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopText : MonoBehaviour {

    public TextMesh text;
    public GameObject theShop;
    private bool isOpen;
    public AudioSource click;

    // Use this for initialization
    void Start () {
        text = this.gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        theShop = GameObject.Find("ShopTiles");
        isOpen = true;
    }

    public void beenClicked()
    {
        if (isOpen)
        {
            isOpen = false;
            closeShop();
        }
        else
        {
            isOpen = true;
            openShop();
        }
    }

    private void openShop()
    {
        click.Play();
        theShop.SetActive(true);
        text.text = "CLOSE \n SHOP";

    }

    private void closeShop()
    {
        click.Play();
        theShop.SetActive(false);
        text.text = "SHOP";
    }
}

