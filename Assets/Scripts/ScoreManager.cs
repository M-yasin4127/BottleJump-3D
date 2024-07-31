using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{

    public int Score = 25;
    public TextMeshProUGUI CoinsScore;
    public TextMeshProUGUI ScoreforlevelCom;
    public TextMeshProUGUI ScoreforGameOver;
    public TextMeshProUGUI ScoreforLevelCom1;
    public TextMeshProUGUI AllScores;
    public int AllScore = 0;

    void Start()
    {
        Score = PlayerPrefs.GetInt("Score");
        AllScore = Score;
        AllScores.text = AllScore.ToString();
    }

    public void CoinsCollect()
    {
        Score += 15;
        CoinsScore.text = Score.ToString();
        ScoreforlevelCom.text = Score.ToString();
        ScoreforGameOver.text = Score.ToString();
        //ScoreforLevelCom1.text = Score.ToString();
        ChangeScore();
    }
    public void ChangeScore()
    {
            PlayerPrefs.SetInt("Score",Score);
    }
}
 
  