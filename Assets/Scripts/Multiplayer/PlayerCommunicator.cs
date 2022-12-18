using System;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(NetworkObject))]
public class PlayerCommunicator : NetworkBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    [ContextMenu("Send message to user")]
    private void SendMessage()
    {
        SendFriendRequestToUser(NetworkManager.ConnectedClients.Keys.Last());
    }
    
    public void SendFriendRequestToUser(ulong playerId)
    {
        var clientRpcParams = new ClientRpcParams()
        {
            Send = new ClientRpcSendParams()
            {
                TargetClientIds = new ulong[] { playerId }
            }
        };
        
        SendFriendRequestClientRPC(clientRpcParams);
    }

    [ClientRpc]
    private void SendFriendRequestClientRPC(ClientRpcParams clientRpcParams = default)
    {
        Debug.Log("Friend request sent to user with id = " + NetworkManager.LocalClientId);
        //TODO: Connect with popups
    }
}
