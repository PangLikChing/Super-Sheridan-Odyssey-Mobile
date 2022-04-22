using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPCManager : MonoBehaviour
{
    public GameObject winScreen, loseScreen;

    [PunRPC]
    public void OnVictory()
    {
        Debug.Log("I won");
        winScreen.SetActive(true);
    }

    [PunRPC]
    public void OnLose()
    {
        Debug.Log("I lose");
        loseScreen.SetActive(true);
    }
}
