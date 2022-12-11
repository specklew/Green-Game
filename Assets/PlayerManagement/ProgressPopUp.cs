using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressPopUp : MonoBehaviour
{
    //Object Player
    [Header("Player in the world")]
    public GameObject playerGameObject;

    //UI Object
    [Header("Player Info UI")]
    public GameObject playerScoreGameObject;
    public GameObject playerNameGameObject;

    [Header("World Condition UI")]
    public GameObject waterConditionGameObject;
    public GameObject litterConditionGameObject;
    public GameObject airConditionGameObject;

    [Header("Task List UI")]
    public GameObject Task1;
    public GameObject Task2;
    public GameObject Task3;
    public GameObject Task4;
    public GameObject Task5;


    private GameObject[] gameObjectTaskList;

   

    private Text playerScore;
    private Text playerName;

    private Text waterCondition;
    private Text litterCondition;
    private Text airCondition;

    private Text currentTaskType;
    private Text currentTaskName;
    private Text currentTaskStatus;



    void Awake()
    {
       // world = GameObject.Find("Main").GetComponent<WorldDesign>();

        gameObjectTaskList = new GameObject[] { Task1, Task2, Task3, Task4, Task5};

        playerScore = playerScoreGameObject.GetComponent<Text>();
        playerName = playerNameGameObject.GetComponent<Text>();

        waterCondition = waterConditionGameObject.GetComponent<Text>();
        litterCondition = litterConditionGameObject.GetComponent<Text>();
        airCondition = airConditionGameObject.GetComponent<Text>();
        
    }


    public void setTextScore(int score)
    {
        this.playerScore.text = score.ToString();
    }

    public void setTextName(string name)
    {
        this.playerName.text = name;
    }

    public void setWaterCondition(string condition)

    {
        this.waterCondition.text = condition;
    }

    public void setLitterCondition(string condition)
    {
        this.litterCondition.text = condition;
    }

    public void setAirCondition(string condition)
    {
        this.airCondition.text = condition;
    }
    //
    /*
    public void setWaterCondition()

    {
        this.waterCondition.text = world.get_Water_condition.text;
    }

    public void setLitterCondition()
    {
        this.litterCondition.text = world.get_Litter_condition.text;
    }

    public void setAirCondition()
    {
        this.airCondition.text = world.get_Air_condition.text;
    }
    */
    //

    public void setTask(int taskPosition, Task task)
    {
        GameObject currentTask = this.gameObjectTaskList[taskPosition];

        currentTaskType = GetChildWithName(currentTask, "TextTaskType").GetComponent<Text>();
        currentTaskName = GetChildWithName(currentTask, "TextTaskName").GetComponent<Text>();
        currentTaskStatus = GetChildWithName(currentTask, "TextTaskStatus").GetComponent<Text>();

        currentTaskType.text = task.getType();
        currentTaskName.text = task.getName();
        currentTaskStatus.text = task.getStatus();


    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }


}
