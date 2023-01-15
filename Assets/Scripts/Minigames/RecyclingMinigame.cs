using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecyclingMinigame : MonoBehaviour, IMinigame
{
    #region UI variables

    public GameObject result;
    public GameObject rubbish1;
    public GameObject rubbish2;
    public GameObject rubbish3;
    public GameObject rubbish4;
    public GameObject rubbish5;
    public GameObject rubbish6;
    public GameObject rubbish7;
    public GameObject rubbish8;
    public GameObject rubbish9;
    public GameObject rubbish10;
    public GameObject rubbish11;
    public GameObject rubbish12;
    public GameObject container1;
    public GameObject container2;
    public GameObject container3;
    public GameObject container4;

    public Image rubbishImage1;
    public Image rubbishImage2;
    public Image rubbishImage3;
    public Image rubbishImage4;
    public Image rubbishImage5;
    public Image rubbishImage6;
    public Image rubbishImage7;
    public Image rubbishImage8;
    public Image rubbishImage9;
    public Image rubbishImage10;
    public Image rubbishImage11;
    public Image rubbishImage12;
    public Image rubbishContainerImage1;
    public Image rubbishContainerImage2;
    public Image rubbishContainerImage3;
    public Image rubbishContainerImage4;

    public TextMeshProUGUI resultText;

    #endregion

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;

    private List<KeyValuePair<Rubbish, Image>> rubbishList;
    private KeyValuePair<Rubbish, Image> currentRubbish;
    private int correctAnswers;

    public RecyclingMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        StartMinigame();
    }

    void Update()
    {

    }

    public void StartMinigame()
    {
        rubbishList = new List<KeyValuePair<Rubbish, Image>>();

        Rubbish rubbishObj1 = new Rubbish("Apple", "brown");
        Rubbish rubbishObj2 = new Rubbish("Fish", "brown");
        Rubbish rubbishObj3 = new Rubbish("Egg", "brown");
        Rubbish rubbishObj4 = new Rubbish("Jar", "green");
        Rubbish rubbishObj5 = new Rubbish("WhiteBottle", "green");
        Rubbish rubbishObj6 = new Rubbish("GreenBottle", "green");
        Rubbish rubbishObj7 = new Rubbish("PaperBag", "blue");
        Rubbish rubbishObj8 = new Rubbish("PaperSheet", "blue");
        Rubbish rubbishObj9 = new Rubbish("PaperSheets", "blue");
        Rubbish rubbishObj10 = new Rubbish("PlasticBottle", "yellow");
        Rubbish rubbishObj11 = new Rubbish("PlasticBag", "yellow");
        Rubbish rubbishObj12 = new Rubbish("Can", "yellow");

        rubbishImage1 = rubbish1.GetComponent<Image>();
        rubbishImage2 = rubbish2.GetComponent<Image>();
        rubbishImage3 = rubbish3.GetComponent<Image>();
        rubbishImage4 = rubbish4.GetComponent<Image>();
        rubbishImage5 = rubbish5.GetComponent<Image>();
        rubbishImage6 = rubbish6.GetComponent<Image>();
        rubbishImage7 = rubbish7.GetComponent<Image>();
        rubbishImage8 = rubbish8.GetComponent<Image>();
        rubbishImage9 = rubbish9.GetComponent<Image>();
        rubbishImage10 = rubbish10.GetComponent<Image>();
        rubbishImage11 = rubbish11.GetComponent<Image>();
        rubbishImage12 = rubbish12.GetComponent<Image>();

        rubbishContainerImage1 = container1.GetComponent<Image>();
        rubbishContainerImage2 = container2.GetComponent<Image>();
        rubbishContainerImage3 = container3.GetComponent<Image>();
        rubbishContainerImage4 = container4.GetComponent<Image>();

        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj1, rubbishImage1));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj2, rubbishImage2));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj3, rubbishImage3));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj4, rubbishImage4));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj5, rubbishImage5));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj6, rubbishImage6));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj7, rubbishImage7));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj8, rubbishImage8));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj9, rubbishImage9));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj10, rubbishImage10));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj11, rubbishImage11));
        rubbishList.Add(new KeyValuePair<Rubbish, Image>(rubbishObj12, rubbishImage12));

        System.Random random = new System.Random();

        rubbishList = rubbishList.OrderBy(a => random.Next(0, 100000)).ToList();

        rubbishList[0].Value.gameObject.SetActive(true);
        currentRubbish = rubbishList[0];
    }

    public void OnBrownContainerClick()
    {
        if (currentRubbish.Key.ContainerColor == "brown")
        {
            correctAnswers++;
        }

        rubbishList[0].Value.gameObject.SetActive(false);

        if (rubbishList.Count > 1)
        {
            rubbishList.RemoveAt(0);
            rubbishList[0].Value.gameObject.SetActive(true);
        } 
        else
        {

        }

    }

    public void OnGreenContainerClick()
    {
        if (currentRubbish.Key.ContainerColor == "green")
        {
            correctAnswers++;
        }

        rubbishList[0].Value.gameObject.SetActive(false);

        if (rubbishList.Count > 1)
        {
            rubbishList.RemoveAt(0);
            rubbishList[0].Value.gameObject.SetActive(true);
        }
        else
        {

        }
    }

    public void OnBlueContainerClick()
    {
        if (currentRubbish.Key.ContainerColor == "blue")
        {
            correctAnswers++;
        }

        rubbishList[0].Value.gameObject.SetActive(false);

        if (rubbishList.Count > 1)
        {
            rubbishList.RemoveAt(0);
            rubbishList[0].Value.gameObject.SetActive(true);
        }
        else
        {

        }
    }

    public void OnYellowContainerClick()
    {
        if (currentRubbish.Key.ContainerColor == "yellow")
        {
            correctAnswers++;
        }

        rubbishList[0].Value.gameObject.SetActive(false);

        if (rubbishList.Count > 1)
        {
            rubbishList.RemoveAt(0);
            rubbishList[0].Value.gameObject.SetActive(true);
        }
        else
        {

        }
    }

    public void CalculateEnvironmentPoints()
    {
        /*EnvironmentPoints = chosenTransport.PointsValue;
        resultText.text = "You selected " + chosenTransport.Name + ", Your score: " + EnvironmentPoints.ToString();*/
    }
}
