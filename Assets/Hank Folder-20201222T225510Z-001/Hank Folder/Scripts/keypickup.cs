using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypickup : MonoBehaviour
{
    public bool pickedUp;
    

    public bool key1;
    public bool key2;

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
        if (key1 == true)
        {
            
            inventory.Instance.key1Carried = true;
        }
        else if(key2 == true)
        {
           
            inventory.Instance.key2Carried = true;
        }
        
        Destroy(gameObject);
    }
}
