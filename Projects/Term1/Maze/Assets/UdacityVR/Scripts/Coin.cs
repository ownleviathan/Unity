using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{
	public ParticleSystem coinProofPrefab;
    //Create a reference to the CoinPoofPrefab
	void Update(){
		transform.Rotate (1, 0, 0);
	}

    public void OnCoinClicked() {
		Instantiate (coinProofPrefab, gameObject.transform.position, Quaternion.Euler(-90,0,0));
		//coinProofPrefab.transform.position = transform.position;
		//coinProofPrefab.Play ();
		Destroy (gameObject);
		GameManager.instance.coinCollected();
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
    }



}
