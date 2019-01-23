using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int starsCollected = 0;
    public Text stars_Text;
    public Text Fps_text;
    public ObjectsbyLevel levelInfo;
    public SteamVR_LoadLevel loadLevel;

    private bool isAValidThrow = false;
    private float fpsDeltaTime;
    private int fps;
    private bool winLevel;
    private bool goNextLevel;
    private bool lastLevel;


    private void Awake()
    {
        this.winLevel = false;
        this.goNextLevel = false;
        stars_Text.text = "COLLECTED STARS: " + starsCollected.ToString() + "/" + levelInfo.stars.Count.ToString();
        if (levelInfo.Levelnumber == 3) {
            this.lastLevel = true;
        }
        else {
            this.lastLevel = false;
        }
    }

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        UpdateFramePerSeconds();
        if (!isLastLevel() && GetGoNextLevel())
        {
            loadLevel.Trigger();
        }        
    }

    public void collectStar() {
        starsCollected++;
        stars_Text.text = "COLLECTED STARS: " + starsCollected.ToString() +  "/" + levelInfo.stars.Count.ToString();
    }

    public void ResetStars()
    {
        starsCollected = 0;
        levelInfo.ResetStars();
    }

    public void SetValidThrow(bool value) {
        this.isAValidThrow = value;
    }


    public bool isValidThrow() {
        return this.isAValidThrow;
    }

    public void SetWinLevel(bool value) {
        this.winLevel = value;
    }

    public bool isWinLevel() {
        return this.winLevel;
    }

    public void SetGoNextLevel(bool value) {
        this.goNextLevel = value;
    }

    public bool GetGoNextLevel() {
        return this.goNextLevel;
    }

    public void SetLastLevel(bool value) {
        this.lastLevel = true;
    }

    public bool isLastLevel() {
        return this.lastLevel;
    }

    public void UpdateFramePerSeconds()
    {
        fpsDeltaTime += (Time.unscaledDeltaTime - fpsDeltaTime) * 0.1f;
        fps = (int)(1.0f / fpsDeltaTime);
        Fps_text.text = "FPS: " + fps;
    }
    public bool validatePickAllStars() {
        if (starsCollected == levelInfo.stars.Count)
            return true;
        else
            return false;
    }

}
