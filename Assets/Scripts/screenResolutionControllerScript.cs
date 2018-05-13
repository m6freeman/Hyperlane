using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenResolutionControllerScript : MonoBehaviour {

	    public static screenResolutionControllerScript Instance;



	void Awake () // creating static instance of type GameManager
    {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy (Instance);
        }

		Screen.SetResolution(450, 800, false);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
