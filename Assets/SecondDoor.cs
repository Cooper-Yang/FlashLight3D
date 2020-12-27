using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    public static bool Opened;

    // Start is called before the first frame update

    private void Start()
    {
        Opened = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GetComponent<DoorMvmt>().isOpen)
        {
            Opened = true;
        }
    }
}
