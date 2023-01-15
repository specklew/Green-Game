using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky_script : MonoBehaviour
{
    private int sky;
    public Sprite sky_good_sprite;
    public Sprite sky_medium_sprite;
    public Sprite sky_bad_sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sky == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sky_good_sprite;
        }
        else if (sky == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sky_medium_sprite;
        }
        else if (sky == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sky_bad_sprite;
        }
    }
}
