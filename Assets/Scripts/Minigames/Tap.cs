using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Tap
{
    public bool IsOn { get; set; }
    public double WaterUsedPerSecondInLiters { get; set; }

    public Tap(double usage)
    {
        WaterUsedPerSecondInLiters = usage;
    }
}
