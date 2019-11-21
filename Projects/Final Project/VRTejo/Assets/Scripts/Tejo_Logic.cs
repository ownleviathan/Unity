using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Tejo_Logic : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabAction;
    private AudioSource audioTejo;
    private bool stopTejo = false;
    private bool throwTejo = false;
    private Vector3 _lastVelocity;


    private Transform previousPosition;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        audioTejo = this.GetComponent<AudioSource>();
        previousPosition = gameObject.transform;
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.CheckIfTjetoStopped();
        if (this.throwTejo) {
            if (!this.stopTejo)
            {
                if (previousPosition == gameObject.transform)
                {
                    Debug.Log("<<<<<<<<<<<<SE DETUVO aquiii>>>>>>>>>> " + previousPosition.position + " >>> " + gameObject.transform.position);
                    GameManager.instance.Player1.numTejosThrowed++;
                    GameManager.instance.checkScore();
                }
                else
                {
                    previousPosition = gameObject.transform;
                }
                this.stopTejo = true;
            }
        }
        
    }

    private void CheckIfTjetoStopped() {
        if (rb.IsSleeping()) {
            Debug.Log("Tejo de detuvo Totalmente.");
        }
    }

    private bool CheckGrabTejo() {
        return grabAction.GetState(handType);
    }

    void FixedUpdate()
    {
        rb.AddForce(-Vector3.up * thrust);
        //if (this.throwTejo)
            
    }

    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        //Debug.Log("Hovering hand: " + hand.name);
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        //Debug.Log("No Hand Hovering");
    }

    private void HandHoverUpdate(Hand hand)
    {        
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);
        if (startingGrabType != GrabTypes.None) {
            GameManager.instance.HitMud = false;         
        }
    }

    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        GameManager.instance.validThrowing = true;
        audioTejo.Play();
        this.throwTejo = true;

    }
}
