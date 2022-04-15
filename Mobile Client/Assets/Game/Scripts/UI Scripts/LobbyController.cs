using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputField))]
public class LobbyController : MonoBehaviourPunCallbacks
{
    // private TypedLobby privateLobby = new TypedLobby("privateLobby", LobbyType.Default);
    private Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();

    [SerializeField]
    private GameObject m_cancelButton;

    [SerializeField]
    private GameObject m_loadButton;

    [SerializeField]
    private GameObject m_createRoomButton;

    [SerializeField]
    private GameObject m_joinRoomButton;

    [SerializeField]
    private GameObject m_inputFieldName;

    [SerializeField]
    private GameObject m_lobbyHeading;

    [SerializeField]
    private GameObject m_inputFieldNewRoom;

    [SerializeField]
    private GameObject m_listOfRooms;

    public GameObject _inputPlayerFieldObject;
    private InputField _inputPlayerField;

    public GameObject _inputNewRoomFieldObject;
    private InputField _inputNewRoomField;

    public GameObject _listOfRoomsObject;
    private Dropdown _listOfRooms;

    //[SerializeField]
    //private GameObject m_listOfPlayers;
    //private Dropdown _listOfPlayers;

    List<string> m_dropOptions;

    string playerName;
    string newRoomName;
    string existingRoomName;

    bool createRoomClicked = false;
    bool firstTimeInScene;

    int _dropdownValue;
    string dropdownString;

    //int _dropdown2Value;
    //string dropdown2String;

    // Start is called before the first frame update
    void Start()
    {
        _inputPlayerField = GameObject.Find("InputFieldName").GetComponent<InputField>();
        _inputNewRoomField = GameObject.Find("InputFieldNewRoom").GetComponent<InputField>();
        _listOfRooms = GameObject.Find("ListofRooms").GetComponent<Dropdown>();
        //_listOfPlayers = GameObject.Find("ListofPlayers").GetComponent<Dropdown>();
        m_cancelButton.SetActive(false);
        m_createRoomButton.SetActive(false);
        m_joinRoomButton.SetActive(false);
        m_inputFieldName.SetActive(false);
        m_loadButton.SetActive(true);
        m_lobbyHeading.SetActive(false);
        m_inputFieldNewRoom.SetActive(false);
        m_listOfRooms.SetActive(false);
        //m_listOfPlayers.SetActive(false);
        firstTimeInScene = false;

    }

    void Update()
    {
        if (string.IsNullOrEmpty(PhotonNetwork.NickName) || firstTimeInScene == true)
        {

        }
        else
        {
            Debug.Log("Returned to the Lobby");
            Debug.Log("Nickname :" + PhotonNetwork.NickName);

            m_createRoomButton.SetActive(true);
            m_joinRoomButton.SetActive(true);
            m_inputFieldName.SetActive(false);
            m_lobbyHeading.SetActive(true);
            m_inputFieldNewRoom.SetActive(true);
            m_listOfRooms.SetActive(true);
            //m_listOfPlayers.SetActive(true);
            firstTimeInScene = true;
            PhotonNetwork.LeaveRoom();
        }
    }


    public void GetPlayerName()
    {
        playerName = _inputPlayerField.text;
        Debug.Log("Player name is " + playerName);

        if (string.IsNullOrEmpty(_inputPlayerField.text))
        {
            Debug.LogError("Player name is null or empty");
            return;
        }
        else
        {
            PhotonNetwork.NickName = playerName;
            m_createRoomButton.SetActive(false);
            m_joinRoomButton.SetActive(true);
            m_inputFieldName.SetActive(false);
            m_lobbyHeading.SetActive(true);
            m_inputFieldNewRoom.SetActive(false);
            m_listOfRooms.SetActive(true);
            //m_listOfPlayers.SetActive(true);

        }

    }

    public void GetNewRoomName()
    {
        newRoomName = _inputNewRoomField.text;
        Debug.Log("Room name is " + newRoomName);

        if (string.IsNullOrEmpty(_inputNewRoomField.text))
        {
            Debug.LogError("New Room name is null or empty");
            return;
        }

    }

    public void CreateNamedRoom()
    {
        if (string.IsNullOrEmpty(_inputNewRoomField.text))
        {
            Debug.LogError("New Room name is null or empty");
            return;
        }
        else
        {
            m_cancelButton.SetActive(true);
            m_createRoomButton.SetActive(false);
            m_joinRoomButton.SetActive(false);
            m_inputFieldNewRoom.SetActive(false);
            createRoomClicked = true;

            Debug.Log("Creating room " + newRoomName + " now");
            RoomOptions roomOpts = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
            PhotonNetwork.CreateRoom("Room" + newRoomName, roomOpts, TypedLobby.Default);
        }
    }

