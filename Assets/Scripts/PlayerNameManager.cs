using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField inputName;
    [SerializeField] private TMP_Text warning;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("playerName");
            inputName.text = PlayerPrefs.GetString("playerName");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUserInputValueChange()
    {
        PhotonNetwork.NickName = inputName.text;
        PlayerPrefs.SetString("playerName", inputName.text);
        warning.text = "ENTER NICKNAME:";
    }
}
