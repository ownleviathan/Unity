using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int numMechasperTurn;
    public int numEmbocinperTurn;
    public int numManosperTurn;
    public int numMononaperTurn;
    public int numPlayerAttemps;
    public int numTejosThrowed;
    public int numMechasExploted;
    public int score;

    public Player() {
        numMechasperTurn = 0;
        numEmbocinperTurn = 0;
        numManosperTurn = 0;
        numMononaperTurn = 0;
        numTejosThrowed = 0;
        numMechasExploted = 0;
        score = 0;
    }

    public void setScore(int score) {
        this.score = score;
    }

    public void addMecha() {
        this.numMechasperTurn++;
    }

    public void addEmbocin() {
        this.numEmbocinperTurn++;
    }

    public void addMonona() {
        this.numMononaperTurn++;
    }

    public void addMano() {
        this.numManosperTurn++;
    }

    public void calScore() {
        Debug.Log("Scores");
        Debug.Log("MANOS: " + this.numManosperTurn.ToString());
        Debug.Log("MECHAS: " + this.numMechasperTurn.ToString());
        Debug.Log("EMBOCIN: " + this.numEmbocinperTurn.ToString());
        Debug.Log("MONONA: " + this.numEmbocinperTurn.ToString());
        Debug.Log("LANZADOS: " + this.numTejosThrowed.ToString());
        Debug.Log("ESTALLADAS: " + this.numMechasExploted.ToString());

        if (this.numMechasperTurn > 0 && this.numMononaperTurn > 0) {
            this.numMononaperTurn++;
            this.score += this.numMononaperTurn * GlobalVariables.MONONAPOINTS;
        }            
        else {
            if (this.numMechasperTurn > 0) {
                this.score += this.numMechasperTurn * GlobalVariables.MECHAPOINTS;
            }
            if (this.numEmbocinperTurn > 0) {
                this.score += this.numEmbocinperTurn * GlobalVariables.EMBOCINADAPOINTS;
            }
            if (this.numManosperTurn > 0 && this.numMechasperTurn == 0 && this.numEmbocinperTurn == 0) {
                this.score += this.numManosperTurn * GlobalVariables.MANOPOINTS;
            }
        }        
    }

    public void resetValues() {
        this.numMechasperTurn = 0;
        this.numEmbocinperTurn = 0;
        this.numManosperTurn = 0;
        this.numMononaperTurn = 0;
        this.numTejosThrowed = 0;
        this.numMechasExploted = 0;
        this.score = 0;
    }
}
