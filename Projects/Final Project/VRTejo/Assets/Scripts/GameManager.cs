using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private bool finishRound = false;
    private bool gameStart = false;
    private bool hitMud = false;
    private bool winner = false;
    private float fpsDeltaTime;
    private int fps;

    [HideInInspector] public bool validThrowing = false;
    [HideInInspector] public Player Player1 = new Player();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        validThrowing = false;
    }

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFramePerSeconds();
    }

    public bool FinishRound
    {
        get { return finishRound; }
        set { finishRound = value; }
    }

    public bool GameStart
    {
        get { return gameStart; }
        set { gameStart = value; }
    }

    public bool HitMud
    {
        get { return hitMud; }
        set { hitMud = value; }
    }

    public bool Winner
    {
        get { return winner; }
        set { winner = value; }
    }

    public void AddMechaPlayer() {

        Player1.numMechasperTurn++;
        Debug.Log("Num Mechas: " + Player1.numMechasperTurn.ToString());        
    }

    public void AddEmbocinPlayer()
    {
        Player1.numEmbocinperTurn++;
        Debug.Log("Num Embocin: " + Player1.numMechasperTurn.ToString());
    }

    public void AddNumAttemps()
    {
        Player1.numPlayerAttemps++;            
    }

    public void checkScore() {

        Player1.calScore();
        textManager.instance.setTextPlayer1();


        if (Player1.numTejosThrowed == GlobalVariables.NUMTEJOSGAME)
        {
            Debug.Log("<<<<<<<<<<<<ENTROOO>>>>>>>>>>>>>" + Player1.numTejosThrowed.ToString() + "    " + GlobalVariables.NUMTEJOSGAME.ToString());
            textManager.instance.setTextGameOver();
            this.GameStart = false;
            this.restartGame();
        }
        else {
            if (Player1.score >= GlobalVariables.MAXSCORETOWIN)
            {
                textManager.instance.setTextWinnerPlayer();
                this.winner = true;
                this.GameStart = false;
                this.restartGame();
            }
        }

        if (Player1.numMechasExploted == GlobalVariables.NUMMECHASGAME) {
            SaveObjOrigin.instance.ResetTejos();
            SaveObjOrigin.instance.ResetMechas();
        }
    }


    public void restartGame()
    {
        Player1.resetValues();
        this.validThrowing = false;
        this.winner = false;
        SaveObjOrigin.instance.ResetTejos();
        SaveObjOrigin.instance.ResetMechas();
        ControllerMenu.instance.RestartMenu();
        PlayerPosition.instance.SetPlayerMenuPosition();
        textManager.instance.ResetTextScore();
    }

    public bool isValidThrowing()
    {
        return this.validThrowing;
    }

    public void UpdateFramePerSeconds()
    {
        fpsDeltaTime += (Time.unscaledDeltaTime - fpsDeltaTime) * 0.1f;
        fps = (int)(1.0f / fpsDeltaTime);
        Debug.Log("FPS: " + fps);
    }
}
