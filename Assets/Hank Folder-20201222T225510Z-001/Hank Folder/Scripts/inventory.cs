using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public GameObject fuelUI;
    public int fuelCarried;
    public Text invFuel;

    public GameObject genUI;

    public bool key1Carried;
    public GameObject key1;
    public bool key2Carried;
    public GameObject key2;

    public bool paper1Carried;
    public GameObject paper1;
    public bool paper2Carried;
    public GameObject paper2;
    public bool paper3Carried;
    public GameObject paper3;
    public bool paper4Carried;
    public GameObject paper4;
    public bool paper5Carried;
    public GameObject paper5;
    public bool paper6Carried;
    public GameObject paper6;
    public bool paper7Carried;
    public GameObject paper7;
    public bool paper8Carried;
    public GameObject paper8;

    public GameObject fPController;
    public GameObject crosshair;
    public GameObject crosshairObject;
    public GameObject torch;

    public bool firstPickFuel;
    public bool firstGen;
    public bool generatorCanWork;

    public Transform playerPos;

    private static inventory _instance;
    public static inventory Instance { get { return _instance; } }

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
        fuelCarried = 0;
        key1Carried = false;
        key2Carried = false;
        paper1Carried = false;
        paper2Carried = false;
        paper3Carried = false;
        paper4Carried = false;
        paper5Carried = false;
        paper6Carried = false;
        paper7Carried = false;
        paper8Carried = false;
        firstPickFuel = false;
        firstGen = false;
    }

    // Update is called once per frame
    void Update()
    {
        invFuel.text = fuelCarried+"";

        if (firstPickFuel == true)
        {
            fuelUI.SetActive(true);
        }
        if (firstGen == true)
        {
            genUI.SetActive(true);
        }


        if (key1Carried == true)
        {
            key1.SetActive(true);
        }
        else if (key1Carried == false)
        {
            key1.SetActive(false);
        }

        if (key2Carried == true)
        {
            key2.SetActive(true);
        }
        else if (key2Carried == false)
        {
            key2.SetActive(false);
        }

        if (paper1Carried == true)
        {
            paper1.SetActive(true);
        }
        else if (paper1Carried == false)
        {
            paper1.SetActive(false);
        }

        if (paper2Carried == true)
        {
            paper2.SetActive(true);
        }
        else if (paper2Carried == false)
        {
            paper2.SetActive(false);
        }

        if (paper3Carried == true)
        {
            paper3.SetActive(true);
        }
        else if (paper3Carried == false)
        {
            paper3.SetActive(false);
        }

        if (paper4Carried == true)
        {
            paper4.SetActive(true);
        }
        else if (paper4Carried == false)
        {
            paper4.SetActive(false);
        }

        if (paper5Carried == true)
        {
            paper5.SetActive(true);
        }
        else if (paper5Carried == false)
        {
            paper5.SetActive(false);
        }

        if (paper6Carried == true)
        {
            paper6.SetActive(true);
        }
        else if (paper6Carried == false)
        {
            paper6.SetActive(false);
        }

        if (paper7Carried == true)
        {
            paper7.SetActive(true);
        }
        else if (paper7Carried == false)
        {
            paper7.SetActive(false);
        }

        if (paper8Carried == true)
        {
            paper8.SetActive(true);
        }
        else if (paper8Carried == false)
        {
            paper8.SetActive(false);
        }


    }
}
