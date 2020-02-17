using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatsManager : MonoBehaviour
{
    #region Public Members

    public int CurrentLife { get; private set; }
    public int Score { get; private set; }
    public int BestScore { get; private set; }

    #endregion

    #region Delegates

    //Life Event
    public delegate void LifeChangedDelegate();
    public event LifeChangedDelegate OnLifeChanged;

    public void ChangeLife()
    {
        if (CurrentLife > 0)
        {
            --CurrentLife;
            Save();
            OnLifeChanged?.Invoke();
        }
    }

    //Score Event
    public delegate void ScoreChangedDelegate();
    public event ScoreChangedDelegate OnScoreChanged;

    public void ChangeScore(int value)
    {
        if (value < 0)
            value = _pointsToLose;
        Score += value;

        if (Score <= 0)
            Score = 0;
        Save();
        OnScoreChanged?.Invoke();
    }

    #endregion

    #region Main Methods

    //Save Life and Score between scenes
    public void Save()
    {
        if (CurrentLife != 0)
        {
            PlayerPrefs.SetInt("CurrentLife", CurrentLife);
            PlayerPrefs.SetInt("Score", Score);
        }
        if (Score > BestScore)
            PlayerPrefs.SetInt("BestScore", Score);
    }

    public int LoadBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }

    #endregion

    #region System

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            CurrentLife = _maxLife;
            Score = 0;
        }
        else
        {
            CurrentLife = PlayerPrefs.GetInt("CurrentLife");
            Score = PlayerPrefs.GetInt("Score");
            //CurrentLife = _maxLife;  //(For tests purposes. Please comment the 2 lines aboves and uncomment this one if you want to play level 2 or 3 directly)
        }
        BestScore = PlayerPrefs.GetInt("BestScore");
    }

    #endregion

    #region Private Members

    [SerializeField]
    [Tooltip("How many life player has")]
    private int _maxLife = 3;
    [SerializeField]
    [Range(-100, 1)]
    [Tooltip("How many points player loses each time the ball is lost")]
    private int _pointsToLose = -20;

    #endregion
}