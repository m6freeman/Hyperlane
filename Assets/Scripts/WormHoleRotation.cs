using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHoleRotation : MonoBehaviour {

	public int scaleSpeed = 1;
	private bool grow;
    // Use this for initialization
    void Start () {
		
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate(0, 0, Time.deltaTime * 50);
		if (grow)
		{
			transform.localScale += new Vector3(Time.deltaTime * scaleSpeed, Time.deltaTime * scaleSpeed, Time.deltaTime * scaleSpeed);
			if (transform.localScale.x >= 7) grow = false;
			
		} else if ( !grow )
		{
			transform.localScale -= new Vector3(Time.deltaTime * scaleSpeed, Time.deltaTime * scaleSpeed, Time.deltaTime * scaleSpeed);
			if (transform.localScale.x <= 6) grow = true;
		}
    }
}