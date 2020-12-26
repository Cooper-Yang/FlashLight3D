using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ghostIdle;
    public AudioClip ghostScream;
    public Transform player;
    public GameObject torch;
    public AudioSource aSScraeam;

    bool canScream = true;
    

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        //print(dist);
        if (dist < 25 && canScream&&torch.GetComponent<flashlight>().on)
        {
            Debug.Log("scream!");
            aSScraeam.Play();
            canScream = false;
        }
        else if(dist>32)
        {
            canScream = true;
        }
    }
}
