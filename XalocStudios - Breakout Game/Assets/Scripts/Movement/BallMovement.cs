using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    #region Public Members

    public float BallSpeed { get; private set; }
    public bool InPlay { get; private set; }

    #endregion

    #region Methods

    public void ChangeBallSpeed(float value)
    {
        BallSpeed += value;
    }

    //Reset ball's position and speed + child it to the paddle when player loses a life
    public void RootBall()
    {
        if(_playerStatsManager.CurrentLife > 0)
        {
            InPlay = false;

            _transform.position = _initialBallPosition;
            _transformPaddle.position = _initialPaddlePosition;
            _transform.SetParent(_transformPaddle);
        }
    }

    private void _playerStatsManager_OnLifeChanged()
    {
        BallSpeed = _ballSpeed;
        RootBall();
    }

    #endregion

    #region System Methods

    public void Awake()
    {
        _transform = GetComponent<Transform>();
        _transformPaddle = FindObjectOfType<PaddleMouvement>().transform;

        BallSpeed = _ballSpeed;

        _initialBallPosition = _transform.position;
        _initialPaddlePosition = _transformPaddle.position;
        _initialBallLocalPosition = _transform.localPosition;

        _playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        _soundManager = FindObjectOfType<SoundManager>();

        _playerStatsManager.OnLifeChanged += _playerStatsManager_OnLifeChanged;
    }

    public void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !InPlay)
        {
            InPlay = true;
            _transform.parent = null;
            _horizontal = Input.GetAxis("Horizontal");

            //Paddle standing still
            if (_horizontal == 0f)
                _direction = Vector3.up;

            //Paddle moving right
            else if (_horizontal > 0f)
                _direction = new Vector3(_horizontal, 1f, 0f);

            //Paddle moving left
            else if (_horizontal < 0f)
                _direction = new Vector3(_horizontal, 1f, 0f);
        }
    }

    public void FixedUpdate()
    {
        if (InPlay)
        {
            _tempPos = _transform.position;
            _tempPos += _direction * BallSpeed * Time.deltaTime;
            _transform.position = _tempPos;
        }
        else _transform.localPosition = _initialBallLocalPosition;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            _soundManager.PlaySound(_ballSound);

            _impactNormal = collision.contacts[0].normal;
            _calculatedDir = Vector2.Reflect(_direction, _impactNormal);
            _direction = _calculatedDir;            
        }
    }

    #endregion

    #region Private Members

    [SerializeField]
    [Range(1,50)]
    private float _ballSpeed = 20f;
    private float _horizontal = 0;

    private Transform _transform;
    private Transform _transformPaddle;

    private Vector3 _tempPos;
    private Vector3 _direction;
    private Vector3 _initialBallPosition;
    private Vector3 _initialPaddlePosition;
    private Vector3 _initialBallLocalPosition;
    private Vector3 _calculatedDir = Vector3.zero;
    private Vector3 _impactNormal = Vector3.zero;

    private PlayerStatsManager _playerStatsManager;
    private SoundManager _soundManager;

    [SerializeField]
    private AudioClip _ballSound = null;

    #endregion
}