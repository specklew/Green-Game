using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


namespace Multiplayer
{
    public class MultiplayerManager
    {
        private GameManager _game;

        public bool IsServer => NetworkManager.Singleton.IsServer;
        public bool IsClient => NetworkManager.Singleton.IsClient;
        
        public MultiplayerManager(GameManager game)
        {
            _game = game;
        }

        public void SetupServer()
        {
            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartServer();
        }

        public void StopServer()
        {
            NetworkManager.Singleton.Shutdown();
        }

        public void StartClient()
        {
            //byte[] connectionData = null;
            
            //TODO: Send connection payload over the net if needed.
            //NetworkManager.Singleton.NetworkConfig.ConnectionData = connectionData;
            NetworkManager.Singleton.StartClient();
            
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
        }

        public void StopClient()
        {
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnectedCallback;
        }

        private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
        {
            ulong clientId = request.ClientNetworkId;
            byte[] connectionData = request.Payload;

            response.Approved = true;
            response.CreatePlayerObject = true;
            response.PlayerPrefabHash = null;
            response.Position = Vector3.zero;
            response.Rotation = Quaternion.identity;
            response.Pending = false;
            
            _game.DeveloperConsole.SetDebugMessage("Connected player with clientId = " + clientId);
        }
        
        private void OnClientConnectedCallback(ulong clientId)
        {
            _game.DeveloperConsole.SetDebugMessage("Client connected callback!");
        }
    }
}