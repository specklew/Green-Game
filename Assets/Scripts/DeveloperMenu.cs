using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class DeveloperMenu : MonoBehaviour
{
    private bool IsActive { get; set; }

    private GameManager _gameManager;
    
    private string _serverButtonText = ServerStartButtonText;
    private const string ServerStartButtonText = "Start Server";
    private const string ServerStopButtonText = "Stop Server";
    
    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void OnGUI()
    {
        if (!IsActive) return;

        if (GUILayout.Button(_serverButtonText))
        {
            _gameManager.StartServer();
            _serverButtonText = ServerStopButtonText;
        }
    }

    public void ToggleConsole()
    {
        IsActive = !IsActive;
    }
}
