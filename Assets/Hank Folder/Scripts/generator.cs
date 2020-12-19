using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator : MonoBehaviour
{
    public int fuelAmt;
    public int fuelCap;

    public GameObject player;
    public int invFuel;

    public bool canWork;
    void Start()
    {
        fuelCap = 5;
        canWork = false;
    }

    // Update is called once per frame
    void Update()
    {
        invFuel = player.GetComponent<inventory>().fuelCarried;

        if (Input.GetKeyDown(KeyCode.F))//pur fuel into generator
        {
            fuelAmt += invFuel;
            player.GetComponent<inventory>().fuelCarried=0;
            
        }

        if (fuelAmt == fuelCap)//gas is full
        {
            canWork = true;
        }
    }
}
