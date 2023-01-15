using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShoppingMinigame : MonoBehaviour, IMinigame
{
    #region UI variables

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject item6;
    public GameObject result;
    public GameObject summary;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject buyButton;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI summaryText;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;
    public ulong PlayerId { get; set; }

    private List<ShopItem> shopItems;
    private bool[] selectedItems;
    private int maxItems;
    private int currentItems;

    public ShoppingMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        selectedItems = new bool[6];
        StartMinigame();
    }

    public void Update()
    {
        //Not necessary to update the text fields
    }

    public void DisplayShoppingList()
    {
        shopItems = ShopItem.GenerateRandomItems();
        text1.text = shopItems[0].Name;
        text2.text = shopItems[1].Name;
        text3.text = shopItems[2].Name;
        text4.text = shopItems[3].Name;
        text5.text = shopItems[4].Name;
        text6.text = shopItems[5].Name;
    }

    public void StartMinigame()
    {
        resultText = result.GetComponent<TextMeshProUGUI>();
        summaryText = summary.GetComponent<TextMeshProUGUI>();
        text1 = item1.GetComponent<TextMeshProUGUI>();
        text2 = item2.GetComponent<TextMeshProUGUI>();
        text3 = item3.GetComponent<TextMeshProUGUI>();
        text4 = item4.GetComponent<TextMeshProUGUI>();
        text5 = item5.GetComponent<TextMeshProUGUI>();
        text6 = item6.GetComponent<TextMeshProUGUI>();
        var bb = buyButton.GetComponent<Button>();
        bb.interactable = false;

        var rng = new System.Random();
        maxItems = rng.Next(1, 5);
        summaryText.text = GenerateSummaryString(maxItems, 0);
        resultText.text = "";
        DisplayShoppingList();    
    }

    public string GenerateSummaryString(int max, int current)
    {
        if(max == 1) return "Your shopping list may contain 1 item (" + (max - current) + " remaining)";
        return "Your shopping list may contain " + max + " items (" + (max - current) + " remaining)";
    }

    public void CalculateEnvironmentPoints()
    {
        
        for(int i = 0; i < 6; i++)
        {
            if(selectedItems[i])
            {
                EnvironmentPoints += shopItems[i].PointsValue; //property of IPlayer should be accessed here to store the points, such property does not exist yet
            }
        }
        resultText.text = "Your score: " + EnvironmentPoints;
        GameManager.Instance.AddCurrentPlayerGlobalScore(EnvironmentPoints);
        GameManager.Instance.AddPointsToCurrentPlayer(PointsType.LITTER, EnvironmentPoints);
        GameManager.Instance.AddPointsToCurrentPlayer(PointsType.WATER, EnvironmentPoints);
        GameManager.Instance.AddPointsToCurrentPlayer(PointsType.AIR, EnvironmentPoints);
        IsCompleted = true;
        MorbButtons();
    }

    public void I1ButtonOnClick()
    {
        selectedItems[0] = !selectedItems[0];
        var button = button1.GetComponent<Button>();

        if (selectedItems[0])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text1.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text1.color = Color.white;
        }
        UpdateList();
    }

    public void I2ButtonOnClick()
    {
        selectedItems[1] = !selectedItems[1];
        var button = button2.GetComponent<Button>();

        if (selectedItems[1])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text2.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text2.color = Color.white;
        }
        UpdateList();
    }

    public void I3ButtonOnClick()
    {
        selectedItems[2] = !selectedItems[2];
        var button = button3.GetComponent<Button>();

        if (selectedItems[2])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text3.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text3.color = Color.white;
        }
        UpdateList();
    }

    public void I4ButtonOnClick()
    {
        selectedItems[3] = !selectedItems[3];
        var button = button4.GetComponent<Button>();

        if (selectedItems[3])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text4.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text4.color = Color.white;
        }
        UpdateList();
    }

    public void I5ButtonOnClick()
    {
        selectedItems[4] = !selectedItems[4];
        var button = button5.GetComponent<Button>();

        if (selectedItems[4])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text5.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text5.color = Color.white;
        }
        UpdateList();
    }

    public void I6ButtonOnClick()
    {
        selectedItems[5] = !selectedItems[5];
        var button = button6.GetComponent<Button>();

        if (selectedItems[5])
        {
            button.GetComponentInChildren<TMP_Text>().text = "REMOVE";
            text6.color = Color.blue;
        }
        else
        {
            button.GetComponentInChildren<TMP_Text>().text = "ADD";
            text6.color = Color.white;
        }
        UpdateList();
    }

    public void UpdateList()
    {
        var buttons = new Button[6];
        buttons[0] = button1.GetComponent<Button>();
        buttons[1] = button2.GetComponent<Button>();
        buttons[2] = button3.GetComponent<Button>();
        buttons[3] = button4.GetComponent<Button>();
        buttons[4] = button5.GetComponent<Button>();
        buttons[5] = button6.GetComponent<Button>();


        currentItems = 0;
        for(int i = 0; i < 6; i++)
        {
            if(selectedItems[i]) currentItems++;
        }
        summaryText.text = GenerateSummaryString(maxItems, currentItems);
        if (currentItems < maxItems)
        {
            for(int i = 0; i < 6; i++)
            {
                buttons[i].interactable = true;
            }
            var bb = buyButton.GetComponent<Button>();
            bb.interactable = false;
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if(!selectedItems[i]) buttons[i].interactable = false;
            }
            var bb = buyButton.GetComponent<Button>();
            bb.interactable = true;
        }
    }


    public void MorbButtons()
    {
        var b1 = button1.GetComponent<Button>();
        b1.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[0].PointsValue.ToString();
        b1.interactable = false;

        var b2 = button2.GetComponent<Button>();
        b2.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[1].PointsValue.ToString();
        b2.interactable = false;

        var b3 = button3.GetComponent<Button>();
        b3.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[2].PointsValue.ToString();
        b3.interactable = false;

        var b4 = button4.GetComponent<Button>();
        b4.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[3].PointsValue.ToString();
        b4.interactable = false;

        var b5 = button5.GetComponent<Button>();
        b5.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[4].PointsValue.ToString();
        b5.interactable = false;

        var b6 = button6.GetComponent<Button>();
        b6.GetComponentInChildren<TMP_Text>().text = "score: " + shopItems[5].PointsValue.ToString();
        b6.interactable = false;
        

        //uncomment this when integrated with game manager
        //GameManager.Instance.AddPointsToCurrentPlayer(PointsType.AIR, EnvironmentPoints);
        //GameManager.Instance.SetTaskStatus("ShoppingMinigame", "done");
    }
}
