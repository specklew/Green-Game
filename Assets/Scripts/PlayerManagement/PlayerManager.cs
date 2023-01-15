using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject progressPopupGameObject;

    private ArrayList tasks = new ArrayList();
    private ProgressPopUp progressPopup;

    [SerializeField]
    private int previousDay;

    private void Awake()
    {
        progressPopup = progressPopupGameObject.GetComponent<ProgressPopUp>();
    }
    private void Start()
    {
        int lastLoginDay = System.DateTime.Today.Day;

        FetchTask();

        if (PlayerPrefs.HasKey("lastLoginDay"))
        {
            int savedlastLoginDay = PlayerPrefs.GetInt("lastLoginDay");
            if (lastLoginDay != savedlastLoginDay)
            {
                CleanTaskEachDay();
            }
        }

        PlayerPrefs.SetInt("lastLoginDay", lastLoginDay);
    }
    private void Update()
    {
        progressPopup.setTextScore(GameManager.Instance.GetCurrentPlayerGlobalScore());
        progressPopup.setTextName(GameManager.Instance.GetCurrentPlayerName());
    }

    #region Private Methods
    
    private void FetchTask()
    {
        int NUMBER_OF_TASK = 5;
        string[] availableTask = new string[] { "RubbishMinigame", "BrushingTeethMinigame", "SwitchLightsMinigame", "ShoppingMinigame", "TransportMinigame" };
        PointsType[] pointsType = new PointsType[] { PointsType.LITTER, PointsType.WATER, PointsType.AIR, PointsType.LITTER, PointsType.AIR };

        for (int i = 0; i < NUMBER_OF_TASK; i++)
        {
            string currentStatus = GameManager.Instance.GetTaskStatus(availableTask[i]);
            Task currentTask = Task.CreateInstance(GameManager.Instance.CurrentPlayerId, Random.Range(0, 1000), availableTask[i], pointsType[i], currentStatus);
            tasks.Add(currentTask);
            progressPopup.setTask(i, currentTask);
        }
    }

    private void CleanTaskEachDay()
    {
        foreach (Task task in tasks)
        {
            //The player loses points if the deadline is not respected
            if (GameManager.Instance.GetTaskStatus(task.name) == "not done" || GameManager.Instance.GetTaskStatus(task.name) == "failed")
            {
                GameManager.Instance.AddCurrentPlayerGlobalScore(-10);
            }
            //Reset all task status
            GameManager.Instance.SetCurrentPlayerTaskStatus(task.name, "not done");
        }
    }
    #endregion

}
