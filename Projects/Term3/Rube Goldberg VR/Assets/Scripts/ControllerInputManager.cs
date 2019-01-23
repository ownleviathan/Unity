using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ControllerInputManager : MonoBehaviour {
    public SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    //Teleport
    public LayerMask laserMask;
    private LineRenderer laser;
    public GameObject Valid_teleportAimer;
    public Vector3 teleportLocation;
    public GameObject player;
  
    public static float yNudgeAmount = 1f;
    private static readonly Vector3 yNudgeVector = new Vector3(0f, yNudgeAmount, 0f);
    private bool hitArea;


    private TeleportArc teleportArc = null;

    public Material ValidColor;
    public Material InvalidColor;

    private void Awake()
    {
        laser = GetComponentInChildren<LineRenderer>();

    }

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        

        hitArea = false;
	}
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
            laser.gameObject.SetActive(true);
            setLaserStart(gameObject.transform.position);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 15, laserMask))
            {
                teleportLocation = hit.point;

                setLaserEnd(teleportLocation);

                laser.material = ValidColor;
                Valid_teleportAimer.SetActive(true);
                Valid_teleportAimer.transform.position = teleportLocation + yNudgeVector;
                hitArea = true;

            }
          else
            {
                teleportLocation = transform.position + 15 * transform.forward;
                hitArea = false;
                laser.material = InvalidColor;
                Valid_teleportAimer.SetActive(false);

                // RaycastHit groundRay;
                //  if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 1, laserMask))
                // {
                //     teleportLocation.y = groundRay.point.y;
                // }
            }

            setLaserEnd(teleportLocation);

            Valid_teleportAimer.transform.position = teleportLocation + yNudgeVector;
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad)) {
            laser.gameObject.SetActive(false);
            Valid_teleportAimer.SetActive(false);
            if(hitArea)
                player.transform.position = teleportLocation;
        }
	}

    void setLaserStart(Vector3 startPos)
    {
        laser.SetPosition(0, startPos);
    }

    void setLaserEnd(Vector3 endPos)
    {
        laser.SetPosition(1, endPos);
    }
}
