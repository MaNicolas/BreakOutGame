using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMouvement : MonoBehaviour
{
    #region Public Members
    
    public float PaddleSpeed { get; private set; }

    #endregion

    #region Methods

    public void ChangePlayerSpeed(float value)
    {
        PaddleSpeed -= value;
        if (PaddleSpeed < 10f )
            PaddleSpeed = 10f;
    }

    private void Move()
    {
        _tempPos = _transform.position;
        _tempPos.x += Input.GetAxis("Horizontal") * PaddleSpeed * Time.deltaTime;
        _transform.position = _tempPos;
        FreezeYPosition();
    }

    private void FreezeYPosition()
    {
        _transform.position = new Vector3(_transform.position.x, _originalPosition.y, _transform.position.z);
    }

    private void WithinBounds()
    {
        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - _spriteSizeX;
        _transform.rotation = Quaternion.identity;

        if (_transform.position.x > screenLimit)
        {
            _transform.position = new Vector3(screenLimit, _transform.position.y, _transform.position.z);
        }
        else if (transform.position.x < -screenLimit)
        {
            _transform.position = new Vector3(-screenLimit, _transform.position.y, _transform.position.z);
        }
    }

    private void _playerStatsManager_OnLifeChanged()
    {
        PaddleSpeed = _speed;
        _transform.localScale = _originalScale;
        GetComponent<ShootingSkill>().m_canShoot = false;
    }

    #endregion

    #region System

    void Awake()
    {
        PaddleSpeed = _speed;
        _transform = GetComponent<Transform>();
        _originalPosition = _transform.position;
        _spriteSizeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        _originalScale = _transform.localScale;
        _playerStatsManager.OnLifeChanged += _playerStatsManager_OnLifeChanged;
    }

    void Update()
    {
        //Move
        if (Input.GetAxis("Horizontal") != 0)
            Move();
        else
            _transform.position = new Vector2(_transform.position.x, _transform.position.y);

        //Keeps player within bounds
        WithinBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Avoid Paddle to be pushed by the ball on collision
        if (collision.gameObject.CompareTag("Ball"))
            FreezeYPosition();
    }

    #endregion

    #region Private Members

    [SerializeField][Range(10,100)]
    private float _speed = 50f;

    private Transform _transform;
    private float _spriteSizeX;
    private Vector3 _tempPos;
    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    private PlayerStatsManager _playerStatsManager;

    #endregion
}