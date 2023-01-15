using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinigame
{
    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }
    public PlayerManager? IPlayer { get; set; }
    public ulong PlayerId { get; set;}

    public void StartMinigame();

    public static IMinigame GetTransportMinigame(PlayerManager IPlayer)
    {
        return new TransportMinigame(IPlayer);
    }

    public static IMinigame GetBrushingTeethMinigame(PlayerManager IPlayer)
    {
        throw new System.NotImplementedException();
    }

    public static IMinigame GetSwitchLightsMinigame(PlayerManager IPlayer)
    {
        throw new System.NotImplementedException();
    }

    public static IMinigame GetRubbishMinigame(PlayerManager IPlayer)
    {
        throw new System.NotImplementedException();
    }

    public static IMinigame GetShoppingMinigame(PlayerManager IPlayer)
    {
        throw new System.NotImplementedException();
    }
}
