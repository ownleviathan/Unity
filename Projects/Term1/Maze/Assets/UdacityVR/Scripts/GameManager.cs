using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	int numOfCoins;
	Text scoreTextCoins;
	Text keyFoundText;
	bool keyCollected = false;

	public static GameManager instance = null;

	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	public void KeyCollected(){

		this.keyCollected = true;
		keyFoundText.text = "Key Found? : Yes";
	}

	public bool foundKey(){
		return this.keyCollected;
	}

	public void coinCollected(){
		numOfCoins++;
	}

	public int coinsCollected(){
		return this.numOfCoins;
	}

}
