using System;
using System.Linq;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Netcode;
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

        [SerializeField] private PopUpInvitation _invitation;
        [SerializeField] private PopUpHelpRequest _helpRequest;
        
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            _invitation ??= GetComponent<PopUpInvitation>();
            _helpRequest ??= GetComponent<PopUpHelpRequest>();
        }

        public override void OnNetworkSpawn()
        {
            if(!IsOwner) return;

            Username.Value = GameManager.Instance.GetCurrentPlayerName();
            PlayerId.Value = GameManager.Instance.CurrentPlayerId;
            ClientId.Value = NetworkManager.Singleton.LocalClientId;
        }

        [ContextMenu("Send friend request to user named 'a'")]
        private void SendFriendRequestToA()
        {
            SendFriendRequestToPlayerServerRPC(97);
        }
        
        [ContextMenu("Send help request to user named 'a'")]
        private void SendHelpRequestToA()
        {
            SendHelpRequestToPlayerServerRPC(97);
        }
    
        /// <summary>
        /// Send a friend request to a players PlayerCommunicator that is running only on their machine.
        /// </summary>
        /// <param name="playerId">The id of the user that should receive the help request</param>
        [ServerRpc(RequireOwnership = false)]
        public void SendFriendRequestToPlayerServerRPC(ulong playerId)
        {
            Debug.Log("Player: " + Username.Value + " sent an invitation to player with id: " + playerId);
            NetworkClient networkClient = NetworkManager.Singleton.ConnectedClientsList.First(client => client.PlayerObject.gameObject.GetComponent<PlayerCommunicator>().PlayerId.Value == playerId);
            PlayerCommunicator playerCommunicator = networkClient.PlayerObject.GetComponent<PlayerCommunicator>();

            var clientRpcParams = new ClientRpcParams()
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new []{ playerCommunicator.ClientId.Value }
                }
            };

            playerCommunicator.SendFriendRequestClientRPC(Username.Value, PlayerId.Value, playerCommunicator.Username.Value, clientRpcParams);
        }
        
        /// <summary>
        /// Sends a help request to players PlayerCommunicator running on their machine.
        /// </summary>
        /// <param name="playerId">The id of the user that should receive the help request</param>
        [ServerRpc(RequireOwnership = false)]
        public void SendHelpRequestToPlayerServerRPC(ulong playerId)
        {
            Debug.Log("Player: " + Username.Value + " sent an invitation to player with id: " + playerId);
            NetworkClient networkClient = NetworkManager.Singleton.ConnectedClientsList.First(client => client.PlayerObject.gameObject.GetComponent<PlayerCommunicator>().PlayerId.Value == playerId);
            PlayerCommunicator playerCommunicator = networkClient.PlayerObject.GetComponent<PlayerCommunicator>();

            var clientRpcParams = new ClientRpcParams()
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new []{ playerCommunicator.ClientId.Value }
                }
            };

            playerCommunicator.SendHelpRequestClientRPC(Username.Value, PlayerId.Value, playerCommunicator.Username.Value, clientRpcParams);
        }

        /// <summary>
        /// Add points to the player that is the owner of the Player Communicator.
        /// </summary>
        /// <param name="type">The type of points that the player will be given.</param>
        /// <param name="numberOfPoints">Number of points added.</param>
        [ServerRpc(RequireOwnership = false)]
        public void AddPointsToPlayerServerRPC(PointsType type, int numberOfPoints)
        {
            var clientRpcParams = new ClientRpcParams()
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new []{ PlayerId.Value }
                }
            };

            AddPointsToPlayerClientRPC(type, numberOfPoints, clientRpcParams);
        }

        private async void WaitForUserFriendRequestResponse(string username, ulong playerId)
        {
            Task<bool> task = _invitation.ShowInvitation(username);
            await task;
            
            if (!task.Result) return;
            
            GameManager.Instance.AddFriendToCurrentPlayer(playerId);
            Debug.Log("Friend request accepted from user = " + username);
        }
        
        private async void WaitForHelpRequestResponse(string username, ulong playerId)
        {
            Task<bool> task = _helpRequest.ShowHelpRequest(username);
            await task;
            
            if (!task.Result) return;
            
            GameManager.Instance.AddFriendToCurrentPlayer(playerId);
            Debug.Log("Help request accepted from user = " + username);
        }

        [ClientRpc]
        private void SendFriendRequestClientRPC(FixedString32Bytes senderUsername, ulong playerId, FixedString32Bytes receiverUsername, ClientRpcParams clientRpcParams = default)
        {
            Debug.Log("Current player received an invitation from player: " + senderUsername.Value);
            WaitForUserFriendRequestResponse(senderUsername.Value, playerId);
        }
        
        [ClientRpc]
        private void SendHelpRequestClientRPC(FixedString32Bytes senderUsername, ulong playerId, FixedString32Bytes receiverUsername, ClientRpcParams clientRpcParams = default)
        {
            Debug.Log("Current player received a help request from player: " + senderUsername.Value);
            WaitForHelpRequestResponse(senderUsername.Value, playerId);
        }
        
        [ClientRpc]
        private void AddPointsToPlayerClientRPC(PointsType type, int numberOfPoints, ClientRpcParams clientRpcParams = default)
        {
            Debug.Log("Added points to player = " + Username.Value + " points = " + numberOfPoints + " of type " + type);
            GameManager.Instance.AddPointsToCurrentPlayer(type, numberOfPoints);
            //TODO: Display popup.
            //TODO: Await popup return value.
            //TODO: Synchronize with database.
        }
    }
}
