using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamControl : MonoBehaviour
{
    public Camera deathCam;
    public Camera mainCam;
    public bool isDead;
    public GameObject black;

    public float defFallSpeed;
    public float fallSpeed;
    public float defFallTime;
    public float fallTime;

    void Start()
    {
        deathCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        fallSpeed = defFallSpeed;
        fallTime = defFallTime;
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
                fallSpeed -= 0.8f * Time.deltaTime;
            deathCam.transform.position = new Vector3(0, Mathf.Lerp(deathCam.transform.position.y, 1f, 1 - fallSpeed/defFallSpeed), 0);
            if(fallSpeed <= 0)
            {
                if(fallTime <= 0)
                {
                    fallTime = 0f;
                    if (fallSpeed > -defFallSpeed)
                        fallSpeed -= 0.8f * Time.deltaTime;
                    deathCam.transform.position = new Vector3(0, Mathf.Lerp(deathCam.transform.position.y, 0.2f, (fallSpeed / defFallSpeed) * -1), 0);
                    Color color = black.GetComponent<Image>().color;
                    color.a += 0.8f * Time.deltaTime;
                    black.GetComponent<Image>().color = new Color(0, 0, 0, color.a);
                }
                else if(fallTime > 0)
                {
                    fallTime -= 0.8f * Time.deltaTime;
                }
            }
        }


    }
}
