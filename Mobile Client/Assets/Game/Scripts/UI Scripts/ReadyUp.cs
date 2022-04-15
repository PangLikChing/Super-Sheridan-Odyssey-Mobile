using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{
    private int counter;
    public GameObject PlayerNotReady1;
    public GameObject PlayerNotReady2;
    public GameObject PlayerNotReady3;
    public GameObject PlayerNotReady4;
    public GameObject PlayerReady1;
    public GameObject PlayerReady2;
    public GameObject PlayerReady3;
    public GameObject PlayerReady4;
    public GameObject ReadyUpButton;
    public GameObject StartButton;

    public Text YouAreAText;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        //PlayerNotReady1 = GameObject.Find("Player1NotReady").GetComponent<GameObject>();
        //PlayerNotReady2 = GameObject.Find("Player2NotReady").GetComponent<GameObject>();
        //PlayerNotReady3 = GameObject.Find("Player3NotReady").GetComponent<GameObject>();
        //PlayerNotReady4 = GameObject.Find("Player4NotReady").GetComponent<GameObject>();
        //PlayerReady1 = GameObject.Find("Player1Button").GetComponent<GameObject>();
        //PlayerReady2 = GameObject.Find("Player2Button").GetComponent<GameObject>();
        //PlayerReady3 = GameObject.Find("Player3Button").GetComponent<GameObject>();
        //PlayerReady4 = GameObject.Find("Player4Button").GetComponent<GameObject>();
        //ReadyUpButton = GameObject.Find("ReadyUpButton").GetComponent<GameObject>();
        //StartButton = GameObject.Find("StartButton").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient == true)
        {
            YouAreAText.text = "You Are A Host";
        }
        else
        {
            YouAreAText.text = "You Are A Client";
        }

        if (counter == 1)
        {
            //PlayerNotReady1.SetActive(false);
            //PlayerReady1.SetActive(true);
            //ReadyUpButton.SetActive(false);
            //if (PhotonNetwork.CurrentRoom.Players.Count == 1)
            //{
            //    StartButton.SetActive(true);
            //}
            //ReadyUpButton.SetActive(false);

            if (PhotonNetwork.CurrentRoom.Players.Count == 1)
            {
                StartButton.SetActive(true);
                ReadyUpButton.SetActive(false);
            }

            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("DisableObject1", RpcTarget.All);
        }
        else if (counter == 2)
        {

            //ReadyUpButton.SetActive(false);
            if (PhotonNetwork.CurrentRoom.Players.Count == 2)
            {
                if (PhotonNetwork.IsMasterClient == true)
                {
                    StartButton.SetActive(true);
                }
                //StartButton.SetActive(true);
                ReadyUpButton.SetActive(false);
            }

            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("DisableObject2", RpcTarget.All);
        }
        else if (counter == 3)
        {
            PlayerNotReady3.SetActive(false);
            PlayerReady3.SetActive(true);
            ReadyUpButton.SetActive(false);
            if (PhotonNetwork.CurrentRoom.Players.Count == 3)
            {
                StartButton.SetActive(true);
            }
        }
        else if (counter == 4)
        {
            PlayerNotReady4.SetActive(false);
            PlayerReady4.SetActive(true);
            ReadyUpButton.SetActive(false);
            if (PhotonNetwork.CurrentRoom.Players.Count == 4)
            {
                StartButton.SetActive(true);
            }
        }
    }

    public void ReadyUpPlayer()
    {
        //counter = counter + 1;
        PhotonView pv = PhotonView.Get(this);
        counter = counter + 1;
        pv.RPC("IncreaseCounter", RpcTarget.OthersBuffered, counter);

    }

    //photonView.RPC("DisableChildObject", PhotonTargets.AllBuffered, player, false);
    //PhotonView photonView = PhotonView.Get(this);
    //photonView.RPC("SwordInHand", RpcTarget.All);


    [PunRPC]
    void DisableObject1()
    {
        PlayerNotReady1.SetActive(false);
        PlayerReady1.SetActive(true);

        //if (PhotonNetwork.CurrentRoom.Players.Count == 1)
        //{
        //    StartButton.SetActive(true);
        //}
    }

    [PunRPC]
    void DisableObject2()
    {
        PlayerNotReady2.SetActive(false);
        PlayerReady2.SetActive(true);

        //if (PhotonNetwork.CurrentRoom.Players.Count == 1)
        //{
        //    StartButton.SetActive(true);
        //}
    }

    [PunRPC]
    void IncreaseCounter(int myInt)
    {
        counter = myInt;
    }

    //[PunRPC]
    //void IncreaseCounter()
    //{
    //    counter = counter + 1;
    //}
}
