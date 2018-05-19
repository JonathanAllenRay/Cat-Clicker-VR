using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("die", 5);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void die()
    {
        Destroy(gameObject);
    }
}
