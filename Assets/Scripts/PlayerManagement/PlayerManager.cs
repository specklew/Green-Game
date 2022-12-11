using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private int playerId;
    [SerializeField]
    private string playerName;
    [SerializeField]
    private int playerScore = 0;
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

        //Fetch Player ID From database
        FetchPlayerID();

        //Fetch Tasks of the player from database
        //...code...

        //Fetch World condition from World Design Component
        FetchWorldCondition();

        //Generate 5 daily tasks if it is a new day
        if (isNewConnection())
        {
            turnNotDoneTaskToFail();
            ComputeScore();
            scoreLastDay += playerScore;
            Generate5DailyTask();
        }
    }
    private void Update()
    {
        progressPopup.setTextScore(this.playerScore);
        progressPopup.setTextName(this.playerName);
    }


    #region IPlayerManager

    public PlayerManager(int playerId)
    {
        this.playerId = playerId;
    }

    //Call when a game finished
    public void UpdateTaskStatus(int taskId, string status)
    {
        foreach (Task task in this.tasks)
        {
            if (task.getId() == taskId)
            {
                task.setStatus(status);
            }
        }
        ComputeScore();
        playerScore = scoreLastDay + playerScore; 
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
        foreach (Task task in this.tasks)
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
        for (int i = 0; i < NUMBER_OF_TASK; i++)
        {
            float randomNumber = Random.Range(0, 4);
            Task currentTask = Task.CreateInstance(playerId, Random.Range(0, 1000), availableTask[(int)randomNumber], "daily", "not done");
            this.tasks.Add(currentTask);
            progressPopup.setTask(i, currentTask);
        }
        return this.tasks;
    }

    private int ComputeScore()
    {
        foreach (Task task in this.tasks)
        {
            if (task.getStatus() == "done")
            {
                this.playerScore += 20;
            } else if (task.getStatus() == "failed")
            {
                this.playerScore -= 10;
            }
        }
        return this.playerScore;
    }


    private ArrayList FetchTask()
    {
        //TODO Fetch tasks of the player from database
        //...code...
        return this.tasks;
    }

    private void FetchWorldCondition()
    {
        //TODO : Get world condition from WorldDesign
        //...code...
        progressPopup.setWaterCondition("GOOD");
        progressPopup.setLitterCondition("GOOD");
        progressPopup.setAirCondition("GOOD");
    }


    private void FetchPlayerID()
    {
        //TODO : Fetch Player ID From Database after the registration of the player
        //...code...
        this.playerId = 23;
    }

    #endregion

}
