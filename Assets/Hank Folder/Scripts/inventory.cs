using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public int fuelCarried;


    void Start()
    {
        fuelCarried = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //pick up fuel
        {
            fuelCarried++;
            
        }
    }
}
