using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public bool on;
    public Light torch;
    
    void Start()
    {
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (on == true)
            {
                torch.enabled = false;
                on = false;
            }
            else if (on == false)
            {
                torch.enabled = true;
                on = true;
            }
        }
        
    }
}
