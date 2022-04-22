using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RPCManager : MonoBehaviour
{
    public UnityEvent Victory;
    public UnityEvent GameOver;
    private PhotonView PV;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void GameWon()
    {
        Victory.Invoke();
    }

    [PunRPC]
    public void GameLost()
    {
        GameOver.Invoke();
    }
}
