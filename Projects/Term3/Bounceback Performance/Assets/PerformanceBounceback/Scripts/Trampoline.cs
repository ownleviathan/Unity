using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trampoline : MonoBehaviour {

    private ParticleSystem pSystem;
    public GameManager _gameManager;

	// Use this for initialization
	void Start () {
        pSystem = GetComponentInChildren<ParticleSystem>();
    }
	
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Throwable"))
        {
            //Score Point
            _gameManager.IncrementScore(1);
            //Particle effect
            pSystem.Play();
        }

    }
}
