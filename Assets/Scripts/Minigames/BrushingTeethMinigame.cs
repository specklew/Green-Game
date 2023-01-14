using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System;

public class BrushingTeethMinigame : MonoBehaviour, IMinigame
{
    #region UI variables

    public GameObject result;
    public GameObject button1;
    public GameObject button2;
    public GameObject tapImage;
    public Image tapImageSource;

    public TextMeshProUGUI resultText;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;
    public Tap Tap { get; set; }
    private Stopwatch stopwatch;
    private double waterUsed;
    private int secondsWithTapTurnedOn;
    private Sprite openTap;
    private Sprite closedTap;

    public BrushingTeethMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        openTap = Resources.Load<Sprite>("Sprites/water_tap_open");
        closedTap = Resources.Load<Sprite>("Sprites/water_tap_closed");
        Tap = new Tap(0.25);
        StartMinigame();
    }

    public void Update()
    {
        //Not necessary to update the text fields
    }

    public void StartMinigame()
    {
        stopwatch = new Stopwatch();
        tapImageSource = tapImage.GetComponent<Image>();
        tapImageSource.sprite = closedTap;
        resultText = result.GetComponent<TextMeshProUGUI>();
        resultText.text = "";   
    }

    public void StartTap()
    {
        stopwatch.Start();
        tapImageSource.sprite = openTap;
    }

    public void StopTap()
    {
        stopwatch.Stop();
        double seconds = stopwatch.Elapsed.TotalSeconds;
        waterUsed = seconds * Tap.WaterUsedPerSecondInLiters;
        tapImageSource.sprite = closedTap;
    }

    public void CalculateEnvironmentPoints()
    {
        secondsWithTapTurnedOn = (int) Math.Round(stopwatch.Elapsed.TotalSeconds, 0);
        EnvironmentPoints = 3 - secondsWithTapTurnedOn / 20;
        if(EnvironmentPoints < -3) EnvironmentPoints = -3;
        //property of IPlayer should be accessed here to store the points, such property does not exist yet
        resultText.text = "Tap was open for " + secondsWithTapTurnedOn + " seconds,\nYou used " + Math.Round(waterUsed, 1) + " liters of water,\n" + "Your score: " + EnvironmentPoints;
        IsCompleted = true;
        MorbButtons();
    }

    public void MorbButtons()
    {

        var b1 = button1.GetComponent<Button>();
        b1.interactable = false;

        var b2 = button2.GetComponent<Button>();
        b2.interactable = false;

        //uncomment this when integrated with game manager
        //GameManager.Instance.AddPointsToCurrentPlayer(PointsType.AIR, EnvironmentPoints);
        //GameManager.Instance.SetTaskStatus("BrushingTeethMinigame", "done");
    }
}
