using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DoorMvmt : MonoBehaviour
{
    public Animator DoorAnim;

    public bool isOpen = false;
    public bool canOpen = false;
    public int doorState = 0;

    public bool isLocked = false;
    public bool Lock1 = false; //check if it can be open by key 1
    public bool Lock2 = false; //check if it can be open by key 2
    public GameObject inventory;

    public bool canOpenByGhost = false;
    private bool settodoor = false;

    // Update is called once per frame
    void Update()
    {
        DoorAnim.SetBool("Open", isOpen);

        DoorAnim.SetInteger("OpenState", doorState);

        canOpen = CheckDoorLock();

        if(canOpenByGhost)
        {
            if(settodoor == false)
            {
                changeLayerToDoors();
            }
            
        }

    }

    public void OpenDoorSound()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public bool CheckDoorLock()
    {
        if(isLocked)
        {
            if(Lock1)
            {
                if(inventory.GetComponent<inventory>().key1Carried)
                {
                    
                    return true;
                }
                else
                    //Debug.Log("No Key1");
                    return false;
            }
            if (Lock2)
            {
                if (inventory.GetComponent<inventory>().key2Carried)
                {
                    return true;
                }
                else
                    //Debug.Log("No Key2");
                    return false;
            }
            else
            {
                //Debug.Log("No Lock Chosen");
                return false;
            }
                
                

        }
        else
            return true;


    }

    public void changeLayerToDoors()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Doors");
        foreach(Transform child in transform)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Doors");
            foreach(Transform c in child.transform)
            {
                c.gameObject.layer = LayerMask.NameToLayer("Doors");
            }
        }

        AstarPath.active.Scan();
        settodoor = true;
    }

    
}
