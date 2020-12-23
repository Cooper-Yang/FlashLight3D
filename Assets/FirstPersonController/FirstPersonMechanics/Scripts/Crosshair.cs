using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct CrosshairSize
{
    public Vector2 small;
    public Vector2 medium;
    public Vector2 big;
}


public class Crosshair : MonoBehaviour {

    //Sprites
    [Header("Icons")]
    [SerializeField] private Sprite pickUp;
    [SerializeField] private Sprite note;
    [SerializeField] private Sprite crosshair;

    //crossHair image
    private Image img;
    public CrosshairSize crosshairSize = new CrosshairSize();
    [SerializeField] private InteractionRayCaster _raycaster;

    [SerializeField] private GameObject Door;
    [SerializeField] private GameObject Player;

    // Use this for initialization
    void Start () {
        _raycaster = Camera.main.GetComponent<InteractionRayCaster>();

        _raycaster.onTargetChange += ChangeCrosshair;
        _raycaster.onNoTarget += ChangeCrosshair;

        img = gameObject.GetComponent<Image>();
        
    }


    private void OnDisable()
    {
        _raycaster.onTargetChange -= ChangeCrosshair;
        _raycaster.onNoTarget -= ChangeCrosshair;
    }

    void ChangeCrosshair()
    {
        if(_raycaster.Hit.collider != null)
        {
            switch (_raycaster.Hit.collider.tag)
            {
                case "Key":
                    Debug.Log("got key");
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    if(Input.GetKey(KeyCode.F))
                        _raycaster.Hit.collider.gameObject.GetComponent<keypickup>().pickedUp = true;
                    
                    break;
                case "Note":
                    SetIcon(note);
                    SetSize(crosshairSize.medium);
                    if (Input.GetKey(KeyCode.F))
                        _raycaster.Hit.collider.gameObject.GetComponent<Note>().pickedUp = true;
                    break;
                case "Door":
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    DoorOpenClose();
                    break;
                case "Fuel":
                    SetIcon(note);
                    SetSize(crosshairSize.medium);
                    if (Input.GetKey(KeyCode.F))
                        _raycaster.Hit.collider.gameObject.GetComponent<fuelcan>().pickedUp = true;
                    break;

                case "Generator":
                    SetIcon(note);
                    SetSize(crosshairSize.medium);
                    if (Input.GetKey(KeyCode.F))
                        _raycaster.Hit.collider.gameObject.GetComponent<generator>().AddFuel();
                    break;

                default:
                    SetIcon(crosshair);
                    SetSize(crosshairSize.small);
                    break;
            }
        }
        else
        {
            SetIcon(crosshair);
            SetSize(crosshairSize.small);
            return;
        }
    }


    void DoorOpenClose()
    {
        Debug.Log(_raycaster.Hit.collider.name);
        if (_raycaster.Hit.collider.name == "OutCollider")
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                
                if (Door.GetComponent<DoorMvmt>().isOpen)
                {
                    Door.GetComponent<DoorMvmt>().isOpen = false;
                }
                else if (Door.GetComponent<DoorMvmt>().isOpen == false)
                {
                    Door.GetComponent<DoorMvmt>().doorState = 2;
                    Door.GetComponent<DoorMvmt>().isOpen = true;
                }
            }
        }
        if (_raycaster.Hit.collider.name == "InCollider")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
               
                if (Door.GetComponent<DoorMvmt>().isOpen)
                {
                    Door.GetComponent<DoorMvmt>().isOpen = false;
                }
                else if (Door.GetComponent<DoorMvmt>().isOpen == false)
                {
                    Door.GetComponent<DoorMvmt>().doorState = 1;
                    Door.GetComponent<DoorMvmt>().isOpen = true;
                }
            }
        }


    }

    void SetIcon(Sprite icon)
    {
        img.sprite = icon;
    }

    void SetSize(Vector2 size)
    {
        img.GetComponent<RectTransform>().sizeDelta = size;
    }

}
