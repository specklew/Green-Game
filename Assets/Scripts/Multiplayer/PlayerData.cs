using System.Collections.Generic;

namespace Multiplayer
{
    public struct PlayerData
    {
        public string username;
        public string password;

        public Dictionary<PointsType, int> playerPoints;
        public List<ulong> FriendIds;

        public PlayerData(string name, string pass)
        {
            username = name;
            password = pass;
        
            playerPoints = new Dictionary<PointsType, int>
            {
                {PointsType.AIR, 0},
                {PointsType.WATER, 0},
                {PointsType.LITTER, 0}
            };
        
            FriendIds = new List<ulong>();
        }
    }
}