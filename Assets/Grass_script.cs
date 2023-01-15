using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass_script : MonoBehaviour
{
    private int grass;
    public Sprite grass_good_sprite;
    public Sprite grass_medium_sprite;
    public Sprite grass_bad_sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (grass == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = grass_good_sprite;
        }
        else if (grass == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = grass_medium_sprite;
        }
        else if (grass == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = grass_bad_sprite;
        }
    }
}
