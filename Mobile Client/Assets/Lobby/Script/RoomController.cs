using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.Collections.Generic;
using UnityEngine.UI;

public class RoomController : MonoBehaviourPunCallbacks
{
    //private List<RoomItem> roomItemsList = new List<RoomItem>();
    public GameObject readyButton;
    public GameObject unReadyButton;
    public GameObject backToLobbyButton;
    public GameObject roomPanel;
    public PlayerItem playerItemPrefab;
    public Transform playerListContent;
    private List<PlayerItem> playerItemsList = new List<PlayerItem>();
    private Hashtable playerCustomProperty = new Hashtable();
    private Player[] otherPlayers;
    public override void OnJoinedRoom()
    {
        roomPanel.SetActive(true);
        roomPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = PhotonNetwork.CurrentRoom.Name;
        otherPlayers = PhotonNetwork.PlayerListOthers;
        readyButton.SetActive(true);
        unReadyButton.SetActive(false);
        playerCustomProperty.Add("player_status", 0);
        playerCustomProperty.Add("player_type", "Mobile");
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperty);
    }

    public void Ready()
    {
        playerCustomProperty["player_status"] = 1;
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperty);
        backToLobbyButton.GetComponent<Button>().interactable = false;
        readyButton.SetActive(false);
        unReadyButton.SetActive(true);
    }

    public void UnReady()
    {
        playerCustomProperty["player_status"] = 0;
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperty);
        backToLobbyButton.GetComponent<Button>().interactable = true;
        unReadyButton.SetActive(false);
        readyButton.SetActive(true);
    }

    public void BackToLobby()
    {
        PhotonNetwork.LeaveRoom(true);
    }


    public override void OnPlayerLeftRoom(Player otherPlayer) // mobile player can not live without PC players
    {
        otherPlayers = PhotonNetwork.PlayerListOthers;
        if (otherPlayers.Length < 1)
        {
            PhotonNetwork.LeaveRoom(true);
        }
        else if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.SetMasterClient(otherPlayers[0]);
        }
        UpdatePlayerListing();
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        UpdatePlayerListing();
    }

    public override void OnLeftRoom()
    {
        playerCustomProperty.Clear();
        PhotonNetwork.LocalPlayer.SetCustomProperties(playerCustomProperty);
        roomPanel.SetActive(false);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        UpdatePlayerListing();
    }

    private void UpdatePlayerListing()
    {
        foreach (PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();
        int pcCount = 0;
        int mobileCount = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            PlayerItem newPlayer = Instantiate(playerItemPrefab, playerListContent);
            newPlayer.SetPlayerName(player.NickName);

            newPlayer.SetPlayerType((string)player.CustomProperties["player_type"]);
            if ((string)player.CustomProperties["player_type"] == "PC")
            {
                pcCount++;
            }
            else
            {
                mobileCount++;
            }

            if (player.IsMasterClient)
            {
                newPlayer.SetPlayerStatus("Host");
            }
            else if ((int)player.CustomProperties["player_status"] == 1)
            {
                newPlayer.SetPlayerStatus("Ready");
            }
            else
            {
                newPlayer.SetPlayerStatus("");
            }
            playerItemsList.Add(newPlayer);
        }
    }
}
