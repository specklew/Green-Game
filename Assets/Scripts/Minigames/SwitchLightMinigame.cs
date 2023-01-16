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

    public GameObject description;
    public GameObject bulbImage1;
    public GameObject bulbImage2;
    public GameObject bulbImage3;
    public GameObject bulbImage4;
    public GameObject bulbImage5;
    public GameObject bulbImage6;
    public GameObject onButton1;
    public GameObject onButton2;
    public GameObject onButton3;
    public GameObject onButton4;
    public GameObject onButton5;
    public GameObject onButton6;
    public GameObject offButton1;
    public GameObject offButton2;
    public GameObject offButton3;
    public GameObject offButton4;
    public GameObject offButton5;
    public GameObject offButton6;
    public GameObject result;

    public Image bulbImageSource1;
    public Image bulbImageSource2;
    public Image bulbImageSource3;
    public Image bulbImageSource4;
    public Image bulbImageSource5;
    public Image bulbImageSource6;

    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI resultText;

    private Sprite bulbOn;
    private Sprite bulbOff;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;

    public string buttonParameter;
    public List<Image> bulbs = new List<Image>();

    private Stopwatch stopwatch;
    private int seconds;

    private int bulbOnIndex1;
    private int bulbOnIndex2;
    public ulong PlayerId { get; set; }

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
        bulbImageSource5 = bulbImage5.GetComponent<Image>();
        bulbImageSource6 = bulbImage6.GetComponent<Image>();

        System.Random random = new System.Random();
        bulbOnIndex1 = random.Next(0, 6);
        bulbOnIndex2 = random.Next(0, 6);

        if (bulbOnIndex1 == bulbOnIndex2)
        {
            bulbOnIndex2 = bulbOnIndex1 - 1 < 0 ? 1 : bulbOnIndex1 - 1;
        }

        bulbImageSource1.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;
        bulbImageSource2.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;
        bulbImageSource3.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;
        bulbImageSource4.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;
        bulbImageSource5.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;
        bulbImageSource6.sprite = random.Next(0, 2) == 0 ? bulbOff : bulbOn;

        bulbs.Add(bulbImageSource1);
        bulbs.Add(bulbImageSource2);
        bulbs.Add(bulbImageSource3);
        bulbs.Add(bulbImageSource4);
        bulbs.Add(bulbImageSource5);
        bulbs.Add(bulbImageSource6);

        descriptionText = description.GetComponent<TextMeshProUGUI>();
        resultText = result.GetComponent<TextMeshProUGUI>();

        descriptionText.text += (bulbOnIndex1 + 1).ToString() + " and nr " + (bulbOnIndex2 + 1).ToString();
        resultText.text = "";   
    }

    public void TurnOnBulb1()
    {
        bulbImageSource1.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOnBulb2()
    {
        bulbImageSource2.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOnBulb3()
    {
        bulbImageSource3.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOnBulb4()
    {
        bulbImageSource4.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOnBulb5()
    {
        bulbImageSource5.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOnBulb6()
    {
        bulbImageSource6.sprite = bulbOn;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb1()
    {
        bulbImageSource1.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb2()
    {
        bulbImageSource2.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb3()
    {
        bulbImageSource3.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb4()
    {
        bulbImageSource4.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb5()
    {
        bulbImageSource5.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void TurnOffBulb6()
    {
        bulbImageSource6.sprite = bulbOff;
        FinishGameIfEndConditionIsMet();
    }

    public void FinishGameIfEndConditionIsMet()
    {
        for (int i = 0; i < bulbs.Count; i++)
        {
            if (bulbs[i].sprite == bulbOn && (i == bulbOnIndex1 || i == bulbOnIndex2))
            {
                continue;
            }

            if (bulbs[i].sprite == bulbOff && (i == bulbOnIndex1 || i == bulbOnIndex2))
            {
                return;
            }

            if (bulbs[i].sprite == bulbOn)
            {
                return;
            }
        }

        stopwatch.Stop();
        CalculateEnvironmentPoints();

        onButton1.gameObject.SetActive(false);
        onButton2.gameObject.SetActive(false);
        onButton3.gameObject.SetActive(false);
        onButton4.gameObject.SetActive(false);
        onButton5.gameObject.SetActive(false);
        onButton6.gameObject.SetActive(false);

        offButton1.gameObject.SetActive(false);
        offButton2.gameObject.SetActive(false);
        offButton3.gameObject.SetActive(false);
        offButton4.gameObject.SetActive(false);
        offButton5.gameObject.SetActive(false);
        offButton6.gameObject.SetActive(false);

        resultText.text = $"Your time: {seconds}s, your environment points: {EnvironmentPoints}";
    }

    public void CalculateEnvironmentPoints()
    {
        seconds = (int) Math.Round(stopwatch.Elapsed.TotalSeconds, 0);
        
        if (seconds < 6)
        {
            EnvironmentPoints = 3;
        }
        else if (seconds >= 6 && seconds <= 9)
        {
            EnvironmentPoints = 2;
        }
        else if (seconds > 9 && seconds < 15)
        {
            EnvironmentPoints = 1;
        }
        else
        {
            EnvironmentPoints = 0;
        }
        GameManager.Instance.AddPointsToPlayer(PlayerId, PointsType.AIR, EnvironmentPoints);
        GameManager.Instance.SetTaskStatus("SwitchLightMinigame", "done", PlayerId);
    }
}
