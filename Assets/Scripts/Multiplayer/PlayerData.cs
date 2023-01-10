using System.Collections.Generic;

namespace Multiplayer
{
    public struct PlayerData
    {
        public string username;
        public string password;

        public Dictionary<PointsType, int> playerPoints;
        public Dictionary<string, string> tasksStatus;
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

            tasksStatus = new Dictionary<string, string>
            {
                {"RubbishMinigame", "not done"},
                {"BrushingTeethMinigame", "not done"},
                {"SwitchLightsMinigame", "not done"},
                {"ShoppingMinigame", "not done"},
                {"TransportMinigame", "not done"}
            };

            FriendIds = new List<ulong>();
        }
    }
}