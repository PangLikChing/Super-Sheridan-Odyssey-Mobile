using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartLobbyGame()
    {
        PhotonNetwork.JoinRoom("Room" + PhotonNetwork.CurrentRoom.Players[1].NickName);
        PhotonNetwork.LoadLevel(1);
    }
}
