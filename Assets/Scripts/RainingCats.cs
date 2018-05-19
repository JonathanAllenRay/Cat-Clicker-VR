using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RainingCats : MonoBehaviour {

    public GameObject[] catslol;

	// Use this for initialization
	void Start () {
        catslol = Resources.LoadAll<GameObject>("EndGameCats");
        InvokeRepeating("MakeCats", 0.2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeCats()
    {
        GameObject cat = catslol[Random.Range(0, catslol.Length)];
        Vector3 loc = new Vector3(Random.Range(-10.0f, 10.0f), 42.0f, Random.Range(-10.0f, 10.0f));
        Quaternion q = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        GameObject catMade = Instantiate(cat, loc, q);
        //Vector3 push = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        //catMade.GetComponent<Rigidbody>().AddRelativeForce(push, ForceMode.Impulse);
    }
}
