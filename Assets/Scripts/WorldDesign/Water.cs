using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private int water;
    public Sprite water_good_sprite;
    public Sprite water_medium_sprite;
    public Sprite water_bad_sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.WATER) >= 9)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = water_good_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.WATER) > 0 && GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.WATER) <= 8)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = water_medium_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.WATER) <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = water_bad_sprite;
        }
    }
}
