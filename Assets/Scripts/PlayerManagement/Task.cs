using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : ScriptableObject
{
    private ulong playerId;
    private int id;
    private string name;
    private PointsType type;
    private string status;

    public void Init(ulong playerId, int id, string name, PointsType type, string status)
    {
        this.playerId = playerId;
        this.id = id;
        this.name = name;
        this.type = type;
        this.status = status;
    }
    public static Task CreateInstance(ulong playerId, int id, string name, PointsType type, string status)
    {
        var data = ScriptableObject.CreateInstance<Task>();
        data.Init(playerId, id, name, type, status);
        return data;
    }

    public void setStatus(string status)
    {
        if (status != "done" || status != "not done" || status != "failed")
        {
            Debug.Log("Error Invalid status");
        } else
        {
            this.status = status;
        }
    }

    public string getStatus()
    {
        return this.status;
    }

    public int getId()
    {
        return this.id;
    }

    public string getName()
    {
        return this.name;
    }

    public PointsType getType()
    {
        return this.type;
    }

}
