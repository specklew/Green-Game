using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PopUpHelpRequest : MonoBehaviour
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

    public async Task<bool> ShowHelpRequest(string username)
    {
        inviterName = username;
        inviteText.text = inviterName + " has requested you to help.";
        panel.SetActive(true);
        while (!buttonClicked)
        {
            await System.Threading.Tasks.Task.Delay(10);
        }

        return result;
    }

    void AcceptInvitation()
    {
        buttonClicked = true;
        result = true;
        panel.SetActive(false);
    }

    void DeclineInvitation()
    {
        buttonClicked = true;
        result = false;
        panel.SetActive(false);
    }
}
