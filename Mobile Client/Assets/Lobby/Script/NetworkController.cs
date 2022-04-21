using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class NetworkController : MonoBehaviourPunCallbacks
{
    private string playerName;
    public GameObject menuPanel;
    public GameObject lobbyPanel;
    public StatusMsg statusMsg;
    public 
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            menuPanel.SetActive(true);
            statusMsg.SetStatusMsg("Client Offline");
        }
        else
        {
            lobbyPanel.SetActive(true);
            statusMsg.SetStatusMsg("");
        }
    }

    public override void OnConnectedToMaster()
    {
        statusMsg.SetStatusMsg(PhotonNetwork.LocalPlayer.NickName + " is now connected to the " + PhotonNetwork.CloudRegion + " server!");
        menuPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        playerName = null;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby();
    }

    public void Play()
    {
        if (!string.IsNullOrEmpty(playerName))
        {
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
            statusMsg.SetStatusMsg("Connecting");
        }
        else
        {
            statusMsg.SetStatusMsg("Player name is required");
        }
        Debug.Log("Play clicked");
    }
    public void Quit()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }

    public void SetPlayerName(TMP_InputField input)
    {
        playerName = input.text;
        Debug.Log(playerName);
    }
}
