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
    private int today;
    private int scoreLastDay;


    private void Start()
    {
        progressPopup = progressPopupGameObject.GetComponent<ProgressPopUp>();

        //Get the day of today
        today = (int)System.DateTime.Now.Day;

        //Initialize the array of tasks
        tasks = new ArrayList(5);

        //Fetch Tasks of the player from database
        //...code...

        //Fetch World condition from World Design Component
        FetchWorldCondition();

        //Generate 5 daily tasks if it is a new day
        if (isNewConnection())
        {
            turnNotDoneTaskToFail();
            UpdateScoreInDatabase();
            scoreLastDay += GameManager.Instance.GetCurrentPlayerPoints();
            Generate5DailyTask();
        }
    }
    private void Update()
    {
        progressPopup.setTextScore(GameManager.Instance.GetCurrentPlayerPoints());
        progressPopup.setTextName(GameManager.Instance.GetCurrentPlayerName());
    }


    #region IPlayerManager

    //Call when a game finished
    public void UpdateTaskStatus(int taskId, string status)
    {
        foreach (Task task in tasks)
        {
            if (task.getId() == taskId)
            {
                task.setStatus(status);
            }
        }
        UpdateScoreInDatabase();
        //playerScore = scoreLastDay + playerScore; 
    }

    public void DisplayPopUp(Task[] dailyTasks)
    {
        //TODO Call popup function and display the tasks of dailyTasks
        //...code...
    }
    #endregion

    #region Private Methods
    //compare the day number of today with the day number of the last connection stored in the database
    private bool isNewConnection()
    {
        //TODO
        //...code...
        return true;
    }

    private void turnNotDoneTaskToFail()
    {
        foreach (Task task in tasks)
        {
            if (task.getStatus() == "not done")
            {
                task.setStatus("failed");
            }
        }
    }

    private ArrayList Generate5DailyTask()
    {
        string[] availableTask = new string[] { "RubbishMinigame", "BrushingTeethMinigame", "SwitchLightsMinigame", "ShoppingMinigame", "TransportMinigame" };
        int NUMBER_OF_TASK = 5;
        int j = 0;

        if (tasks.Count > 0)
        {
            foreach (Task task in tasks)
            {
                if (task.getStatus() == "failed")
                {
                    Task currentTask = Task.CreateInstance(GameManager.Instance.CurrentPlayerId, Random.Range(0, 1000), availableTask[j], (PointsType)Random.Range(0, 2), "not done");
                    tasks.Add(currentTask);
                    progressPopup.setTask(j, currentTask);
                }
                j += 1;
            }
        }
        else
        {
            for (int i = 0; i < NUMBER_OF_TASK; i++)
            {
                float randomNumber = Random.Range(0, 4);
                Task currentTask = Task.CreateInstance(GameManager.Instance.CurrentPlayerId, Random.Range(0, 1000), availableTask[i], (PointsType)Random.Range(0, 2), "not done");
                tasks.Add(currentTask);
                progressPopup.setTask(i, currentTask);
            }
        }

        return tasks;
    }

    private void UpdateScoreInDatabase()
    {
        foreach (Task task in tasks)
        {
            if (task.getStatus() == "done")
            {
                GameManager.Instance.AddPointsToCurrentPlayer(task.getType(), 20);
            } else if (task.getStatus() == "failed")
            {
                GameManager.Instance.AddPointsToCurrentPlayer(task.getType(), -10);
            }
        }
    }


    private ArrayList FetchTask()
    {
        //TODO Fetch tasks of the player from database
        //...code...
        return tasks;
    }

    private void FetchWorldCondition()
    {
        //TODO : Get world condition from WorldDesign
        //...code...
        progressPopup.setWaterCondition("GOOD");
        progressPopup.setLitterCondition("GOOD");
        progressPopup.setAirCondition("GOOD");
    }

    #endregion

}
