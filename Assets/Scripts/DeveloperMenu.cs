using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class DeveloperMenu : MonoBehaviour
{
    private bool IsActive { get; set; }

    private GameManager _gameManager;

    private string _lastMessage;
    
    private string _serverButtonText = ServerStartButtonText;
    private const string ServerStartButtonText = "Start Server";
    private const string ServerStopButtonText = "Stop Server";

    private Rect _windowRect = new(20, 20, 200, 200);

    private void Awake()
    {
        _gameManager = GetComponent<GameManager>();
    }

    private void OnGUI()
    {
        if (!IsActive) return;

        GUI.Window(0, _windowRect, DoWindow, "Developer Console");
    }

    private void DoWindow(int id)
    {
        if (GUILayout.Button(_serverButtonText))
        {
            _serverButtonText = _gameManager.Multiplayer.IsServer ? ServerStartButtonText : ServerStopButtonText;
            _gameManager.ToggleServer();
        }
            
        GUILayout.Label(_lastMessage);
        
        //TODO: Fix drag window.
        GUI.DragWindow();
    }

    public void ToggleConsole()
    {
        IsActive = !IsActive;
    }
    
    public void SetDebugMessage(string message)
    {
        _lastMessage = message;
    }
}
