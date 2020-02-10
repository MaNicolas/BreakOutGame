using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Public Members
    
    public float Speed { get; private set; }

    #endregion

    #region Methods

    public void Move()
    {
        _transform.position = new Vector2(_transform.position.x + Input.GetAxis("Horizontal") * Speed * Time.deltaTime, _transform.position.y);
    }

    private void WithinBounds()
    {
        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - _spriteSizeX / 2;
        if (_transform.position.x > screenLimit)
        {
            _transform.position = new Vector3(screenLimit, _transform.position.y, _transform.position.z);
        }
        else if (transform.position.x < -screenLimit)
        {
            _transform.position = new Vector3(-screenLimit, _transform.position.y, _transform.position.z);
        }
    }

    #endregion

    #region System

    void Start()
    {
        Speed = _speed;
        _transform = GetComponent<Transform>();
        _spriteSizeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    void Update()
    {
        //Move
        if (Input.GetAxis("Horizontal") != 0)
            Move();
        else
            _transform.position = new Vector2(_transform.position.x, _transform.position.y);

        //Keeps player within bounds
        float screenLimit = (Camera.main.orthographicSize * Camera.main.aspect) - _spriteSizeX / 2;
        WithinBounds();
    }

    #endregion

    #region Private Members

    [SerializeField]
    private float _speed;

    private Transform _transform;
    private float _spriteSizeX;

    #endregion
}