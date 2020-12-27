using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CamControl : MonoBehaviour
{
    public Camera deathCam;//new cam called deeathcam
    public Camera mainCam;//player cam
    public bool isDead;//dead bool
    public GameObject black;//black panel
    public GameObject player;
    public Text dead;
    [Header("Controll Times")]
    //No need to change non-def floats. Public is easy for checking.
    //Change only def floats.
    public float defFallSpeed;
    public float fallSpeed;
    public float defFallTime;
    public float fallTime;
    public float defRotateTime;
    public float rotateTime;

    void Start()
    {
        dead.gameObject.SetActive(false);
        deathCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        fallSpeed = defFallSpeed;
        fallTime = defFallTime;
        rotateTime = defRotateTime;
    }

    void Update()
    {
        if(isDead)
        {
            deathCam.transform.position = mainCam.transform.position;
            deathCam.transform.rotation = mainCam.transform.rotation;
            deathCam.gameObject.SetActive(true);
            mainCam.gameObject.SetActive(false);
            if (fallSpeed > 0)
            {
                fallSpeed -= 0.8f * Time.deltaTime;
                //fallSpeed *= 1.01f;
            }
            deathCam.transform.position = new Vector3(deathCam.transform.position.x, Mathf.Lerp(deathCam.transform.position.y, 2.3f, 1 - fallSpeed/defFallSpeed), deathCam.transform.position.z);
            if(fallSpeed <= 0)
            {
                if(fallTime <= 0)
                {
                    fallTime = 0f;
                    if (fallSpeed > -defFallSpeed)
                    {
                        fallSpeed -= 0.8f * Time.deltaTime;
                        fallSpeed *= 1.01f;
                    }
                    rotateTime -= 0.8f * Time.deltaTime;
                    if (rotateTime < 0)
                        rotateTime = 0;
                    deathCam.transform.position = new Vector3(deathCam.transform.position.x, 
                                                              Mathf.Lerp(deathCam.transform.position.y, 1.85f, (fallSpeed / defFallSpeed) * -1), deathCam.transform.position.z);
                    deathCam.transform.rotation = Quaternion.Euler(deathCam.transform.rotation.eulerAngles.x, deathCam.transform.rotation.eulerAngles.y, 
                                                  Mathf.Lerp(deathCam.transform.rotation.eulerAngles.z, -76f, 1 - rotateTime/defRotateTime));
                    Color color = black.GetComponent<Image>().color;
                    color.a += 0.8f * Time.deltaTime;
                    black.GetComponent<Image>().color = new Color(0, 0, 0, color.a);
                }
                else if(fallTime > 0)
                {
                    fallTime -= 0.8f * Time.deltaTime;
                }
            }
            if(black.GetComponent<Image>().color.a >= 1)
            {
                dead.gameObject.SetActive(true);
                dead.text = "You died.\nMaybe...use the torch wisely...\nPress ‘R’ to start the next samsara.";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }


    }
}
