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

    bool getKey;
    bool getNote;
    bool getFuel;
    bool openDoor;
    bool pourGenerator;
    bool openLight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (getKey)
            {
                _raycaster.Hit.collider.gameObject.GetComponent<keypickup>().pickedUp = true;
            }
            else if (getNote)
            {
                _raycaster.Hit.collider.gameObject.GetComponent<Note>().pickedUp = true;
            }
            else if (getFuel)
            {
                _raycaster.Hit.collider.gameObject.GetComponent<fuelcan>().pickedUp = true;
            }
            else if (openDoor)
            {
                DoorOpenClose();
            }
            else if (pourGenerator)
            {
                _raycaster.Hit.collider.gameObject.GetComponent<generator>().AddFuel();
            }
            else if (openLight)
            {
                _raycaster.Hit.collider.gameObject.GetComponent<LightSwitchScript>().SwitchLights();
            }
        }
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
                    getKey = true;
                    getNote = false;
                    getFuel = false;
                    openDoor = false;
                    pourGenerator = false;
                    openLight = false;

                    break;
                case "Note":
                    SetIcon(note);
                    SetSize(crosshairSize.medium);
                    getKey = false;
                    getNote = true;
                    getFuel = false;
                    openDoor = false;
                    pourGenerator = false;
                    openLight = false;

                    break;
                case "Door":
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    getKey = false;
                    getNote = false;
                    getFuel = false;
                    openDoor = true;
                    pourGenerator = false;
                    openLight = false;
                    break;
                case "Fuel":
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    getKey = false;
                    getNote = false;
                    getFuel = true;
                    openDoor = false;
                    pourGenerator = false;
                    openLight = false;

                    break;

                case "Generator":
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    getKey = false;
                    getNote = false;
                    getFuel = false;
                    openDoor = false;
                    pourGenerator = true;
                    openLight = false;

                    break;

                case "Light Switch":
                    
                    SetIcon(pickUp);
                    SetSize(crosshairSize.medium);
                    print("switch");
                    getKey = false;
                    getNote = false;
                    getFuel = false;
                    openDoor = false;
                    pourGenerator = false;
                    openLight = true;

                    break;

                default:
                    SetIcon(crosshair);
                    SetSize(crosshairSize.small);
                    getKey = false;
                    getNote = false;
                    getFuel = false;
                    openDoor = false;
                    pourGenerator = false;
                    openLight = false;
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
        //ebug.Log(_raycaster.Hit.collider.name);
        if (_raycaster.Hit.collider.name == "OutCollider")
        {
           
            
                if (_raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen)
                {
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen = false;
                }
                else if (_raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen == false)
                {
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().doorState = 2;
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen = true;
                }
            
        }
        if (_raycaster.Hit.collider.name == "InCollider")
        {
            
                if (_raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen)
                {
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen = false;
                }
                else if (_raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen == false)
                {
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().doorState = 1;
                    _raycaster.Hit.collider.gameObject.GetComponentInParent<DoorMvmt>().isOpen = true;
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
