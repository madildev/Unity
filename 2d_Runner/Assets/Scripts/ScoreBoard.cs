using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard
{
    private int scores;
    private int kills;
    private int attempts;
    private static ScoreBoard instance; //instance variable
    private ScoreBoard(){} 

    public static ScoreBoard getInstance()
    {  //return the single instance of the class
        if(instance == null)
        {
            return instance = new ScoreBoard();
        }
        else
        {
            return instance;
        }
    }

    //Setters and Getters of the members
    public void AddScore(int score)
    {
        this.scores += score;
        Debug.Log("Score: " + this.scores);
    }

    public int GetScores()
    {
        return this.scores;
    }

    public void AddAttempt()
    {
        this.attempts ++;
    }

    public int GetAttempts()
    {
        return this.attempts;
    }

    public void AddKill()
    {
        this.kills ++;
    }

    public int GetKills()
    {
        return this.kills;
    }

    public void ResetScoreBoard()
    {
        this.attempts = 0;
        this.scores = 0;
        this.kills = 0;
        Debug.Log("Score : " + this.scores);
    }

    public void DisplayScore()
    {
        Text ScoreBoardUI = GameObject.FindWithTag("Score").GetComponent<Text>();
        ScoreBoardUI.text = "Score: " + this.scores;
    } 
}
