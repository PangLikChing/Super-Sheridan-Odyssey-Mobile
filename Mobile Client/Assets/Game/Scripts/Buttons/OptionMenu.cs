using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviourPunCallbacks
{
    public void QuitLobby()
    {

        PhotonNetwork.LeaveRoom();

    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        Debug.Log("Quit");
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
}
