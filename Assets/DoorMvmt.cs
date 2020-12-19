using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMvmt : MonoBehaviour
{
    public Animator DoorAnim;

    public bool isOpen = false;
    public int doorState = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen == false)
        {
            DoorAnim.SetBool("Open", false);
        }
        if (isOpen == true)
        {
            DoorAnim.SetBool("Open", true);
        }

        DoorAnim.SetInteger("OpenState", doorState);

    }

    
}
