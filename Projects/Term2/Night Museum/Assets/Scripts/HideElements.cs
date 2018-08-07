﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideElements : MonoBehaviour {

	public GameObject raycastHolder;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forwardDir = raycastHolder.transform.TransformDirection (Vector3.forward) * 100;
		if (Physics.Raycast (raycastHolder.transform.position, (forwardDir), out hit)) {
			if (hit.collider.gameObject.tag != "movementCapable") {
				gameObject.SetActive (false);
			}
		}
	}
}
