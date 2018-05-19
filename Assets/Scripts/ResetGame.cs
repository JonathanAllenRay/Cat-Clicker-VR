using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetGameToStart()
    {
        SceneManager.LoadScene("GoogleVR/Demos/Scenes/HelloVR");
    }
}
