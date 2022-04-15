using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MultiplayerPlayerList : MonoBehaviour
{
    [SerializeField]
    private GameObject m_listOfPlayers;
    private Dropdown _listOfPlayers;
    Dropdown.OptionData nickNameToAdd;
    Dropdown.OptionData nickNameToAdd2;
    Dropdown.OptionData nickNameToAdd3;
    Dropdown.OptionData nickNameToAdd4;
    private List<Dropdown.OptionData> NamesToShow = new List<Dropdown.OptionData>();

    //private string test;

    public Text placeholderText;

    private string name1;
    private string name2;
    private string name3;
    private string name4;

    public Text player1Text;
    public Text player2Text;
    public Text player3Text;
    public Text player4Text;

    private void Awake()
    {
       // _listOfPlayers = GameObject.Find("ListofPlayers").GetComponent<Dropdown>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("TEst Message " + _listOfPlayers.options[1].text);
       // PhotonNetwork.IsMessageQueueRunning = true;
        //_listOfPlayers = GameObject.Find("ListofPlayers").GetComponent<Dropdown>();
        nickNameToAdd = new Dropdown.OptionData();
        nickNameToAdd2 = new Dropdown.OptionData();
        nickNameToAdd3 = new Dropdown.OptionData();
        nickNameToAdd4 = new Dropdown.OptionData();

        player1Text = GameObject.Find("Player1Text").GetComponent<Text>();
        player2Text = GameObject.Find("Player2Text").GetComponent<Text>();
        player3Text = GameObject.Find("Player3Text").GetComponent<Text>();
        player4Text = GameObject.Find("Player4Text").GetComponent<Text>();

        //for (int i = 0; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
        //{
        //    _listOfPlayers.options[i].text = PhotonNetwork.CurrentRoom.Players[i].NickName + " ";
        //}
        //_listOfPlayers.options[1].text = PhotonNetwork.CurrentRoom.Players[1].NickName + " ";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PhotonNetwork.PlayerList[0]);
        //List<string> sdkjhf;

        //string[] namesArray = PhotonNetwork.PlayerList.ToString();

        // NamesToShow.Clear();
        // NamesToShow.Clear();
        // _listOfPlayers.ClearOptions();

        //Dictionary<int, Photon.Realtime.Player> pList = Photon.Pun.PhotonNetwork.CurrentRoom.Players;
        //foreach (KeyValuePair<int, Photon.Realtime.Player> p in pList)
        //{
        //    Debug.Log("New Test MEssage "+p.Value.NickName);
        //    //string test = PhotonNetwork.CurrentRoom.Players[i].NickName;
        //}

        if (PhotonNetwork.CurrentRoom.Players.Count == 1)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Players[1].NickName);
            player1Text.text = PhotonNetwork.CurrentRoom.Players[1].NickName;
            name1 = PhotonNetwork.CurrentRoom.Players[1].NickName;
            //nickNameToAdd.text = name1;
            //NamesToShow.Add(nickNameToAdd);

            //_listOfPlayers.AddOptions(NamesToShow);

        }
        if (PhotonNetwork.CurrentRoom.Players.Count == 2)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Players[1].NickName);
            player1Text.text = PhotonNetwork.CurrentRoom.Players[1].NickName;
            player2Text.text = PhotonNetwork.CurrentRoom.Players[2].NickName;
            name2 = PhotonNetwork.CurrentRoom.Players[1].NickName;
            //nickNameToAdd2.text = name2;
            //NamesToShow.Add(nickNameToAdd);
            //NamesToShow.Add(nickNameToAdd2);

            //_listOfPlayers.AddOptions(NamesToShow);

        }
        else if (PhotonNetwork.CurrentRoom.Players.Count == 3)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.Players[1].NickName);
            player1Text.text = PhotonNetwork.CurrentRoom.Players[1].NickName;
            player2Text.text = PhotonNetwork.CurrentRoom.Players[2].NickName;
            player3Text.text = PhotonNetwork.CurrentRoom.Players[3].NickName;
            name3 = PhotonNetwork.CurrentRoom.Players[1].NickName;
            //nickNameToAdd3.text = name3;
            //NamesToShow.Add(nickNameToAdd);
            //NamesToShow.Add(nickNameToAdd2);
            //NamesToShow.Add(nickNameToAdd3);

            //_listOfPlayers.AddOptions(NamesToShow);

        }
        else if (PhotonNetwork.CurrentRoom.Players.Count == 4)
        {

            Debug.Log(PhotonNetwork.CurrentRoom.Players[1].NickName);
            player1Text.text = PhotonNetwork.CurrentRoom.Players[1].NickName;
            player2Text.text = PhotonNetwork.CurrentRoom.Players[2].NickName;
            player3Text.text = PhotonNetwork.CurrentRoom.Players[3].NickName;
            player4Text.text = PhotonNetwork.CurrentRoom.Players[4].NickName;
            //name4 = PhotonNetwork.CurrentRoom.Players[1].NickName;
            //nickNameToAdd4.text = name4;
            //NamesToShow.Add(nickNameToAdd);
            //NamesToShow.Add(nickNameToAdd2);
            //NamesToShow.Add(nickNameToAdd3);
            //NamesToShow.Add(nickNameToAdd4);

            //_listOfPlayers.AddOptions(NamesToShow);
        }

        //_listOfPlayers.AddOptions(NamesToShow);
        //for (int i = 1; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
        //{
        //Debug.Log("Photon message "+PhotonNetwork.CurrentRoom.Players[i].NickName + " " + i);

        //string test = PhotonNetwork.CurrentRoom.Players[i].NickName;
        // string test = namesArray[i];

        //placeholderText.text = test;
        //Debug.Log("Test message "+test);
        //nickNameToAdd.text = test;
        //Debug.Log("nickNameToAdd message "+ nickNameToAdd.text);
        //NamesToShow.Add(nickNameToAdd);
        //Debug.Log("nickNameToAdd message " + NamesToShow.ToString());

        //}

        //Debug.Log(PhotonNetwork.PlayerList[0]);

        //if (PhotonNetwork.CurrentRoom.Players.Count == 1)
        //{
        //    Debug.Log("There are 1 players in the lobby");
        //    string test = PhotonNetwork.PlayerList[0].ToString();
        //    nickNameToAdd.text = test;
        //    NamesToShow.Add(nickNameToAdd);
        //}
        //else if (PhotonNetwork.CurrentRoom.Players.Count == 2)
        //{
        //    Debug.Log("There are 2 players in the lobby");
        //    string test = PhotonNetwork.PlayerList[0].ToString();
        //    string test2 = PhotonNetwork.PlayerList[1].ToString();
        //    nickNameToAdd.text = test;
        //    nickNameToAdd2.text = test2;
        //    NamesToShow.Add(nickNameToAdd);
        //    NamesToShow.Add(nickNameToAdd2);
        //}
        //else if (PhotonNetwork.CurrentRoom.Players.Count == 3)
        //{
        //    Debug.Log("There are 3 players in the lobby");
        //    string test = PhotonNetwork.CurrentRoom.Players[1].NickName;
        //    string test2 = PhotonNetwork.CurrentRoom.Players[2].NickName;
        //    string test3 = PhotonNetwork.CurrentRoom.Players[3].NickName;
        //    nickNameToAdd.text = test;
        //    nickNameToAdd2.text = test2;
        //    nickNameToAdd3.text = test3;
        //    NamesToShow.Add(nickNameToAdd);
        //    NamesToShow.Add(nickNameToAdd2);
        //    NamesToShow.Add(nickNameToAdd3);
        //}
        //else if (PhotonNetwork.CurrentRoom.Players.Count == 4)
        //{
        //    Debug.Log("There are 4 players in the lobby");
        //    string test = PhotonNetwork.CurrentRoom.Players[1].NickName;
        //    string test2 = PhotonNetwork.CurrentRoom.Players[2].NickName;
        //    string test3 = PhotonNetwork.CurrentRoom.Players[3].NickName;
        //    string test4 = PhotonNetwork.CurrentRoom.Players[4].NickName;
        //    nickNameToAdd.text = test;
        //    nickNameToAdd2.text = test2;
        //    nickNameToAdd3.text = test3;
        //    nickNameToAdd4.text = test4;
        //    NamesToShow.Add(nickNameToAdd);
        //    NamesToShow.Add(nickNameToAdd2);
        //    NamesToShow.Add(nickNameToAdd3);
        //    NamesToShow.Add(nickNameToAdd4);
        //}

        //_listOfPlayers.ClearOptions();
        //_listOfPlayers.AddOptions(NamesToShow);

        //foreach (PhotonPlayer p in PhotonNetwork.playerList)
        //{
        //    string nickName = p.NickName;
        //}

        //_listOfPlayers.options = NamesToShow;

    }

    public void GetPlayerNickNames()
    {
        //int numberOfPlayers = PhotonNetwork.CurrentRoom.Players.Count;
        //string[] playerNickNames;

        //for (int i = 1; i <= PhotonNetwork.CurrentRoom.Players.Count; i++)
        //{
        //    Debug.Log(PhotonNetwork.CurrentRoom.Players[i].NickName + " " + i);
        //    string test = PhotonNetwork.CurrentRoom.Players[i].NickName;
        //    nickNameToAdd.text = test;
        //    NamesToShow.Add(nickNameToAdd);
        //    _listOfPlayers.options = NamesToShow;
        //}

        //_dropdown2Value = _listOfRooms.value;
        //dropdown2String = _listOfRooms.options[_dropdown2Value].text;
        //Debug.Log("Selected Dropdown Name Is " + dropdown2String);
    }

    //[PunRPC]
    //void DisableChildObject(string mainObject, string childObject, bool setActive)
    //{
    //    GameObject.Find(mainObject).transform.FindChild(childObject).gameObject.SetActive(setActive);
    //}
}
