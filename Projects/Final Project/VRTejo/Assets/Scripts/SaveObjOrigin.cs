using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjOrigin : MonoBehaviour
{
    public static SaveObjOrigin instance = null;

    public GameObject[] tejos;
    //public List<GameObject> mechas;
    public GameObject[] mechas;
    private Vector3[] startPosTejos;
    private Quaternion[] startRotTejos;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        startPosTejos = new Vector3[tejos.Length];
        startRotTejos = new Quaternion[tejos.Length];
        //mechas = new List<GameObject>();

        for (int i = 0; i < tejos.Length; i++)
        {
            startPosTejos[i] = tejos[i].transform.position;
            startRotTejos[i] = tejos[i].transform.rotation;
        }

    }

    public void ResetMechas()
    {
        foreach (GameObject obj in mechas) {
            obj.SetActive(true);
            obj.GetComponent<MeshRenderer>().enabled = true;
        }       
    }

    public void ResetTejos()
    {
        for (int i = 0; i < tejos.Length; i++)
        {
            tejos[i].transform.position = startPosTejos[i];
            tejos[i].transform.rotation = startRotTejos[i];
        }
    }
}
