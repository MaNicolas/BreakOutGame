using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    #region System

    void Awake()
    {
        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Trigger the events in "PlayerStatsManager"
        if (collision.CompareTag("Ball"))
        {
            _playerStatsManager.ChangeLife();       
            _playerStatsManager.ChangeScore(-1);
            _soundManager.PlaySound(_dieSound);
        }

        //Destroy Capsules if not used
        if (collision.CompareTag("Capsule"))
            Destroy(collision.gameObject);
    }

    #endregion

    #region Private Members

    private PlayerStatsManager _playerStatsManager;
    private SoundManager _soundManager;
    [SerializeField]
    private AudioClip _dieSound = null;

    #endregion
}