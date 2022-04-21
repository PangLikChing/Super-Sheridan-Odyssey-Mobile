using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class LobbyController : MonoBehaviourPunCallbacks
{
    private float nextUpdateTime;
    private List<RoomItem> roomItemsList = new List<RoomItem>();
    private Hashtable roomCustomProperty = new Hashtable();
    private int maxMobilePlayer = 1;
    [HideInInspector]
    public float timeBetweenUpdates = 1.5f;
    public string selectRoomName = null;
    public Transform contentObject;
    public RoomItem roomItemPrefab;
    public GameObject lobbyPanel;
    public StatusMsg statusMsg;


    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();
        Debug.Log("Joined: " + PhotonNetwork.CurrentRoom.Name);
    }

    public void JoinRoom()
    {
        if (!string.IsNullOrEmpty(selectRoomName) )
        {
            PhotonNetwork.JoinRoom(selectRoomName);
            selectRoomName = null;
            
        }
        else
        {
            statusMsg.SetStatusMsg("You need to select a room first");
        }
        
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach (RoomInfo room in roomList)
        {
            int index = roomItemsList.FindIndex(x => x.roomName.text == room.Name);
            if (index == -1)
            {
                if(!room.RemovedFromList && (int)room.CustomProperties["Mobile_Count"] < maxMobilePlayer)
                {
                    RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
                    newRoom.SetRoomName(room.Name);
                    roomItemsList.Add(newRoom);
                }
            }
            else
            {
                if (room.RemovedFromList || (int)room.CustomProperties["Mobile_Count"] >= maxMobilePlayer)
                {
                    Destroy(roomItemsList[index].gameObject);
                    roomItemsList.RemoveAt(index);
                }
            }
            //else maintain list
        }
    }

    public override void OnLeftRoom()
    {
        roomCustomProperty.Clear();
        if(lobbyPanel!=null)
        lobbyPanel.SetActive(true);
    }

}
