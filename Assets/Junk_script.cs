using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk_script : MonoBehaviour
{
    private int junk;
    public Sprite junk_good_sprite;
    public Sprite junk_medium_sprite;
    public Sprite junk_bad_sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (junk == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = junk_good_sprite;
        }
        else if (junk == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = junk_medium_sprite;
        }
        else if (junk == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = junk_bad_sprite;
        }
    }
}
