using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class StatusMsg : MonoBehaviourPunCallbacks
{
    public TMP_Text errorMsg;

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        SetStatusMsg("Failed to create room");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        SetStatusMsg("Failed to join that room");
    }

    public void SetStatusMsg(string _msg)
    {
        errorMsg.text = _msg;
    }
}
