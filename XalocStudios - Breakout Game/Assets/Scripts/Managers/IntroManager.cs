using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    #region Main Methods

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    #endregion

    #region Private Members

    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _quitButton;

    #endregion
}