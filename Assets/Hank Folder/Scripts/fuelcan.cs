﻿using System.Collections;
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
            Destroy(gameObject);
        }
    }
}
