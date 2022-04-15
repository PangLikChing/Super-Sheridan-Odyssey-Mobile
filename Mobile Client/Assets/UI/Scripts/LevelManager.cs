using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LevelManager : Singleton<LevelManager>
{
    public GameObject spawnPoint;
    public GameObject winTrigger;

    public int coinValue;
    public int numOfCoinsHeld;
    public int livesNum;

    public Text gameScore;
   // public Text gameLives;


    public UnityEvent Spawn;
    public UnityEvent GameOver;

    public Slider health;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    AudioSource coinSource;

    public AudioClip coinClip;

    public float respawnDelay = 5f;
    public float respawnTimer;
    private bool respawnCountDown;
    //private PlayerController playerController;

    void Start()
    {
        //numOfCoinsHeld = 0;
        gameScore.text = "Score: " + numOfCoinsHeld;
        //gameLives.text = "Lives: " + livesNum;
        health.maxValue = 3.0f;
        health.value = 3.0f;
        coinSource = GetComponent<AudioSource>();

        respawnTimer = 0;
        //playerController.playerData.PlayerDefeat.AddListener(OnPlayerDefeat);

        //playerController.playerData.UpdateHealth.AddListener(SetHealthUI);
        Cursor.visible = false;
    }

    void Update()
    {
        if (respawnCountDown)
        {
            respawnTimer -= Time.deltaTime;
        }

        if (respawnTimer <= 0)
        {
            Spawn.Invoke();
            GameObject gameobject = GameObject.Find("Player Controller");
            //playerController = gameobject.GetComponent<PlayerController>();
            //playerController.playerData.PlayerDefeat.AddListener(OnPlayerDefeat);
            //playerController.playerData.UpdateHealth.AddListener(SetHealthUI);
            //playerController.characterLocomotion.transform.position = spawnPoint.transform.position + Vector3.up * 0.05f;
            //playerController.characterLocomotion.transform.rotation = spawnPoint.transform.rotation;
            respawnTimer = respawnDelay;
            respawnCountDown = false;
        }
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

    public void SetHealthUI(float currenthealth)
    {
        health.value = currenthealth;
    }

    public void OnPlayerDefeat()
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
            respawnCountDown = true;
        }
        else
        {
            GameOver.Invoke();
        }
    }
}
