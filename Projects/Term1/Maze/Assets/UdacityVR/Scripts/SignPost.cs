using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignPost : MonoBehaviour
{	

	Text coinsText;

	void Update(){
		coinsText = gameObject.GetComponent<Text> ();
		coinsText.text = " YOU WIN " +"\n" + "Coins: " + GameManager.instance.coinsCollected ().ToString () +"/10";
	}

	public void ResetScene() 
	{
		SceneManager.LoadScene ("A Maze");
	}
}