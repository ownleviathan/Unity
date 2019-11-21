using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Valve.VR;

public class ControllerMenu : MonoBehaviour
{
    public static ControllerMenu instance = null;

    public GameObject MainMenu;
    public GameObject TejoVideo;
    public GameObject PlayVideoText;
    public GameObject TejoObj;

    public GameObject CanvasVideo;
    public GameObject CanvasInstructions;
    public GameObject CanvasHowtoPlay;
    public GameObject CanvasCredits;
    public GameObject CanvasWinner;

    public GameObject jukebox;

    private VideoPlayer video;
    private bool isPlaying = false;
    private Text playingVideoText;
    private AudioSource audio_juke;



    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        video = TejoVideo.GetComponent<VideoPlayer>();
        playingVideoText = PlayVideoText.GetComponent<Text>();
        audio_juke = jukebox.GetComponent<AudioSource>();       
    }


    public void HideMenu() {
        MainMenu.SetActive(false);

    }

    public void PlayVideo() {

        if (!isPlaying)
        {
            video.Play();
            playingVideoText.text = "Pause";
            isPlaying = true;
        }
        else {
            video.Pause();
            playingVideoText.text = "Continue";
            isPlaying = false;
        }        
    }

    public void StopVideo()
    {
        video.Stop();
        playingVideoText.text = "Play";
        isPlaying = false;
    }

    public void whatsTejo() {
        CanvasVideo.SetActive(true);
        CanvasInstructions.SetActive(false);
        CanvasHowtoPlay.SetActive(false);
        CanvasCredits.SetActive(false);
        CanvasWinner.SetActive(false);
    }
    public void HowToPlay() {
        CanvasVideo.SetActive(false);
        CanvasInstructions.SetActive(false);
        CanvasHowtoPlay.SetActive(true);
        CanvasCredits.SetActive(false);
        CanvasWinner.SetActive(false);
    }
    
    public void Credits() {
        CanvasVideo.SetActive(false);
        CanvasInstructions.SetActive(false);
        CanvasHowtoPlay.SetActive(false);
        CanvasCredits.SetActive(true);
        CanvasWinner.SetActive(false);
    }

    public void NewGame() {
        GameManager.instance.GameStart = true;
        audio_juke.Play();
        MainMenu.SetActive(false);        
        TejoObj.SetActive(true);
        PlayerPosition.instance.SetPlayerTejoPosition();

    }
    // Start is called before the first frame update
    void Start()
    {
        TejoObj.SetActive(false);
        CanvasVideo.SetActive(false);
        CanvasInstructions.SetActive(true);
        CanvasHowtoPlay.SetActive(false);
        CanvasCredits.SetActive(false);
        CanvasWinner.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartMenu() {
        MainMenu.SetActive(true);
        PlayerPosition.instance.SetPlayerMenuPosition(); //MenuPosition.instance.SetMenuPosition();
        TejoObj.SetActive(false);
        CanvasVideo.SetActive(false);
        CanvasInstructions.SetActive(false);
        CanvasHowtoPlay.SetActive(false);
        CanvasCredits.SetActive(false);
        CanvasWinner.SetActive(true);
    }
}
