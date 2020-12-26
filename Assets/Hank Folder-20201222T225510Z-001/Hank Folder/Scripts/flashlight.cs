using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public bool on;
    public Light torch;
    
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (on == true)
            {
                torch.enabled = false;
                on = false;
                AudioManager.Instance.FlashLightClick();
                AITargetScript.me.StopChasingPlayer();
            }
            else if (on == false)
            {
                torch.enabled = true;
                on = true;
                AudioManager.Instance.FlashLightClick();
                AITargetScript.me.ChasePlayer(inventory.Instance.playerPos);
            }
        }
        
    }
}
