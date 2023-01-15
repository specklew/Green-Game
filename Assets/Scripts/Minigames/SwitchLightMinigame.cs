using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System;

public class SwitchLightMinigame : MonoBehaviour, IMinigame
{
    #region UI variables

    public GameObject result;
    public GameObject offButton1;
    public GameObject offButton2;
    public GameObject offButton3;
    public GameObject offButton4;
    public GameObject bulbImage1;
    public GameObject bulbImage2;
    public GameObject bulbImage3;
    public GameObject bulbImage4;
    public GameObject button;

    public Image bulbImageSource1;
    public Image bulbImageSource2;
    public Image bulbImageSource3;
    public Image bulbImageSource4;
    public Button doneButton;

    public TextMeshProUGUI resultText;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;
    public ulong PlayerId { get; set; }
    private Stopwatch stopwatch;
    private int seconds;

    private Sprite bulbOn;
    private Sprite bulbOff;

    public SwitchLightMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        bulbOn = Resources.Load<Sprite>("Sprites/bulb_on");
        bulbOff = Resources.Load<Sprite>("Sprites/bulb_off");

        StartMinigame();
    }

    public void Update()
    {

    }

    public void StartMinigame()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();

        bulbImageSource1 = bulbImage1.GetComponent<Image>();
        bulbImageSource2 = bulbImage2.GetComponent<Image>();
        bulbImageSource3 = bulbImage3.GetComponent<Image>();
        bulbImageSource4 = bulbImage4.GetComponent<Image>();

        bulbImageSource1.sprite = bulbOn;
        bulbImageSource2.sprite = bulbOn;
        bulbImageSource3.sprite = bulbOn;
        bulbImageSource4.sprite = bulbOn;

        //doneButton = button.GetCompoment<Button>();

        resultText = result.GetComponent<TextMeshProUGUI>();
        resultText.text = "";   
    }

    public void TurnOffBulb1()
    {
        bulbImageSource1.sprite = bulbOff;
    }

    public void TurnOffBulb2()
    {
        bulbImageSource2.sprite = bulbOff;
    }

    public void TurnOffBulb3()
    {
        bulbImageSource3.sprite = bulbOff;
    }

    public void TurnOffBulb4()
    {
        bulbImageSource4.sprite = bulbOff;
    }

    public void DoneButton()
    {
        if (bulbImageSource1.sprite == bulbOn ||
            bulbImageSource2.sprite == bulbOn ||
            bulbImageSource3.sprite == bulbOn ||
            bulbImageSource4.sprite == bulbOn)
        {
            return;
        }

        stopwatch.Stop();
        CalculateEnvironmentPoints();
        //doneButton.gameObject.SetActive(false);
        resultText.text = $"Your time: {seconds}s, your environment points: {EnvironmentPoints}";
    }

    public void CalculateEnvironmentPoints()
    {
        seconds = (int) Math.Round(stopwatch.Elapsed.TotalSeconds, 0);
        
        if (seconds < 3)
        {
            EnvironmentPoints = 3;
        }
        else if (seconds >= 3 && seconds <= 5)
        {
            EnvironmentPoints = 2;
        }
        else if (seconds > 5 && seconds < 7)
        {
            EnvironmentPoints = 1;
        }
        else
        {
            EnvironmentPoints = 0;
        }
    }

    public void MorbButtons()
    {

        var b1 = offButton1.GetComponent<Button>();
        b1.interactable = false;

        var b2 = offButton2.GetComponent<Button>();
        b2.interactable = false;

        var b3 = offButton3.GetComponent<Button>();
        b2.interactable = false;

        var b4 = offButton4.GetComponent<Button>();
        b2.interactable = false;
    }
}
