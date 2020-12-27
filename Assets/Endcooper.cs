using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Endcooper : MonoBehaviour
{
    public Camera endCam;
    public Camera mainCam;

    public GameObject doorChild; //The door body child of the door prefab.
    public GameObject audioChild; //The prefab's audio source GameObject, from which the sounds are played.
    public GameObject rollDoor;

    public Text title;
    public float counter;

    public AudioClip openSound; //The door opening sound effect (3D sound.)
    public AudioClip closeSound; //The door closing sound effect (3D sound.)

    public bool inTrigger = false; //Bool to check if CharacterController is in the trigger.
    private bool doorOpen = false; //Bool used to check the state of the door, if it's open or not.
    private bool counterOn = false;
    void Start()
    {
        endCam.gameObject.SetActive(false);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (counterOn)
        {
            counter += 0.1f * Time.deltaTime;
            if (counter >= 1)
                counter = 1;
            title.color = new Color(title.color.r, title.color.g, title.color.b, Mathf.Lerp(0f, 1f, counter));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        endCam.gameObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        rollDoor.GetComponent<BasicDoor>().doorOpenClose();
        counterOn = true;
        //SceneManager.LoadScene(2);
    }
}
