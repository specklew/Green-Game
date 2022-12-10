using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class MeanOfTransport
{
    public string Name { get; set; }
    public int PointsValue { get; set; }

    public MeanOfTransport(string name, int points)
    {
        Name = name;
        PointsValue = points;
    }
    private static System.Random rng = new System.Random();
    private static List<MeanOfTransport> meansOfTransport = new List<MeanOfTransport>()
    {
        new MeanOfTransport("Bus", 1),
        new MeanOfTransport("Bicycle", 3),
        new MeanOfTransport("Car", 0),
        new MeanOfTransport("Motorbike", 0),
        new MeanOfTransport("Scooter", 0),
        new MeanOfTransport("Tram", 2),
        new MeanOfTransport("Train", 1),
    };

    public static List<MeanOfTransport> GenerateRandomMeansOfTransport()
    {
        var means = meansOfTransport.OrderBy(m => rng.Next()).ToList();
        return means.GetRange(0,4);
    }
}
