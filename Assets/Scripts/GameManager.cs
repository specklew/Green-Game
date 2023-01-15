using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Multiplayer;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DeveloperMenu))]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public ulong CurrentPlayerId { get; private set; }
    public Dictionary<ulong, PlayerData> players;

    public DeveloperMenu DeveloperConsole;
    public MultiplayerManager Multiplayer;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this;
            DeveloperConsole = TryGetComponent(out DeveloperMenu console) ? console : gameObject.AddComponent<DeveloperMenu>();
            Multiplayer = new MultiplayerManager(this);
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            DeveloperConsole.ToggleConsole();
        }
    }

    private GameManager()
    {
        players = new Dictionary<ulong, PlayerData>();
        //TODO: get data from mockup file
    }

    public void ToggleServer()
    {
        if (Multiplayer.IsServer)
        {
            Multiplayer.StopServer();
            SceneManager.LoadScene("MainMenuScene");
            return;
        }
        
        if(!players.ContainsKey(0)) players.Add(0, new PlayerData("server", "password"));
        CurrentPlayerId = 0;
        
        Multiplayer.SetupServer();
        SceneManager.LoadScene("WorldDesign");
    }

    public void AddPointsToCurrentPlayer(PointsType type, int numberOfPoints)
    {
        players[CurrentPlayerId].playerPoints[type] += numberOfPoints;
    }

    public void AddPointsToPlayer(ulong playerId, PointsType type, int numberOfPoints)
    {
        GetPlayerNetworkCommunicator(playerId).AddPointsToPlayerServerRPC(type, numberOfPoints, playerId);
    }

    public PlayerCommunicator GetPlayerNetworkCommunicator(ulong playerId)
    {
        return FindObjectsOfType<PlayerCommunicator>().First(communicator => communicator.PlayerId.Value == playerId);
    }

    public int GetCurrentPlayerPointsOfType(PointsType type)
    {
        return players[CurrentPlayerId].playerPoints[type];
    }

    public int GetCurrentPlayerPoints()
    {
        return players[CurrentPlayerId].playerPoints.Sum(valuePair => valuePair.Value);
    }

    public int AddCurrentPlayerGlobalScore(int numberOfPoints)
    {
        return players[CurrentPlayerId].globalScore["value"] += numberOfPoints;
    }

    public int GetCurrentPlayerGlobalScore()
    {
        return players[CurrentPlayerId].globalScore["value"];
    }

    public string GetCurrentPlayerName()
    {
        return players[CurrentPlayerId].username;
    }

    public void AddFriendToCurrentPlayer(ulong friendId)
    {
        players[CurrentPlayerId].FriendIds.Add(friendId);
    }
    
    /// <summary>
    /// Loads additively the specified minigame scene into the current player view.
    /// </summary>
    /// <param name="minigameName">The name of the minigame scene that should be loaded.</param>
    /// <param name="playerId">Id of the player that should receive points for the completion of the minigame.</param>
    public void LoadMinigame(string minigameName, ulong playerId = default)
    {
        if (playerId == default) playerId = CurrentPlayerId;
        StartCoroutine(LoadMinigameCoroutine(minigameName, playerId));
    }
    
    private IEnumerator LoadMinigameCoroutine(string minigameName, ulong playerId)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(minigameName, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return new WaitForNextFrameUnit();
        }
        
        IEnumerable<IMinigame> minigames = FindObjectsOfType<MonoBehaviour>().OfType<IMinigame>();
        minigames.First().PlayerId = playerId;
    }

    public void RegisterPlayer(string username, string password)
    {
        ulong id = HashFunction(username);
        players.Add(id, new PlayerData(username, password));
        Debug.Log("Registered player with login = " + username + " and password = " + password);
    }

    public bool LogPlayer(string username, string password)
    {
        ulong id = HashFunction(username);

        if (players[id].password == password)
        {
            CurrentPlayerId = id;
            Multiplayer.StartClient();

            return true;
        }

        return false;
    }

    private static ulong HashFunction(string s)
    {
        int total = 0;
        char[] c = s.ToCharArray();

        for (int k = 0; k <= c.GetUpperBound(0); k++)
            total += c[k];
        
        return (ulong)total;
    }

    #region functions related to task

    public void SetTaskStatus(string taskName, string status, ulong playerId)
    {
        GetPlayerNetworkCommunicator(playerId).SetPlayerTaskStatusServerRPC(taskName, status, playerId);
    }
    
    public void SetCurrentPlayerTaskStatus(string taskName, string status)
    {
        players[CurrentPlayerId].tasksStatus[taskName] = status;
        
        if (status == "done")
        {
            players[CurrentPlayerId].globalScore["value"] += 20;
        }
        if (status == "failed")
        {
            players[CurrentPlayerId].globalScore["value"] -= 10;
        }
    }

    public string GetTaskStatus(string taskName)
    {
        return players[CurrentPlayerId].tasksStatus[taskName];
    }

    #endregion
}