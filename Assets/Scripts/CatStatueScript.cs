using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStatueScript : MonoBehaviour
{

    public GameObject manager;
    public int value;
    private int catLevel;
    public AudioSource ding;

    // Use this for initialization
    void Start()
    {
        catLevel = 3;
        manager = GameObject.Find("GameplayManager");
        if (manager != null)
        {
            Debug.Log("manager found");
        }
    }

    public void activateStatue()
    {
        InvokeRepeating("generateCredits", 1.00f, 1.00f);
    }


    private void generateCredits()
    {
        manager.GetComponent<GameplayManager>().clickCredits += value;
    }

    public void beenClicked()
    {
        ding.Play();
        int clickValTemp = manager.GetComponent<GameplayManager>().currClickValue * (catLevel * catLevel);
        manager.GetComponent<GameplayManager>().clickCredits += clickValTemp;
        int critLevel = manager.GetComponent<GameplayManager>().critLevel;
        if (critLevel >= Random.Range(1, 101))
        {
            manager.GetComponent<GameplayManager>().clickCredits += clickValTemp * 2;
        }
    }


}

