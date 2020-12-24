using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelcan : MonoBehaviour
{
    public bool pickedUp;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            PickedUp();
        }
    }

    public void PickedUp()
    {
        if (inventory.Instance.firstPickFuel == false)
        {
            inventory.Instance.firstPickFuel = true;
        }

        inventory.Instance.fuelCarried++;
        Destroy(gameObject);
    }
}
