using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public int score = 0;
    public Text Score_text;
    public Text Fps_text;
    private float fpsDeltaTime;
    private int fps;



    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateFramePerSeconds();
    }


    public void IncrementScore(int value)
    {
        score += value;
        Score_text.text = score.ToString();
    }

    public int getScore() {
        return score;
    }

    public void UpdateFramePerSeconds()
    {
        fpsDeltaTime += (Time.unscaledDeltaTime - fpsDeltaTime) * 0.1f;
        fps = (int)(1.0f / fpsDeltaTime);
        Fps_text.text = "FPS: " + fps;
    }
}
