using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generator : MonoBehaviour
{
    public int fuelAmt;
    public int fuelCap;

    public int invFuel;

    

    public Text genFuel;

    void Start()
    {
        fuelCap = 5;
        inventory.Instance.generatorCanWork = false;
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

        fuelAmt += invFuel;
        inventory.Instance.fuelCarried = 0;
    }
}
