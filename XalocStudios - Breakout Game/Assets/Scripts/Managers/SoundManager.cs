using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    #region Main Methods

    public void PlaySound(AudioClip sound)
    {
        _audioSource.PlayOneShot(sound);
    }

    private void SetMusic(AudioClip music)
    {
        _audioSource.clip = music;
        _audioSource.Play();
    }

    #endregion

    #region System

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
            SetMusic(_introMusic);

        if (SceneManager.GetActiveScene().buildIndex == 1)
            SetMusic(_level1Music);

        if (SceneManager.GetActiveScene().buildIndex == 2)
            SetMusic(_level2Music);

        if (SceneManager.GetActiveScene().buildIndex == 3)
            SetMusic(_level3Music);

        if (SceneManager.GetActiveScene().buildIndex == 4)
            SetMusic(_winMusic);

        if (SceneManager.GetActiveScene().buildIndex == 5)
            SetMusic(_gameOvermusic);
    }

    #endregion

    #region Private Members

    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _introMusic = null;
    [SerializeField]
    private AudioClip _level1Music = null;
    [SerializeField]
    private AudioClip _level2Music = null;
    [SerializeField]
    private AudioClip _level3Music = null;
    [SerializeField]
    private AudioClip _winMusic = null;
    [SerializeField]
    private AudioClip _gameOvermusic = null;

    #endregion
}