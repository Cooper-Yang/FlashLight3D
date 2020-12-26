using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prompts : MonoBehaviour
{


    public Text noFuels;
    public Text notEnoughFuels;
    public Text noPowers;
    public Text noKeys;
 

    private static prompts _instance;
    public static prompts Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        /* notEnoughFuel = true;
         noFuel = true;
         noPower = true;
         noKey = true;
         haveAKey = false;
         haveBkey = false;

      */
        noFuels.enabled = false;
        notEnoughFuels.enabled = false;
        noKeys.enabled = false;
        noPowers.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        /*
        //interact with generator
        if (noFuel)
        {
            StartCoroutine(NoFuel());
        }

        if (notEnoughFuel == true)
        {
            StartCoroutine(NotEnoughFuel());
        }

        //interact with door
        if (noKey)
        {
            StartCoroutine(NoKey());
        }

      

        //interact with elevator door
        if (noPower)
        {
            StartCoroutine(NoPower());
        }
         */

    }

    public IEnumerator NoFuel()
    {
        noFuels.enabled = true;
        yield return new WaitForSeconds(3f);
        noFuels.enabled = false;
    }
    public IEnumerator NotEnoughFuel()
    {
        notEnoughFuels.enabled = true;
        yield return new WaitForSeconds(3f);
        notEnoughFuels.enabled = false;
    }
    public IEnumerator NoKey()
    {
        noKeys.enabled = true;
        yield return new WaitForSeconds(3f);
        noKeys.enabled = false;
    }
   
    public IEnumerator NoPower()
    {
        noPowers.enabled = true;
        yield return new WaitForSeconds(3f);
        noPowers.enabled = false;
    }

}
