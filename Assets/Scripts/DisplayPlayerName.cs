using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class DisplayPlayerName : MonoBehaviour
{
    public TMP_Text playerName;
    Vector3 lookPos;

    // Start is called before the first frame update
    void Start()
    {
        playerName.text = PhotonNetwork.LocalPlayer.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        lookPos = Camera.main.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-lookPos), Time.deltaTime*3);
    }
}
