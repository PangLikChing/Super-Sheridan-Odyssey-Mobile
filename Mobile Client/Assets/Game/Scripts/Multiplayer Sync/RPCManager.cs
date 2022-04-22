using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPCManager : MonoBehaviour, IOnEventCallback
{
    public UnityEvent gameWon;
    public UnityEvent gameLost;
    public GameObject winScreen;
    public GameObject loseScreen;
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;
        if (eventCode == 0)
        {
            int data = (int)photonEvent.CustomData;
            if (data == 0)
            {
                gameWon.Invoke();
                Debug.Log("win");
                winScreen.SetActive(true);
            }
            else
            {
                gameLost.Invoke();
                loseScreen.SetActive(true);
            }
        }
    }
}
