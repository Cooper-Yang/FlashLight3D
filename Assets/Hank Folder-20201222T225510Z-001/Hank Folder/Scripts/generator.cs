using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generator : MonoBehaviour
{
    public int fuelAmt;
    public int fuelCap;

    public int invFuel;

    bool canStart;

    public Text genFuel;



    void Start()
    {
        fuelCap = 5;
        inventory.Instance.generatorCanWork = false;
        canStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        invFuel = inventory.Instance.fuelCarried;

        genFuel.text = fuelAmt + " / 5";

        if (fuelAmt == fuelCap)//gas is full
        {
            inventory.Instance.generatorCanWork = true;
        }

        if(inventory.Instance.generatorCanWork && canStart)
        {
            GetComponent<AudioSource>().Play();
            canStart = false;
        }

    }

    public void AddFuel()
    {
        if (inventory.Instance.firstGen == false)
        {
            inventory.Instance.firstGen = true;
        }

        if (invFuel > 0)
        {
            AudioManager.Instance.OilPour();
            
        }
       
            else if (!canStart)
            {
                StartCoroutine(prompts.Instance.GenOn());
            }
            else
            {
                StartCoroutine(prompts.Instance.NoFuel());
            }
               
      

        fuelAmt += invFuel;
        inventory.Instance.fuelCarried = 0;
    }
}
