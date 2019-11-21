using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer_Logic : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(-Vector3.up * thrust);
    }
}
