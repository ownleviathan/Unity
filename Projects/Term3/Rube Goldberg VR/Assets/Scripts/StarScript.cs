using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour {

    public GameManager _gameManager;
    public AudioSource _pickCoin;

    private void OnTriggerEnter(Collider collision)
    {
        Collider coli =  collision.GetComponent<Collider>();

        if (coli.name == "Ball")
        {
            _gameManager.collectStar();
            _pickCoin.Play();
            StartCoroutine(hideStar()); 
        }
    }

    public IEnumerator hideStar() {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    } 

}
