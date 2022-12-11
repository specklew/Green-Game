using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinigame
{
    public bool IsCompleted { get; set; }
    public int EnvironmentPoints { get; set; }

    public void StartMinigame();
    public void CalculateEnvironmentPoints(MeanOfTransport chosenTransport);
}
