using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    #region Main Methods

    public void TakeDamage()
    {
        _hitPoint--;
        if (_hitPoint > 0)
            GetComponent<SpriteRenderer>().sprite = _spriteDamaged;     //Change brick's aspect when damaged

        if (_hitPoint <= 0)
        {
            _playerStatsManager.ChangeScore(50 * _multiplyScore);       //Triggers Score event in "PlayerStatsManager"
            _levelManager.DecreaseNumberBricks();
            _capsuleManager.CreateCapsule(_transform.position);
            Destroy(gameObject);
        }
    }

    #endregion

    #region System

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _capsuleManager = FindObjectOfType<CapsuleManager>();
        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        _levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }
    }

    #endregion

    #region Private Members

    [SerializeField]
    private int _hitPoint;
    [SerializeField]
    private int _multiplyScore = 1;

    [SerializeField]
    private Sprite _spriteDamaged = null;

    private Transform _transform;
    private CapsuleManager _capsuleManager;
    private PlayerStatsManager _playerStatsManager;
    private LevelManager _levelManager;

    #endregion
}