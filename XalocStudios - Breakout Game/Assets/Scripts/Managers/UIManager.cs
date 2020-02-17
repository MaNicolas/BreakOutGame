using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    #region Main Methods

    private void _playerStatsManager_OnLifeChanged()
    {
        UpdateUI();
    }

    private void _playerStatsManager_OnScoreChanged()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _lifeText.text = "Life: " + _playerStatsManager.CurrentLife.ToString();
        _scoreText.text = "Score: " + _playerStatsManager.Score.ToString();
        _bestScore.text = "High Score: " + _playerStatsManager.LoadBestScore();
    }

    #endregion

    #region System

    private void Awake()
    {
        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        _lifeText = GameObject.Find("Life").GetComponent<TextMeshProUGUI>();
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _bestScore = GameObject.Find("BestScore").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateUI();
        _playerStatsManager.OnLifeChanged += _playerStatsManager_OnLifeChanged;
        _playerStatsManager.OnScoreChanged += _playerStatsManager_OnScoreChanged;
    }

    #endregion

    #region Private Members

    private PlayerStatsManager _playerStatsManager;
    private TextMeshProUGUI _lifeText;
    private TextMeshProUGUI _scoreText;
    private TextMeshProUGUI _bestScore;

    #endregion
}