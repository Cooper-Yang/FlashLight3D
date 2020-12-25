using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoorAnim.SetBool("Open", isOpen);

        DoorAnim.SetInteger("OpenState", doorState);

        canOpen = CheckDoorLock();
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
                    Debug.Log("No Key1");
                    return false;
            }
            if (Lock2)
            {
                if (inventory.GetComponent<inventory>().key2Carried)
                {
                    return true;
                }
                else
                    Debug.Log("No Key2");
                    return false;
            }
            else
            {
                Debug.Log("No Lock Chosen");
                return false;
            }
                
                

        }
        else
            return true;


    }

    
}
