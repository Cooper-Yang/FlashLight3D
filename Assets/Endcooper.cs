using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Endcooper : MonoBehaviour
{
    public Camera endCam;
    public Camera mainCam;

    public GameObject rollDoor;

    public Text title;
    public float counter;

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
        rollDoor.GetComponent<BasicDoor>().doorChild.GetComponent<Animation>().Stop();
        rollDoor.GetComponent<BasicDoor>().doorOpenClose();
        counterOn = true;
        //SceneManager.LoadScene(2);
    }
}
