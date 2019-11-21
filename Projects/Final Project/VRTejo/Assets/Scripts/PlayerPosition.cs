using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition instance = null;
    public GameObject menuPosition;
    public GameObject tejoPosition;

    private Vector3 newPosition;
    private Quaternion newRotation;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        
    }
    public void SetPlayerMenuPosition()
    {
        gameObject.transform.position = menuPosition.transform.position;
        gameObject.transform.rotation = menuPosition.transform.rotation;

    }

    public void SetPlayerTejoPosition()
    {
        gameObject.transform.position = tejoPosition.transform.position;
        gameObject.transform.rotation = tejoPosition.transform.rotation;
    }
}