    public void GetExistingRoom()
    {
        _dropdownValue = _listOfRooms.value;
        dropdownString = _listOfRooms.options[_dropdownValue].text;
        Debug.Log("Selected Dropdown Name Is " + dropdownString);
    }

    //public void GetPlayerNickNames()
    //{
    //    //int numberOfPlayers = PhotonNetwork.CurrentRoom.Players.Count;
    //    //string[] playerNickNames;
    //    for (int i = 1; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
    //    {
    //        _listOfPlayers.options[i].text = PhotonNetwork.CurrentRoom.Players[i].NickName + " ";

    //    }

    //    //_dropdown2Value = _listOfRooms.value;
    //    //dropdown2String = _listOfRooms.options[_dropdown2Value].text;
    //    //Debug.Log("Selected Dropdown Name Is " + dropdown2String);
    //}


    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////
    /// </summary>
    public void JoinNamedRoom()
    {
        m_cancelButton.SetActive(true);
        m_createRoomButton.SetActive(false);
        m_joinRoomButton.SetActive(false);
        PhotonNetwork.JoinRoom("Room" + dropdownString);

        Debug.Log("Joined " + dropdownString);
    }

    public void Cancel()
    {
        m_cancelButton.SetActive(false);
        m_createRoomButton.SetActive(true);
        m_joinRoomButton.SetActive(true);
        m_inputFieldName.SetActive(false);
        m_lobbyHeading.SetActive(true);
        m_inputFieldNewRoom.SetActive(true);
        _inputNewRoomField.text = null;
        createRoomClicked = false;
        PhotonNetwork.LeaveRoom();

    }

    public override void OnConnectedToMaster()
    {
        m_loadButton.SetActive(false);
        m_inputFieldName.SetActive(true);

        PhotonNetwork.JoinLobby(TypedLobby.Default);

        PhotonNetwork.AutomaticallySyncScene = true;

        firstTimeInScene = true;
    }

    public override void OnJoinedLobby()
    {
        {
            Debug.Log("Joined Lobby");
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {

            }
            else
            {
                m_inputFieldName.SetActive(false);
            }

        }
    }

    private void UpdateCachedRoomList(List<RoomInfo> roomList)
    {
        List<string> workingList = new List<string>();
        int bInt = 0;
        int eInt = 0;
        string wString;

        existingRoomName = "";
        workingList.Add(existingRoomName);

        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];

            cachedRoomList[info.Name] = info;
            Debug.Log("cached room entry " + info);

            if (info.RemovedFromList)
            {
                cachedRoomList.Remove(info.Name);
            }
            else
            {
                // cachedRoomList[info.Name] = info;
                // Debug.Log("Before converting to string " + info);

                //Convert the room info to a string. Search the string for 'Room. This marks the position of the
                //start of the room name. Search the string for ' vi. This marks the position of the end of
                //the room name. Subtract the start position from the end position to get the number of characters
                //in the room name. Then use Substring to extract it.

                wString = info.ToString();
                bInt = wString.IndexOf("'Room");
                bInt = bInt + 5;
                eInt = wString.IndexOf("' vi");
                eInt = eInt - bInt;

                existingRoomName = wString.Substring(bInt, eInt);

                workingList.Add(existingRoomName);
            }
        }

        if (roomList.Count > 0)
        {
            _listOfRooms.AddOptions(workingList);
        }

        Debug.Log("Updated cached room list");
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateCachedRoomList(roomList);
    }

    public override void OnLeftLobby()
    {
        cachedRoomList.Clear();
        Debug.Log("Left privateLobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        cachedRoomList.Clear();
    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to join a room");

        if (createRoomClicked == true)
        {
            CreateNamedRoom();
        }
        else
        {
            m_cancelButton.SetActive(false);
            m_createRoomButton.SetActive(true);
            m_joinRoomButton.SetActive(true);
            return;
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create room. Try changing the name and click Create Room again.");
        Cancel();
    }

    public override void OnJoinedRoom()
    {
        if (createRoomClicked == true)
        {
            Debug.Log("Joined Room " + newRoomName);
            createRoomClicked = false;
        }
        else
        {
            Debug.Log("Joined Room");
        }

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            //PhotonNetwork.IsMessageQueueRunning = false;
            PhotonNetwork.LoadLevel(3);
            //GetPlayerNickNames();
            //////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }

    public void GoToSinglePlayer()
    {
        SceneManager.LoadScene("Connors scene");
    }
}
