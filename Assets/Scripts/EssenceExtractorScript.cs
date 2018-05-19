using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceExtractorScript : MonoBehaviour {

    public GameObject manager;
    public int creditValue;

    // Use this for initialization
    void Start()
    {

        manager = GameObject.Find("GameplayManager");
        InvokeRepeating("generateCredits", 2.00f, 1.00f);
    }

    void generateCredits()
    {
        manager.GetComponent<GameplayManager>().clickCredits += creditValue;
    }
}
