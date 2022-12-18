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
        if (litter == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_good_sprite;
        }
        else if (litter == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_medium_sprite;
        }
        else if (litter == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = litter_bad_sprite;
        }
    }
}
