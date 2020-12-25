using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prompts : MonoBehaviour
{
    public bool notEnoughFuel;
    public bool noFuel;
    public bool noPower;
    public bool noKey;
    public bool haveAKey;
    public bool haveBkey;

    public Text noFuels;
    public Text notEnoughFuels;
    public Text noPowers;
    public Text noKeys;
    public Text wrongKey;
    void Start()
    {
        notEnoughFuel = true;
        noFuel = true;
        noPower = true;
        noKey = true;
        haveAKey = false;
        haveBkey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.Instance.fuelCarried == 0)
        {
            noFuel = true;
        }
        else if(inventory.Instance.fuelCarried > 0)
        {
            noFuel = false;
        }

        if(inventory.Instance.generatorCanWork == false)
        {
            notEnoughFuel = true;
        }
        else if (inventory.Instance.generatorCanWork == true)
        {
            notEnoughFuel = false;
        }

        //interact with generator
        if (noFuel) 
        {
            noFuels.enabled = true;
        }
       
        if (notEnoughFuel == true)
        {
            notEnoughFuels.enabled = true;
        }
       

        
        if (inventory.Instance.key1Carried == false && inventory.Instance.key2Carried == false)
        {
            noKey = true;
            haveAKey = false;
            haveBkey = false;
        }
        if (inventory.Instance.key1Carried == true )
        {
            noKey = false;
            haveAKey = true;
            haveBkey = false;
        }
        if (inventory.Instance.key2Carried == true)
        {
            noKey = false;
            haveAKey = false;
            haveBkey = true;
        }

        //interact with door
        if (noKey)
        {
            noKeys.enabled = true;
        }

        //interact with elevator door
        if (noPower)
        {
            noPowers.enabled = true; ;
        }
        
    }
}
