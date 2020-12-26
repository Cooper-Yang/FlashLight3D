using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public Text first;
    public Text second;
    public bool firstClick;
    public bool firstPress;

    public Image crosshair;
    void Start()
    {
        first.enabled = true;
        second.enabled = false;
        firstClick = false;
        firstPress = false;
        inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
        crosshair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (firstClick == false)
            {
                first.enabled = false;
                second.enabled = true;
                firstClick = true;
                inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
                crosshair.enabled = true;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (firstPress == false && firstClick==true)
            {
                first.enabled = false;
                second.enabled = false;
                firstPress = false;
            }

        }
    }
}
