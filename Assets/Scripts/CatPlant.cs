using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlant : MonoBehaviour {

    public GameObject manager;
    public int creditValue;
    public bool isActive;
    public MeshRenderer plantStem;
    public ParticleSystem ps;

    // Use this for initialization
    void Start () {

        manager = GameObject.Find("GameplayManager");
        plantStem = this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
        plantStem.enabled = false;
        isActive = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void activate()
    {
        plantStem.enabled = true;
        isActive = true;
        InvokeRepeating("generateCredits", 3.50f, 3.50f);
    }

    void generateCredits()
    {
        if (isActive)
        {
            int value = creditValue * manager.GetComponent<GameplayManager>().multiplantLevel;
            manager.GetComponent<GameplayManager>().clickCredits += value;
        }
    }
}
