using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoundingSound : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip[] pound;
    public bool canPound = true;
    public IEnumerator Pounding()
    {
        
        aS.clip = pound[Random.Range(0, 3)];
        aS.Play();
        canPound = false;
        yield return new WaitForSeconds(0.5f);
        canPound = true;
    }
}
