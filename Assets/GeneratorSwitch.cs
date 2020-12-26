using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorSwitch : MonoBehaviour
{
    public AudioSource t1;
    public AudioSource t2;
    bool once=true;
    public void SwitchToTheEnd()
    {
        if (inventory.Instance.generatorCanWork&&once)
        {
            AudioManager.Instance.GeneratorSwitch();
            t1.PlayDelayed(.5f);
            t2.PlayDelayed(1f);
            once = false;
        }
        else
        {
            StartCoroutine(prompts.Instance.NotEnoughFuel());
        }
        
    }
}
