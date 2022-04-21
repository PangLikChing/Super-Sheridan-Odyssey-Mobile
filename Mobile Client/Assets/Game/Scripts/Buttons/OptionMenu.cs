using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    public void QuitLobby()
    {
        // Quit the lobby

    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();

        Debug.Log("Quit");
    }
}
