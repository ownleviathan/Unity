using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeSpin : MonoBehaviour {

	private bool startSpin = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			startSpin = !startSpin;
		}

		if(startSpin)
			transform.Rotate (0, 1, 0);
	}
}
