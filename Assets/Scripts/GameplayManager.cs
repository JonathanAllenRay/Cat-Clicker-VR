using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameplayManager : MonoBehaviour {
    public int clickCredits;

    public int numCats;
    public int maxCats;
    public GameObject[] cats;
    public int lv1Cats;
    public int lv2Cats;
    public int lv3Cats;

    public int numPlants;
    public GameObject[] plants;

    public int numClickBot;
    public GameObject[] clickBots;

    public GameObject[] spawns;

    public GameObject catStatueInstance;

    public int catraxtorLv;

    public bool smartClick;
    public AudioSource musicBox;
    public int clickLevel;
    public int critLevel;
    public int multiplantLevel;
    public int catMultiplier;
    public int currClickValue;

    public GameObject newCat;
    public GameObject lv2Cat;
    public GameObject lv3Cat;
    public GameObject finalCat;
    public GameObject plantPrefab;
    public GameObject clickBot;

    public ParticleSystem bang;
    
    // Use this for initialization
    void Start () {
        currClickValue = 1;
        critLevel = 0;
        catMultiplier = 0;
        multiplantLevel = 1;
        lv1Cats = 0;
        lv2Cats = 0;
        lv3Cats = 0;
        plants = GameObject.FindGameObjectsWithTag("Plant");
        clickBots = GameObject.FindGameObjectsWithTag("ClickBot");
        for (int i = 0; i < clickBots.Length; i++)
        {
            clickBots[i].SetActive(false);
        }
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
        catStatueInstance = GameObject.Find("CatStatue");
        catStatueInstance.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void handlePurchase(string item, int cost)
    {
        clickCredits -= cost;
        if (item == "ClickPower")
        {
            buyClickPower();

        }
        else if (item == "CritClick")
        {
            buyCritClick();
        }
        else if (item == "CatPlant")
        {
            buyCatPlant();
        }
        else if (item == "MultiplantLevel")
        {
            buyMultiplantLevel();
        }
        else if (item == "Music")
        {
            buyMusic();
        }
        else if (item == "CatMultiplier")
        {
            buyCatMultiplier();
        }
        else if (item == "CatStatue")
        {
            buyCatStatue();
        }
        else if (item == "ClickBot")
        {
            buyClickBot();
        }
        else if (item == "NewCat")
        {
            buyNewCat();
        }
        else if (item == "Lv2Fusion")
        {
            buyLv2Fusion();
        }
        else if (item == "Lv3Fusion")
        {
            buyLv3Fusion();
        }
        else if (item == "Lv4Fusion")
        {
            buyLv4Fusion();
        }
    }

    private void buyClickPower()
    {
        currClickValue++;
    }

    private void buyCritClick()
    {
        critLevel++;
    }

    private void buyCatPlant()
    {
        for (int i = 0; i < plants.Length; i++)
        {
            if (plants[i].GetComponent<CatPlant>().isActive == false)
            {
                plants[i].GetComponent<CatPlant>().activate();
                break;
            }
        }
    }

    private void buyMultiplantLevel()
    {
        multiplantLevel++;
    }

    private void buyMusic()
    {
        //Change music here
        catMultiplier += 10;
        multiplantLevel += 10;
        clickLevel += 10;
        musicBox.clip = (AudioClip) Resources.Load("DreamCulture");
        musicBox.Play();
    }

    private void buyCatMultiplier()
    {
        catMultiplier++;
    }

    private void buyClickBot() {
        for (int i = 0; i < clickBots.Length; i++)
        {
            if (clickBots[i].activeInHierarchy == false)
            {
                clickBots[i].SetActive(true);
                clickBots[i].GetComponent<ClickBotScript>().activate();
                break;
            }
        }
    }


    private void buyCatStatue()
    {
        catStatueInstance.SetActive(true);
        catStatueInstance.GetComponent<CatStatueScript>().activateStatue();
    }

    private void buyNewCat()
    {
        lv1Cats++;
        Instantiate(newCat, spawns[0].transform.position, spawns[0].transform.rotation);
        cats = GameObject.FindGameObjectsWithTag("Cat"); 
    }
    
    private void buyLv2Fusion()
    {
        Instantiate(bang, spawns[0].transform.position, spawns[0].transform.rotation);
        int remainingCats = 2;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i] != null && cats[i].GetComponent<CatScript>().catLevel == 1 && remainingCats > 0)
            {
                //cats[i].GetComponent<CatScript>().poof();
                Destroy(cats[i]);
                remainingCats--;
            }
        }
        Instantiate(lv2Cat, spawns[0].transform.position, spawns[0].transform.rotation);
        cats = GameObject.FindGameObjectsWithTag("Cat");
    }

    private void buyLv3Fusion()
    {
        Instantiate(bang, spawns[0].transform.position, spawns[0].transform.rotation);
        int remainingCats = 3;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i] != null && cats[i].GetComponent<CatScript>().catLevel == 2 && remainingCats > 0)
            {
                //cats[i].GetComponent<CatScript>().poof();
                Destroy(cats[i]);
                remainingCats--;
            }
        }
        Instantiate(lv3Cat, spawns[0].transform.position, spawns[0].transform.rotation);
        cats = GameObject.FindGameObjectsWithTag("Cat");
    }

    private void buyLv4Fusion()
    {
        Instantiate(bang, spawns[0].transform.position, spawns[0].transform.rotation);
        int remainingCats = 4;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i] != null && cats[i].GetComponent<CatScript>().catLevel == 3 && remainingCats > 0)
            {
                //cats[i].GetComponent<CatScript>().poof();
                Destroy(cats[i]);
                remainingCats--;
            }
        }
        cats = GameObject.FindGameObjectsWithTag("Cat");
        Invoke("nani", 3.50f);

    }

    public int getNumCatsLevel(int num)
    {
        int count = 0;
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i] != null && cats[i].GetComponent<CatScript>().catLevel == num)
            {
                count++;
            }
        }
        return count;
    }

    void nani()
    {
        SceneManager.LoadScene("GoogleVR/Demos/Scenes/HelloVR_2");
    }
}
