using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserLogIn : MonoBehaviour
{
    public TMP_InputField usernameInput, passwordInput;
    public GameObject warningText;
    public GameObject logInPage, loadingPage;

    public LoadToServer connectToServer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(usernameInput.text == "" || passwordInput.text == "")
        {
            warningText.SetActive(false);
        }
    }

    public void LogIn()
    {
        if (usernameInput.text == "chip" && passwordInput.text == "1010")
        {
            connectToServer.ConnectServer();
            logInPage.SetActive(false);
            loadingPage.SetActive(true);
        }
        else
        {
            warningText.SetActive(true);
        }
    }
}
