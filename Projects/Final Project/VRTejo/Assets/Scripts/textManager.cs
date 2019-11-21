using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{
    public static textManager instance = null;

    public Text player1Text,DebugTxT,menuWinnerText;
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
        player1Text.text = GameManager.instance.Player1.score.ToString() + "/" + GlobalVariables.MAXSCORETOWIN.ToString();
    }

    public void setTextPlayer1() {
        player1Text.text = GameManager.instance.Player1.score.ToString() + "/" + GlobalVariables.MAXSCORETOWIN.ToString();
    }

    public void setTextWinnerPlayer() {
        player1Text.text = "WIN " + GameManager.instance.Player1.score.ToString() + "/" + GlobalVariables.MAXSCORETOWIN.ToString();
        menuWinnerText.text = "WINNER";
    }

    public void setTextGameOver()
    {
        player1Text.text = "GAME OVER";
        menuWinnerText.text = "GAME OVER";

    }


    public void DebugText(string txt)
    {
        DebugTxT.text = txt;
    }

    public void ResetTextScore() {
        player1Text.text = GameManager.instance.Player1.score.ToString() + "/" + GlobalVariables.MAXSCORETOWIN.ToString();
    }
}
