using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text playerName;
    public TMP_Text playerStatus;
    public TMP_Text playerType;

    public void SetPlayerName(string name)
    {
        playerName.text = name;
    }

    public void SetPlayerType(string type)
    {
        playerType.text = type;
    }

    public void SetPlayerStatus(string name)
    {
        playerStatus.text = name;
    }
}
