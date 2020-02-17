using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region Public Members

    public int NumberOfBricks { get; private set; }

    #endregion

    #region Main Methods

    public void DecreaseNumberBricks()
    {
        NumberOfBricks--;
    }

    #endregion

    #region System

    private void Awake()
    {
        _bricksArray = GameObject.FindGameObjectsWithTag("Brick");
        NumberOfBricks = _bricksArray.Length;
        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
    }

    private void Update()
    {
        if (NumberOfBricks == 0)
        {
            _playerStatsManager.Save();
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex + 1);
        }

        if (_playerStatsManager.CurrentLife == 0)
        {
            _playerStatsManager.Save();
            SceneManager.LoadScene("GameOver");
        }

        if(Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #endregion

    #region Private Members

    private GameObject[] _bricksArray;
    private PlayerStatsManager _playerStatsManager;

    #endregion
}