using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject m_World;
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
        set_Water_condition(0);
        set_Litter_condition(0);
        set_Air_condition(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (water==0)
        {

        }else if (water==1)
        {

        }
        else if(water == 2)
        {

        }

        if (litter == 0)
        {

        }
        else if (litter == 1)
        {

        }
        else if (litter == 2)
        {

        }

        if (air == 0)
        {

        }
        else if (air == 1)
        {

        }
        else if (air == 2)
        {

        }
    }
}
