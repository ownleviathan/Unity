using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManipulation : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;

    public bool isRightHand;

    public GameObject ballObject;
    public float throwforce = 1.5f;

    //Swipe
    private float swipeSum;
    private float touchLast;
    private float touchCurrent;
    private float distance;
    private bool hasSwipedLeft;
    private bool hasSwipedRight;
    private bool oculus;

    private bool menuActivated = false;

    public ObjectMenuManager objectMenuManager;
    public GameManager _gameManager;

    private BallReset _ballReset;

    public GameObject instructions;

    public ObjectsbyLevel byLevel;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        if (UnityEngine.XR.XRDevice.model.Contains("Oculus")){
            oculus = true;
        }
        else {
            oculus = false;
        }

        _ballReset = ballObject.GetComponent<BallReset>();
        _gameManager.SetValidThrow(true);

	}
	
	// Update is called once per frame
	void Update ()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        int rightIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        int leftIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);

        SteamVR_Controller.Device rightDevice = SteamVR_Controller.Input(rightIndex);
        SteamVR_Controller.Device leftDevice = SteamVR_Controller.Input(leftIndex);

        if (isRightHand)
        {
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                touchLast = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            }

            if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
               
                touchCurrent = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
                if (menuActivated) {
                    if (oculus)
                    {
                        swipeSum = touchCurrent;
                    }
                    else
                    {
                        distance = touchCurrent - touchLast;
                        touchLast = touchCurrent;
                        swipeSum += distance;
                    }
                    if (!hasSwipedRight)
                    {
                        if (swipeSum > 0.5f)
                    {
                        Debug.Log("Swipe Right");
                        swipeSum = 0;
                        SwipeRight();
                        hasSwipedRight = true;
                        hasSwipedLeft = false;
                    }
                }

                if (!hasSwipedLeft)
                {
                    if (swipeSum < -0.5f)
                    {
                        Debug.Log("Swipe Left");
                        swipeSum = 0;
                        SwipeLeft();
                        hasSwipedRight = false;
                        hasSwipedLeft = true;
                    }
                    }

                }
            }

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                objectMenuManager.EnableDisableMenu();
                menuActivated = !menuActivated;
            }

            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                SwipeReset();
            }

            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                //Spawn object currently selected by menu
                SpawnObject();

            }
        }
    }

    void SpawnObject()
    {
        objectMenuManager.SpawnCurrentObject();
    }

    void SwipeLeft()
    {
        objectMenuManager.MenuLeft();
    }

    void SwipeRight()
    {
        objectMenuManager.MenuRight();
    }

    private void SwipeReset()
    {
        swipeSum = 0;
        touchCurrent = 0;
        touchLast = 0;
        hasSwipedRight = false;
        hasSwipedLeft = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Throwable"))
        {
            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                ThrowObject(other);
            }
            else if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                GrabObject(other);
            }
        }
    }

    private void GrabObject(Collider other)
    {
        other.transform.SetParent(gameObject.transform);
        other.GetComponent<Rigidbody>().isKinematic = true;
        device.TriggerHapticPulse(2000);
        if (other.gameObject.name =="Ball") {
            //Debug.Log("Grab ball");
            other.GetComponent<Rigidbody>().useGravity = true;
            instructions.SetActive(false);
        }
    }

    private void ThrowObject(Collider other)
    {

        other.transform.SetParent(null);

       if (other.gameObject.layer !=  9) {
            if (_gameManager.isValidThrow())
            {
                Rigidbody rigidbody = other.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                rigidbody.useGravity = true;
                rigidbody.velocity = device.velocity * throwforce;
                rigidbody.angularVelocity = device.angularVelocity;
            }
            else {
                _ballReset.ResetPosition();
                //Debug.Log("Can't throw the ball");
            }

        }
        
    }
}
