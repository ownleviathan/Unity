using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mononaCollider : MonoBehaviour
{

    private bool insideBocin = false;
    private bool addPoints = false;

    //private Collider mesh;
    // Start is called before the first frame update
    void Start()
    {
      //mesh = canchaCollider.gameObject.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (insideBocin && !addPoints) {
            GameManager.instance.AddEmbocinPlayer();            
            addPoints = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 Veltejo;
        Collider objCollider = GetComponent<Collider>();

        if (other.gameObject.CompareTag("Tejos"))
        {

            if (objCollider.bounds.Contains(other.bounds.max)&& objCollider.bounds.Contains(other.bounds.min))
            {
                Debug.Log("<<<<<<<<<<<<<<<<<<<<<<<EMBOCINADA>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Veltejo = other.attachedRigidbody.velocity;
                int valx = (int)Veltejo.x;
                int valy = (int)Veltejo.y;
                int valz = (int)Veltejo.z;
                if (valx == valy && valy == valz && valz == 0) {
                    insideBocin = true;                        
                    objCollider.enabled = false;
                    GameManager.instance.checkScore();
                }
                        
            }

        }

    }
}
