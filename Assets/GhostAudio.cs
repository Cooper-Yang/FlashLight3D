using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip ghostIdle;
    public AudioClip ghostScream;
    public Transform player;
    
    public AudioSource aSScraeam;

    bool canScream = true;
    

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        //print(dist);
        if (dist < 25 && canScream)
        {
            Debug.Log("scream!");
            aSScraeam.Play();
            canScream = false;
        }
    }
}
