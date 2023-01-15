using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratch : MonoBehaviour
{
    public GameObject mask;
    bool pressed;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        if(pressed)
        {
            GameObject ob = Instantiate(mask, pos, Quaternion.identity);
            ob.transform.parent = GameObject.Find("scratch").transform;
        }
        if(Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            pressed = false;
        }
    }
}
