using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public bool paper1;
    public bool paper2;
    public bool paper3;
    public bool paper4;
    public bool paper5;
    public bool paper6;
    public bool paper7;
    public bool paper8;

    public bool pickedUp;

    //public bool gamePause;

    private void Update()
    {
        
        if (pickedUp)
        {
            displayUI();
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            notDisplayUI();
            Time.timeScale = 1;
            pickedUp = false;
        }
    }

    public void displayUI()
    {
        if (paper1)
        {
            inventory.Instance.paper1Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper2)
        {
            inventory.Instance.paper2Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper3)
        {
            inventory.Instance.paper3Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper4)
        {
            inventory.Instance.paper4Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper5)
        {
            inventory.Instance.paper5Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper6)
        {
            inventory.Instance.paper6Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper7)
        {
            inventory.Instance.paper7Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
        else if (paper8)
        {
            inventory.Instance.paper8Carried = true;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = false;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = false;
            inventory.Instance.GetComponent<flashlight>().enabled = false;
        }
    }

    public void notDisplayUI()
    {
        if (paper1)
        {
            inventory.Instance.paper1Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper2)
        {
            inventory.Instance.paper2Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper3)
        {
            inventory.Instance.paper3Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper4)
        {
            inventory.Instance.paper4Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper5)
        {
            inventory.Instance.paper5Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper6)
        {
            inventory.Instance.paper6Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper7)
        {
            inventory.Instance.paper7Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
        else if (paper8)
        {
            inventory.Instance.paper8Carried = false;
            inventory.Instance.fPController.GetComponent<CameraController>().enabled = true;
            inventory.Instance.crosshair.GetComponent<Canvas>().enabled = true;
            inventory.Instance.GetComponent<flashlight>().enabled = true;
        }
    }
}
