﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSwitch : MonoBehaviour
{
    public AudioSource t1;
    public AudioSource t2;
    public GameObject lights;
    public bool once;
   

    public void Start()
    {
      
        once = true;
    }
    public void SwitchToTheEnd()
    {
        if (inventory.Instance.generatorCanWork&&once)
        {
            AudioManager.Instance.GeneratorSwitch();
            t1.PlayDelayed(.5f);
            t2.PlayDelayed(1f);
            once = false;
            lights.SetActive(true);
        }
       
        else 
        {
            StartCoroutine(prompts.Instance.NotEnoughFuel());
        }
        
    }
}
