using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mecha_Explosion : MonoBehaviour
{

    private Vector3 explodeScale;
    public AudioSource audioSource;

    private MeshRenderer tejoMeshRender;
    private bool hasCollide = false;

    public GameObject explosionEffect;
    private ParticleSystem partiSystem;


    private void Awake()
    {
        tejoMeshRender = GetComponent<MeshRenderer>();
        partiSystem =  explosionEffect.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Explode() {

        explodeScale = explosionEffect.transform.localScale;

        explodeScale.x = 5;
        explodeScale.y = 20;
        explodeScale.z = 5;

        explosionEffect.transform.localScale = explodeScale;
    
        Instantiate(explosionEffect, transform.position, transform.rotation);
        audioSource.Play();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tejos"))
        {
            if (!hasCollide) {

                Debug.Log("<<<<<<<<<<<<MECHAAA>>>>>");
                hasCollide = true;
                Explode();
                tejoMeshRender.enabled = false;
                partiSystem.Stop();                                       
                GameManager.instance.AddMechaPlayer();
                GameManager.instance.Player1.numMechasExploted++;
                StartCoroutine(PlayandHide(audioSource.clip, this.gameObject));
                GameManager.instance.checkScore();
                //Destroy(gameObject, audioSource.clip.length);
                hasCollide = false;
            }                
        }
    }

    public IEnumerator PlayandHide(AudioClip clip, GameObject obj)
    {
        yield return new WaitForSeconds(clip.length);
        obj.SetActive(false);
        GameManager.instance.checkScore();
    }
}
