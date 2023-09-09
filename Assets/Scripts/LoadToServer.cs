using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LoadToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject loadingScene, lobbyScene, roomScene;
    [SerializeField] private TMP_Text roomNameText;

    [SerializeField] private Transform playerList;
    [SerializeField] private GameObject player;

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

    public void CreateRoom()
    {
        PhotonNetwork.NickName = "Chip";
        PhotonNetwork.CreateRoom("Room 1");
        lobbyScene.SetActive(false);
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
}
