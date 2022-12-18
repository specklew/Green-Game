using System;
using System.Linq;
using Unity.Collections;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

namespace Multiplayer
{
    [RequireComponent(typeof(NetworkObject))]
    public class PlayerCommunicator : NetworkBehaviour
    {
        [NonSerialized] public NetworkVariable<FixedString32Bytes> Username = new(
            writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);
        [NonSerialized] public NetworkVariable<ulong> PlayerId = new(
            writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);
        [NonSerialized] public NetworkVariable<ulong> ClientId = new(
            writePerm: NetworkVariableWritePermission.Owner, readPerm: NetworkVariableReadPermission.Everyone);

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public override void OnNetworkSpawn()
        {
            if(!IsOwner) return;

            Username.Value = GameManager.Instance.GetCurrentPlayerName();
            PlayerId.Value = GameManager.Instance.CurrentPlayerId;
            ClientId.Value = NetworkManager.Singleton.LocalClientId;
        }

        [ContextMenu("Send message to user")]
        private void SendMessage()
        {
            SendFriendRequestToUser(97);
        }
    
        /// <summary>
        /// Send a friend request to a players PlayerCommunicator that is running only on their machine.
        /// </summary>
        public void SendFriendRequestToUser(ulong playerId)
        {
            NetworkClient networkClient = NetworkManager.Singleton.ConnectedClientsList.First(client => client.PlayerObject.gameObject.GetComponent<PlayerCommunicator>().PlayerId.Value == playerId);
            PlayerCommunicator playerCommunicator = networkClient.PlayerObject.GetComponent<PlayerCommunicator>();

            var clientRpcParams = new ClientRpcParams()
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new []{ playerCommunicator.ClientId.Value }
                }
            };

            playerCommunicator.SendFriendRequestClientRPC(Username.Value, playerCommunicator.Username.Value, clientRpcParams);
        }

        [ClientRpc]
        private void SendFriendRequestClientRPC(FixedString32Bytes senderUsername, FixedString32Bytes recieverUsername, ClientRpcParams clientRpcParams = default)
        {
            Debug.Log("Friend request sent to user with name = " + recieverUsername + ", sender username = " + senderUsername);
            Debug.Log(ClientId.Value);

            
        }
    }
}
