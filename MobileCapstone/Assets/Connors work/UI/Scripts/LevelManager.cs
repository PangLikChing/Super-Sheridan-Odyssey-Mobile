using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public int coinValue;
    public int numOfCoinsHeld;
    public int livesNum;

    public Text gameScore;
   // public Text gameLives;


    public UnityEvent Respawn;
    public UnityEvent GameOver;

    public Slider health;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    AudioSource coinSource;

    public AudioClip coinClip;

    //[SerializeField]
    public Dropdown spawnableItemsDropdown;

    public GameObject platformPrefab;
    private bool spawnPlatform;

    public GameObject wallPrefab;
    private bool spawnWall;

    public GameObject bulletPrefab;

    void Start()
    {
        //numOfCoinsHeld = 0;
        gameScore.text = "Score: " + numOfCoinsHeld;
        //gameLives.text = "Lives: " + livesNum;
        health.maxValue = 3.0f;
        health.value = 3.0f;
        coinSource = GetComponent<AudioSource>();
        spawnableItemsDropdown.options.Clear();

        List<string> spawnableItems = new List<string>();
        spawnableItems.Add("Nothing");
        spawnableItems.Add("Platform");
        spawnableItems.Add("Wood Wall");

        foreach(var spawnableItem in spawnableItems)
        {
            spawnableItemsDropdown.options.Add(new Dropdown.OptionData() { text = spawnableItem });
        }

        DropdownItemSelected(spawnableItemsDropdown);

        spawnableItemsDropdown.onValueChanged.AddListener(delegate
        {
            DropdownItemSelected(spawnableItemsDropdown);
        });

        spawnPlatform = true;
        spawnWall = true;

        wallPrefab = GameObject.Find("Wood Wall");
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        int dropdownIndex = dropdown.value;

        if (dropdown.options[dropdownIndex].text == "Platform")
        {

        }
        else if (dropdown.options[dropdownIndex].text == "Wood Wall")
        {

        }
        else
        {

        }

    }

    void Update()
    {
        int dropdownIndex = spawnableItemsDropdown.value;

        if (spawnableItemsDropdown.options[dropdownIndex].text == "Platform")
        {
            if (Input.GetMouseButton(0) && spawnPlatform == true)
            {
                //Debug.Log("I am working");
                StartCoroutine(SpawnPlatform());

            }
        }
        else if (spawnableItemsDropdown.options[dropdownIndex].text == "Wood Wall")
        {
            //Debug.Log("I got to spawn walls drop box if statment");
            if (Input.GetMouseButton(0) && spawnWall == true)
            {
                //Debug.Log("I got to spawn walls if statment");
                //Debug.Log("I am working");
                StartCoroutine(SpawnWall());

            }
        }
        else
        {

        }
    }

    IEnumerator SpawnPlatform()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.0f;       
        Vector3 objectPos = Camera.current.ScreenToWorldPoint(mousePos);
        //Instantiate(bulletPrefab, objectPos, Quaternion.identity);
        Instantiate(platformPrefab, objectPos, Quaternion.identity);
        spawnPlatform = false;
        yield return new WaitForSeconds(2);
        spawnPlatform = true;
    }

    IEnumerator SpawnWall()
    {
        //Debug.Log("I got to spawn walls method");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.0f;
        Vector3 objectPos = Camera.current.ScreenToWorldPoint(mousePos);
        //Instantiate(bulletPrefab, objectPos, Quaternion.identity);
        Instantiate(wallPrefab, objectPos, Quaternion.identity);
        spawnWall = false;
        yield return new WaitForSeconds(2);
        spawnWall = true;
    }

    public void KeepScore(int newCoinToBeAdded)
    {
        coinSource.clip = coinClip;
        coinSource.Play();
        numOfCoinsHeld = numOfCoinsHeld + (coinValue * newCoinToBeAdded);

        gameScore.text = "Score: " + numOfCoinsHeld;
        //gameLives.text = "Lives: " + livesNum;
    }

    void OnDisable()
    {
        PlayerPrefs.SetInt("Coins", numOfCoinsHeld);
    }

    public void OnPlayerDeath()
    {
        livesNum--;
        //gameLives.text = "Lives: " + livesNum;

        if (livesNum < 3)
        {
            heart3.SetActive(false);
        }

        if (livesNum < 2)
        {
            heart2.SetActive(false);
        }

        if (livesNum < 1)
        {
            heart1.SetActive(false);
        }


        if (livesNum > 0)
        {
            Respawn.Invoke();
        }
        else
        {
            GameOver.Invoke();
        }
    }

    public Slider GetHealthSliderInstance()
    {
        return health;
    }
}
