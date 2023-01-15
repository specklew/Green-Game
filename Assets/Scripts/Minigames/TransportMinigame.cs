using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransportMinigame : MonoBehaviour, IMinigame
{
    #region UI variables

    public GameObject transport1;
    public GameObject transport2;
    public GameObject transport3;
    public GameObject transport4;
    public GameObject result;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public TextMeshProUGUI transport1Text;
    public TextMeshProUGUI transport2Text;
    public TextMeshProUGUI transport3Text;
    public TextMeshProUGUI transport4Text;
    public TextMeshProUGUI resultText;
    public Button button1Click;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;
    
    public ulong PlayerId { get; set; }

    private List<MeanOfTransport> displayedAvailableTransport;

    public TransportMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        StartMinigame();
    }

    public void Update()
    {
        //Not necessary to update the text fields
        //Why not delete it if it's not necessary?
    }

    public void DisplayListOfAvailableTransport()
    {
        displayedAvailableTransport = MeanOfTransport.GenerateRandomMeansOfTransport();
        transport1Text.text = displayedAvailableTransport[0].Name;
        transport2Text.text = displayedAvailableTransport[1].Name;
        transport3Text.text = displayedAvailableTransport[2].Name;
        transport4Text.text = displayedAvailableTransport[3].Name;
    }

    public void StartMinigame()
    {
        resultText = result.GetComponent<TextMeshProUGUI>();
        transport1Text = transport1.GetComponent<TextMeshProUGUI>();
        transport2Text = transport2.GetComponent<TextMeshProUGUI>();
        transport3Text = transport3.GetComponent<TextMeshProUGUI>();
        transport4Text = transport4.GetComponent<TextMeshProUGUI>();

        resultText.text = "";
        DisplayListOfAvailableTransport();    
    }

    public void CalculateEnvironmentPoints(MeanOfTransport chosenTransport)
    {
        EnvironmentPoints = chosenTransport.PointsValue;                    //property of IPlayer should be accessed here to store the points, such property does not exist yet
        resultText.text = "You selected " + chosenTransport.Name + ", Your score: " + EnvironmentPoints.ToString();
        GameManager.Instance.AddCurrentPlayerGlobalScore(EnvironmentPoints);
        GameManager.Instance.AddPointsToCurrentPlayer(PointsType.AIR, EnvironmentPoints);
    }

    public void T1ButtonOnClick()
    {
        CalculateEnvironmentPoints(displayedAvailableTransport[0]);
        transport1Text.color = Color.blue;
        IsCompleted = true;
        MorbButtons();
        
    }

    public void T2ButtonOnClick()
    {
        CalculateEnvironmentPoints(displayedAvailableTransport[1]);
        transport2Text.color = Color.blue;
        IsCompleted = true;
        MorbButtons();
    }

    public void T3ButtonOnClick()
    {
        CalculateEnvironmentPoints(displayedAvailableTransport[2]);
        transport3Text.color = Color.blue;
        IsCompleted = true;
        MorbButtons();
    }

    public void T4ButtonOnClick()
    {
        CalculateEnvironmentPoints(displayedAvailableTransport[3]);
        transport4Text.color = Color.blue;
        IsCompleted = true;
        MorbButtons();
    }

    public void MorbButtons()
    {
        var b1 = button1.GetComponent<Button>();
        b1.GetComponentInChildren<TMP_Text>().text = "score: " + displayedAvailableTransport[0].PointsValue.ToString();
        b1.interactable = false;

        var b2 = button2.GetComponent<Button>();
        b2.GetComponentInChildren<TMP_Text>().text = "score: " + displayedAvailableTransport[1].PointsValue.ToString();
        b2.interactable = false;

        var b3 = button3.GetComponent<Button>();
        b3.GetComponentInChildren<TMP_Text>().text = "score: " + displayedAvailableTransport[2].PointsValue.ToString();
        b3.interactable = false;

        var b4 = button4.GetComponent<Button>();
        b4.GetComponentInChildren<TMP_Text>().text = "score: " + displayedAvailableTransport[3].PointsValue.ToString();
        b4.interactable = false;
        
        //Need to extract this functionality to a separate method to avoid code repetition.
        GameManager.Instance.AddPointsToPlayer(PlayerId, PointsType.AIR, EnvironmentPoints);
        GameManager.Instance.SetTaskStatus("TransportMinigame", "done", PlayerId);
    }
}
