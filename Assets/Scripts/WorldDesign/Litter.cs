using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Litter : MonoBehaviour
{
    private int litter;
    public Sprite litter_good_sprite;
    public Sprite litter_medium_sprite;
    public Sprite litter_bad_sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.LITTER) >= 9)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_good_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.LITTER) > 0 && GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.LITTER) <= 8)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_medium_sprite;
        }
        else if (GameManager.Instance.GetCurrentPlayerPointsOfType(PointsType.LITTER) <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_bad_sprite;
        }
    }
}
