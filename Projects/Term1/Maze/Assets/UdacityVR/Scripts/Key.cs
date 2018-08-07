using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public ParticleSystem keyProofPrefab;
	public GameObject DoorPrefab;

	public float degreesPerSecond = 15.0f;
	public float amplitude = 0.5f;
	public float frequency = 1f;


	// Position Storage Variables
	Vector3 posOffset = new Vector3 ();
	Vector3 tempPos = new Vector3 ();

	bool floatUp;

	void Start(){
		// Store the starting position & rotation of the object
		posOffset = transform.position;
	}

	void Update(){
		// Spin object around Y-Axis
		transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

		// Float up/down with a Sin()
		tempPos = posOffset;
		tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

		transform.position = tempPos;
	}


	public void OnKeyClicked()
	{
		Instantiate (keyProofPrefab, gameObject.transform.position, Quaternion.Euler(-90,0,0));
		Destroy (gameObject);
		GameManager.instance.KeyCollected ();

		//GameManagerMaze.instance.Collect
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy
    }

}
