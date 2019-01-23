using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMenuManager : MonoBehaviour {
    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public bool isActive = false;

    public ObjectsbyLevel byLevel;

    public int currentObject = 0;

    public Text fan_text;
    public Text trampoline_text;
    public Text metal_text;
    public Text wook_text;
    public Text control_fan_text;    
    public Text control_trampoline_text;    
    public Text control_metal_text;    
    public Text control_wook_text;

    // Use this for initialization

    private void Awake()
    {
        fan_text.text = "FANS AVAILABLE : " + byLevel.FansAvailable.ToString() + "/" + byLevel.numberOfFans.ToString();
        trampoline_text.text = "TRAMPOLINES AVAILABLE : " + byLevel.TrampolinesAvailable.ToString() + "/" + byLevel.numberOfTrampolines.ToString();
        metal_text.text = "METAL PLANKS AVAILABLE : " + byLevel.MetalPlanksAvailable.ToString() + "/" + byLevel.numberOfMetalPlanks.ToString();
        wook_text.text = "WOOK PLANKS AVAILABLE : " + byLevel.WoodenPlanksAvailable.ToString() + "/" + byLevel.numberOfWoodenPlanks.ToString();

        control_fan_text.text = "FANS AVAILABLE : " + byLevel.FansAvailable.ToString() + "/" + byLevel.numberOfFans.ToString();
        control_trampoline_text.text = "TRAMPOLINES AVAILABLE : " + byLevel.TrampolinesAvailable.ToString() + "/" + byLevel.numberOfTrampolines.ToString();
        control_metal_text.text = "METAL PLANKS AVAILABLE : " + byLevel.MetalPlanksAvailable.ToString() + "/" + byLevel.numberOfMetalPlanks.ToString();
        control_wook_text.text = "WOOK PLANKS AVAILABLE : " + byLevel.WoodenPlanksAvailable.ToString() + "/" + byLevel.numberOfWoodenPlanks.ToString();
    }
    void Start () {
        foreach (Transform child in transform) {
            objectList.Add(child.gameObject);
        }
	}

    public void MenuLeft() {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0) {
            currentObject = objectList.Count - 1;
        }
        objectList[currentObject].SetActive(true);
    }

    public void MenuRight() {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count - 1)
        {
            currentObject = 0;
        }
        objectList[currentObject].SetActive(true);
    }

    public void SpawnCurrentObject()
    {
        if (isActive)
        {
            if (currentObject == 0)
            {
                Debug.Log("Fans available: " + byLevel.FansAvailable.ToString() + " Fan game: " + byLevel.numberOfFans.ToString());
                if (byLevel.FansAvailable != 0) {
                    Instantiate(byLevel.UseFan(), objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
                    fan_text.text = "FANS AVAILABLE : " + byLevel.FansAvailable.ToString() + "/" + byLevel.numberOfFans.ToString();
                    control_fan_text.text = "FANS AVAILABLE : " + byLevel.FansAvailable.ToString() + "/" + byLevel.numberOfFans.ToString();
                }
            }

            if (currentObject == 1) {
                if (byLevel.MetalPlanksAvailable != 0) {
                    Instantiate(byLevel.UseMetalPlank(), objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
                    metal_text.text = "METAL PLANKS AVAILABLE : " + byLevel.MetalPlanksAvailable.ToString() + "/" + byLevel.numberOfMetalPlanks.ToString();
                    control_metal_text.text = "METAL PLANKS AVAILABLE : " + byLevel.MetalPlanksAvailable.ToString() + "/" + byLevel.numberOfMetalPlanks.ToString();
                } 
            }
            if (currentObject == 2){
                if (byLevel.TrampolinesAvailable != 0) {
                    Instantiate(byLevel.UseTrampoline(), objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
                    trampoline_text.text = "TRAMPOLINES AVAILABLE : " + byLevel.TrampolinesAvailable.ToString() + "/" + byLevel.numberOfTrampolines.ToString();
                    control_trampoline_text.text = "TRAMPOLINES AVAILABLE : " + byLevel.TrampolinesAvailable.ToString() + "/" + byLevel.numberOfTrampolines.ToString();
                }               
            }
            if (currentObject == 3){
                if (byLevel.WoodenPlanksAvailable != 0) {
                    Instantiate(byLevel.UseWoodenPlank(), objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
                    wook_text.text = "WOOK PLANKS AVAILABLE : " + byLevel.WoodenPlanksAvailable.ToString() + "/" + byLevel.numberOfWoodenPlanks.ToString();
                    control_wook_text.text = "WOOK PLANKS AVAILABLE : " + byLevel.WoodenPlanksAvailable.ToString() + "/" + byLevel.numberOfWoodenPlanks.ToString();
                }                
            }
        }
    }

    public void EnableDisableMenu()
    {
        if (!isActive)
        {
            // show current
            objectList[currentObject].SetActive(true);
            isActive = true;
        }
        else
        {
            foreach (GameObject obj in objectList)
            {
                obj.SetActive(false);
            }
            isActive = false;
        }
    }
}
