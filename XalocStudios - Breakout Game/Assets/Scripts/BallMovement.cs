using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    #region Public Members

    public float BallSpeed { get; private set; }

    #endregion

    #region Methods

    public void IncreaseBallSpeed(float value)
    {
        _ballSpeed += value;
        BallSpeed = _ballSpeed;
    }

    public void DecreaseBallSpeed(float value)
    {
        _ballSpeed -= value;
        BallSpeed = _ballSpeed;
    }

    #endregion

    #region System Methods

    public void Awake()
    {
        BallSpeed = _ballSpeed;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_inPlay)
        {
            _inPlay = true;
            _transform.parent = null;

            if (Input.GetAxis("Horizontal") == 0f)                                         //Checking if the Paddle is standing still
            {
                
            }
            else if (Input.GetAxis("Horizontal") > 0f)                                     //Checking if the Paddle is moving right
            {
                
            }
            else if (Input.GetAxis("Horizontal") < 0f)                                     //Checking if the Paddle is moving left
            {
                
            }
        }
    }

    public void FixedUpdate()
    {
        if (_inPlay)
        {
            
        }
    }

    #endregion

    #region Private Members

    [SerializeField]
    private float _ballSpeed = 20f;
    private bool _inPlay = false;
    private Transform _transform;

    #endregion
}