using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTile : MonoBehaviour {

    public AudioSource shopSound;
    public AudioClip[] shopSounds;

    // Use this for initialization
    public TextMesh text;
    public GameObject manager;
    public TextMesh dCanvas;
    public int cost;
    public int costIncreaseFactor;
    public string item;
    public string originalText;
    public int purchases;
    public int maxPurchases;
    public int requiredLv1Cats;
    public int requiredLv2Cats;
    public int requiredLv3Cats;
    public bool isCatPurchase1;
    public bool isCatPurchase2;
    public bool isCatPurchase3;
    public bool isCatPurchase4;
    public string description;

    // Use this for initialization
    void Start()
    {
        dCanvas = GameObject.Find("DescriptionCanvas").GetComponent<TextMesh>();
        manager = GameObject.Find("GameplayManager");
        text = this.gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        originalText = text.text;
        text.text = originalText + "\n" + "(" + cost + ")";
        shopSounds = Resources.LoadAll<AudioClip>("Sounds/ShopSounds");
    }

    public void beenClicked()
    {
        if (isCatPurchase1 && manager.GetComponent<GameplayManager>().getNumCatsLevel(1) >= manager.GetComponent<GameplayManager>().maxCats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (isCatPurchase2 && manager.GetComponent<GameplayManager>().getNumCatsLevel(2) >= manager.GetComponent<GameplayManager>().maxCats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (isCatPurchase3 && manager.GetComponent<GameplayManager>().getNumCatsLevel(3) >= manager.GetComponent<GameplayManager>().maxCats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (purchases >= maxPurchases)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (isCatPurchase2 && manager.GetComponent<GameplayManager>().getNumCatsLevel(1) < requiredLv1Cats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (isCatPurchase3 && manager.GetComponent<GameplayManager>().getNumCatsLevel(2) < requiredLv2Cats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (isCatPurchase4 && manager.GetComponent<GameplayManager>().getNumCatsLevel(3) < requiredLv2Cats)
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
        else if (cost <= manager.GetComponent<GameplayManager>().clickCredits) {
            shopSound.clip = shopSounds[1];
            shopSound.Play();
            manager.GetComponent<GameplayManager>().handlePurchase(item, cost);
            cost += costIncreaseFactor;
            text.text = originalText + "\n" + "(" + cost + ")";
            purchases++;
            if (purchases == maxPurchases)
            {
                text.text = "SOLD OUT";
            }
        }
        else
        {
            shopSound.clip = shopSounds[0];
            shopSound.Play();
        }
    }

    void Update()
    {
        if (IsValidPurchase())
        {
            text.color = Color.green;
        }            
        else
        {
            text.color = Color.white;
        }
    }

    private bool IsValidPurchase()
    {
        int creds = manager.GetComponent<GameplayManager>().clickCredits;
        if (creds < cost)
        {
            return false;
        }
        if (creds >= cost && purchases < maxPurchases && !IsCatPurchase())
        {
            return true;
        }
        else if (isCatPurchase2 && manager.GetComponent<GameplayManager>().getNumCatsLevel(1) >= 2) {
            return true;

        }
        else if (isCatPurchase3 && manager.GetComponent<GameplayManager>().getNumCatsLevel(2) >= 3)
        {
            return true;
        }
        else if (isCatPurchase4 && manager.GetComponent<GameplayManager>().getNumCatsLevel(3) >= 4)
        {
            return true;
        }
        return false;
    }

    private bool IsCatPurchase()
    {
        if (isCatPurchase2 || isCatPurchase3 || isCatPurchase4)
        {
            return true;
        }
        return false;
    }

    public void showDescription()
    {
        dCanvas.text = description;
    }


    public void clearDescription()
    {
        dCanvas.text = "";
    }
}
