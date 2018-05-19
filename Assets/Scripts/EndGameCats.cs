using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCats : MonoBehaviour {

    public ParticleSystem ps;
	// Use this for initialization
	void Start () {
        Invoke("Poof", 20.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Poof()
    {
        Destroy(gameObject);
    }

    public void beenClicked()
    {
        Instantiate(ps, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
