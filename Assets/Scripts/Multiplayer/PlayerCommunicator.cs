using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;

namespace Multiplayer
{
    [RequireComponent(typeof(NetworkObject))]
    public class PlayerCommunicator : NetworkBehaviour
    {
        [NonSerialized] public NetworkVariable<ulong> PlayerId = new NetworkVariable<ulong>(
            writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);
        [NonSerialized] public NetworkVariable<ulong> ClientId = new NetworkVariable<ulong>(
            writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public override void OnNetworkSpawn()
        {
            PlayerId.Value = GameManager.Instance.CurrentPlayerId;
            ClientId.Value = NetworkManager.Singleton.LocalClientId;
        }

        [ContextMenu("Send message to user")]
        private void SendMessage()
        {
            SendFriendRequestToUser(NetworkManager.ConnectedClients.Keys.Last());
        }
    
        public void SendFriendRequestToUser(ulong playerId)
        {
            IEnumerable<NetworkClient> networkClients = NetworkManager.Singleton.ConnectedClientsList.Where(client => client.PlayerObject.gameObject.GetComponent<PlayerCommunicator>().PlayerId.Value == playerId);
            IReadOnlyList<ulong> targetIds = (IReadOnlyList<ulong>) networkClients.Select(client => client.ClientId);

            var clientRpcParams = new ClientRpcParams()
            {
                Send = new ClientRpcSendParams()
                {
                    TargetClientIds = targetIds
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
}
