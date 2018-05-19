using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour {

    public TextMesh text;
    public GameObject manager;

    // Use this for initialization
    void Start () {
        manager = GameObject.Find("GameplayManager");
        text = this.gameObject.transform.GetChild(0).GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "Credits: \n" + manager.GetComponent<GameplayManager>().clickCredits;
	}
}
