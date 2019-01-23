using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidArea : MonoBehaviour {

    public GameManager _gameManager;
    public GameObject ballObject;
    public Material ballActiveMaterial;
    public Material ballInactiveMaterial;
    public Material AreaValidMaterial;
    public Material AreaInvalidMaterial;
    
    private Renderer areaRenderer;
    private Renderer ballRenderer;
    private bool playerInBounds;


    // Use this for initialization
    void Start () {
        areaRenderer = GetComponent<Renderer>();
        ballRenderer = ballObject.GetComponent<Renderer>();
        _gameManager.SetValidThrow(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.name == "Ball")
        {
            _gameManager.SetValidThrow(true);
            areaRenderer.material = AreaValidMaterial;
            ballRenderer.material = ballActiveMaterial;
        }
    }

    void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.name == "Ball")
        {
            _gameManager.SetValidThrow(false);
            areaRenderer.material = AreaInvalidMaterial;
            ballRenderer.material = ballInactiveMaterial;
        }
    }
}
