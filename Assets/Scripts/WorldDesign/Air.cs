using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    private int air;
    public Sprite air_good_sprite;
    public Sprite air_medium_sprite;
    public Sprite air_bad_sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.AIR) == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = air_good_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.AIR) == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = air_medium_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.AIR) == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = air_bad_sprite;
        }
    }
}
