using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallReset : MonoBehaviour {

    public Transform initial_Position;
    public AudioSource hit_ground_sound;
    public Material ballActiveMAT;
    public Material ballInactiveMAT;
    private GameObject startPosition;
    public GameManager _gameManager;
    public GameObject NextLevelInstructions;
    public Text CountDownText;

    private Vector3 originPos;
    private bool finishCountDown = false;


    float currentTime = 0f;
    float startingTime = 5f;

    void OnCollisionEnter(Collision collision)
    {
        
        Collider Ballobject;
        Ballobject = collision.gameObject.GetComponent<Collider>();

        
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayAudio();
            _gameManager.ResetStars();
            ResetPosition();

            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Renderer>().material = ballActiveMAT;
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            
            if (_gameManager.validatePickAllStars())
            {
                NextLevelInstructions.SetActive(true);
                _gameManager.SetWinLevel(true);
            }
            else {
                _gameManager.ResetStars();
                _gameManager.SetWinLevel(false);
                ResetPosition();
            }
        }
    }


    void startCountDownNextlevel() {

        currentTime -= Time.deltaTime;
        CountDownText.text = "LOADING NEXT LEVEL IN ..." + currentTime.ToString("0");

        if (currentTime <= 0) {
            currentTime = 0;
            _gameManager.SetGoNextLevel(true);
        }
    }


    // Use this for initialization
    void Start () {
        ResetPosition();
        originPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        currentTime = startingTime;
    }
	
	// Update is called once per frame
	void Update () {

        if (_gameManager.isWinLevel()) {

            if(!_gameManager.isLastLevel())
                startCountDownNextlevel();
            else
                CountDownText.text = "GAME OVER. THANKS FOR PLAYING";

        }
	}

    private void PlayAudio()
    {
        if (!hit_ground_sound.isPlaying)
        {
            hit_ground_sound.Play();
        }
    }

    public void ResetPosition()
    {
        transform.position = initial_Position.position;
        transform.rotation = Quaternion.identity;
    } 
}
