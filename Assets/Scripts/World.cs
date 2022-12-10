using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject m_World;
    public SpriteRenderer spriteR;
    private int water;
    private int litter;
    private int air;
    public Sprite water_good_sprite;
    public Sprite water_medium_sprite;
    public Sprite water_bad_sprite;
    public Sprite litter_good_sprite;
    public Sprite litter_medium_sprite;
    public Sprite litter_bad_sprite;
    public Sprite air_good_sprite;
    public Sprite air_medium_sprite;
    public Sprite air_bad_sprite;


    public void set_Water_condition(int water)
    {
        this.water = water;
    }
    public void set_Litter_condition(int litter)
    {
        this.litter= litter;
    }
    public void set_Air_condition(int air)
    {
        this.air = air;
    }
    public int get_Water_condition()
    {
        return water;
    }
    public int get_Litter_condition()
    {
        return litter;
    }
    public int set_Air_condition()
    {
        return air;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        set_Water_condition(0);
        set_Litter_condition(0);
        set_Air_condition(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (water==0)
        {
            spriteR.sprite = water_good_sprite;
        }
        else if (water==1)
        {
            spriteR.sprite = water_medium_sprite;
        }
        else if(water == 2)
        {
            spriteR.sprite = water_bad_sprite;
        }

        if (litter == 0)
        {
            spriteR.sprite = litter_good_sprite;
        }
        else if (litter == 1)
        {
            spriteR.sprite = litter_medium_sprite;
        }
        else if (litter == 2)
        {
            spriteR.sprite = litter_bad_sprite;
        }

        if (air == 0)
        {
            spriteR.sprite = air_good_sprite;
        }
        else if (air == 1)
        {
            spriteR.sprite = air_medium_sprite;
        }
        else if (air == 2)
        {
            spriteR.sprite = air_bad_sprite;
        }
    }
}
