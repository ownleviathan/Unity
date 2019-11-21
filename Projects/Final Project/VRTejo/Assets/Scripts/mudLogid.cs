using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudLogid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tejos"))
        {
            Debug.Log("<<<<<HIT MUD>>>>>>");
            GameManager.instance.HitMud = true;
            GameManager.instance.Player1.addMano();
            //GameManager.instance.checkScore();
        }
    }
}
