using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    public RoomInfo roomInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(RoomInfo room)
    {
        roomInfo = room;
        roomName.text = room.Name;
    }

    public void OnJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
