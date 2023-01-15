using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpInvitation : MonoBehaviour
{
    public GameObject panel;
    public Button acceptButton;
    public Button declineButton;
    public Text inviteText;
    public string inviterName;
    private bool buttonClicked;
    private bool result;

    void Start()
    {
        panel.SetActive(false);
        acceptButton.onClick.AddListener(AcceptInvitation);
        declineButton.onClick.AddListener(DeclineInvitation);
    }

    public async Task<bool> ShowInvitation(string username)
    {
        inviterName = username;
        inviteText.text = inviterName + " has invited you";
        panel.SetActive(true);
        while (!buttonClicked)
        {
            await System.Threading.Tasks.Task.Delay(10);
        }

        return result;
    }

    void AcceptInvitation()
    {
        // Add your code here to handle the acceptance of the invitation
        buttonClicked = true;
        result = true;
        panel.SetActive(false);
    }

    void DeclineInvitation()
    {
        // Add your code here to handle the decline of the invitation
        buttonClicked = true;
        result = false;
        panel.SetActive(false);
    }
}
