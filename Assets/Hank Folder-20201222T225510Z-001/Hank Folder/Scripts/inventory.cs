﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public int fuelCarried;
    public Text invFuel;

    public bool key1Carried;
    public GameObject key1;
    public bool key2Carried;
    public GameObject key2;

    public bool paper1Carried;
    public GameObject paper1;
    public bool paper2Carried;
    public GameObject paper2;

    public GameObject fPController;
    public GameObject crosshair;

    public bool generatorCanWork;

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
    }

    // Update is called once per frame
    void Update()
    {
        invFuel.text = fuelCarried+"";

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


    }
}
