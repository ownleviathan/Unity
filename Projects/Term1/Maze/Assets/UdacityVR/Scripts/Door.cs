using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{

	[Tooltip ("The name of the Animator trigger parameter")]
	public string animationName;
	[Tooltip ("The Animator component on this gameobject")]
	public Animator animatorGameObject;

	public AudioSource door_Locked;
	public AudioSource door_Opened;
	public GameObject templePrefab;

	public void OnDoorClicked() {

		bool checkKey = GameManager.instance.foundKey ();

		Debug.Log ("Value of foundKey :" + checkKey);
		if (checkKey) {
			door_Opened.Play ();
			animatorGameObject.SetTrigger (animationName);
			gameObject.GetComponent<Collider> ().enabled = false;
			templePrefab.GetComponent<Collider> ().enabled = false;

		} else {
			door_Locked.Play ();
		}
	}
}
