using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public GameObject m_World;
    public SpriteRenderer spriteR;
    public static int water;
    public static int litter;
    public static int air;
    /*
    [SerializeField] private Sprite water_good_sprite = Resources.Load<Sprite>("Sprites/water_good");
    [SerializeField] private Sprite water_medium_sprite = Resources.Load<Sprite>("Sprites/water_medium");
    [SerializeField] private Sprite water_bad_sprite = Resources.Load<Sprite>("Sprites/water_bad");
    [SerializeField] private Sprite litter_good_sprite = Resources.Load<Sprite>("Sprites/litter_good");
    [SerializeField] private Sprite litter_medium_sprite = Resources.Load<Sprite>("Sprites/litter_medium");
    [SerializeField] private Sprite litter_bad_sprite = Resources.Load<Sprite>("Sprites/litter_bad");
    [SerializeField] private Sprite air_good_sprite = Resources.Load<Sprite>("Sprites/air_good");
    [SerializeField] private Sprite air_medium_sprite = Resources.Load<Sprite>("Sprites/air_medium");
    [SerializeField] private Sprite air_bad_sprite = Resources.Load<Sprite>("Sprites/air_bad");
    */

    void Awake()
    {
        DontDestroyOnLoad(this);
    }



    public void set_Water_condition(int water)
    {
        //this.water = water;
        World.water = water;
    }
    public void set_Litter_condition(int litter)
    {
        //this.litter= litter;
        World.litter = litter;
    }
    public void set_Air_condition(int air)
    {
        //this.air = air;
        World.air = air;
    }
    public int get_Water_condition()
    {
        return water;
    }
    public int get_Litter_condition()
    {
        return litter;
    }
    public int get_Air_condition()
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
        /*
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
        }*/
    }
}
