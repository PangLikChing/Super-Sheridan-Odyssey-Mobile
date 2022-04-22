using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviourPunCallbacks
{
    public void QuitLobby()
    {
        if(PhotonNetwork.CurrentRoom!=null)
            PhotonNetwork.LeaveRoom();
        else
            SceneManager.LoadScene(0);

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
