using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerControl : MonoBehaviour
{

    private bool accelerometerEnabled;
    private Vector3 pos;

    private float parallaxAdjust = 1;

    public GameObject[] Stars = new GameObject[3];

    // Use this for initialization
    void Start()
    {
        accelerometerEnabled = EnableAccelerometer();
    }

    private bool EnableAccelerometer()
    {
        if (SystemInfo.supportsAccelerometer)
        {
            accelerometerEnabled = true;
            return true;
        }

        
        
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (accelerometerEnabled)
        {
            foreach (var star in Stars)
            {
                star.transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
                parallaxAdjust /= 2;
                if (parallaxAdjust < 0.25f)
                {
                    parallaxAdjust = 1;
                }
            }

        }
    }
}
