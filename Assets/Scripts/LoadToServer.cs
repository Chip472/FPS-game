using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LoadToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject loadingScene, lobbyScene, findRoomScene, nameRoomScene, roomScene;
    [SerializeField] private TMP_Text roomNameText;

    [SerializeField] private Transform playerList, roomContainer;
    [SerializeField] private GameObject player, room;

    [SerializeField] private TMP_InputField roomNameInput;
    [SerializeField] private TMP_Text warningRoomName, warningName;
    [SerializeField] private PlayerNameManager playerName;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting to master");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        GameObject playerTxt = Instantiate(player, playerList);
        playerTxt.GetComponent<TMP_Text>().text = newPlayer.NickName;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Join lobby");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loadingScene.SetActive(false);
        lobbyScene.SetActive(true);
    }

    public void FindRoom()
    {
        lobbyScene.SetActive(false);
        findRoomScene.SetActive(true);
    }

    public void NameRoom()
    {
        if (string.IsNullOrWhiteSpace(playerName.inputName.text))
        {
            warningName.text = "PLEASE ENTER A VALID NICKNAME!";
            return;
        }
        lobbyScene.SetActive(false);
        nameRoomScene.SetActive(true);
    }

    public void NameRoomBack()
    {
        lobbyScene.SetActive(true);
        nameRoomScene.SetActive(false);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrWhiteSpace(roomNameInput.text))
        {
            warningRoomName.text = "PLEASE ENTER A VALID ROOM NAME!";
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInput.text);
        nameRoomScene.SetActive(false);
        roomScene.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joing room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;


        foreach (Transform child in playerList)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i< players.Length; i++)
        {
            GameObject playerTxt = Instantiate(player, playerList);
            playerTxt.GetComponent<TMP_Text>().text = players[i].NickName;
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);

        foreach (Transform child in roomContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i< roomList.Count; i++)
        {
            Instantiate(room, roomContainer).GetComponent<RoomListItem>().Setup(roomList[i]);

        }
    }
}
