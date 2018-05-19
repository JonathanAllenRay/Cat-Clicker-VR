using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public int catLevel;
    public int upgradeLevel;
    public bool hasHat;
    public AudioSource clickSound;
    public AudioSource meow;
    public AudioClip[] clips;
    public ParticleSystem ps;
    public ParticleSystem poofParticle;

    public GameObject manager;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("GameplayManager");
        if (manager != null)
        {
            Debug.Log("manager found");
        }
        InvokeRepeating("generateCredit", 1.00f, 0.50f);
        clips = Resources.LoadAll<AudioClip>("Sounds/Cats");

    }


    // Update is called once per frame
    void Update () {
		
	}

    public void beenClicked()
    {
        clickSound.Play();
        Quaternion n = Quaternion.Euler(270, 0, 0);
        Instantiate(ps, transform.position, n);
        int clickValTemp = manager.GetComponent<GameplayManager>().currClickValue * (catLevel * catLevel);
        manager.GetComponent<GameplayManager>().clickCredits += clickValTemp;
        int critLevel = manager.GetComponent<GameplayManager>().critLevel;
        if (critLevel >= Random.Range(1, 101))
        {
            manager.GetComponent<GameplayManager>().clickCredits += clickValTemp * 9;
            meow.clip = clips[Random.Range(0, clips.Length)];
            Debug.Log("HELP");
            meow.Play();
        }
    }

    private void generateCredit()
    {
        if (catLevel <= 2)
        {
            manager.GetComponent<GameplayManager>().clickCredits += manager.GetComponent<GameplayManager>().catMultiplier * catLevel * catLevel;

        }
        else
        {
            manager.GetComponent<GameplayManager>().clickCredits += manager.GetComponent<GameplayManager>().catMultiplier * catLevel * catLevel * catLevel;

        }
    }

    public void poof()
    {
        Instantiate(poofParticle, transform.position, transform.rotation);
    }
}
