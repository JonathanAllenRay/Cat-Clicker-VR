using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickBotScript : MonoBehaviour {

    public GameObject manager;
    public AudioSource beep;
    public ParticleSystem ps;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("GameplayManager");
        if (manager != null)
        {
            Debug.Log("manager found");
        }
    }

    public void activate()
    {
        InvokeRepeating("generateCredits", 1.00f, 0.33f);
        beep.Play();
    }

    private void generateCredits()
    {
        int clickValTemp = manager.GetComponent<GameplayManager>().currClickValue;
        manager.GetComponent<GameplayManager>().clickCredits += clickValTemp;
        int critLevel = manager.GetComponent<GameplayManager>().critLevel;
        if (critLevel >= Random.Range(1, 101))
        {
            Quaternion n = Quaternion.Euler(270, 0, 0);
            Instantiate(ps, transform.position, n);
            manager.GetComponent<GameplayManager>().clickCredits += clickValTemp * 2;
        }
    }
}
