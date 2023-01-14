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
    public GameObject container1;
    public GameObject container2;
    public GameObject container3;
    public GameObject container4;

    public Image rubbishImage1;
    public Image rubbishImage2;
    public Image rubbishImage3;
    public Image rubbishImage4;
    public Image rubbishContainerImage1;
    public Image rubbishContainerImage2;
    public Image rubbishContainerImage3;
    public Image rubbishContainerImage4;

    public TextMeshProUGUI resultText;

    #endregion

    Vector2 mousePosition;
    Collider2D draggedObject;

    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; } = null;

    public RecyclingMinigame(PlayerManager playerManager)
    {
        this.IPlayer = playerManager;
    }

    public void Start()
    {
        StartMinigame();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggedObject = Physics2D.OverlapPoint(mousePosition);
    }

    void Update()
    {

    }

    public void StartMinigame()
    {
        rubbishImage1 = rubbish1.GetComponent<Image>();
        rubbishImage2 = rubbish2.GetComponent<Image>();
        rubbishImage3 = rubbish3.GetComponent<Image>();
        rubbishImage4 = rubbish4.GetComponent<Image>();
        rubbishContainerImage1 = container1.GetComponent<Image>();
        rubbishContainerImage1 = container2.GetComponent<Image>();
        rubbishContainerImage1 = container3.GetComponent<Image>();
        rubbishContainerImage1 = container4.GetComponent<Image>();
    }

    public void CalculateEnvironmentPoints()
    {
        /*EnvironmentPoints = chosenTransport.PointsValue;
        resultText.text = "You selected " + chosenTransport.Name + ", Your score: " + EnvironmentPoints.ToString();*/
    }
}
