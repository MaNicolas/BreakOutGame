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
        _transform = GetComponent<Transform>();
        BallSpeed = _ballSpeed;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_inPlay)
        {
            _inPlay = true;
            _transform.parent = null;

            if (Input.GetAxis("Horizontal") == 0f)    //Checking if the Paddle is standing still
            {
                _direction = Vector3.up;
                _transform.position = new Vector3(_transform.position.x, _transform.position.y + _transform.up.y, 0);
            }
            else if (Input.GetAxis("Horizontal") > 0f)  //Checking if the Paddle is moving right
            {
                _direction = new Vector3(1f, 1f, 0f);
                _transform.position = new Vector3(_transform.position.x, _transform.position.y + _transform.up.y, 0);
            }
            else if (Input.GetAxis("Horizontal") < 0f)  //Checking if the Paddle is moving left
            {
                _direction = new Vector3(-1f, 1f, 0f);
                _transform.position = new Vector3(_transform.position.x, _transform.position.y + _transform.up.y, 0);
            }
        }
    }

    public void FixedUpdate()
    {
        if (_inPlay)
        {
            //dir = (_transform.position - Camera.main.transform.position).normalized;

            _tempPos = _transform.position;
            _tempPos.x += _direction.x * BallSpeed * Time.deltaTime;
            _tempPos.y += _direction.y * BallSpeed * Time.deltaTime;
            _transform.position = _tempPos;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            Debug.Log("Collision!");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Debug.Log("Do Something!!!!!!!!!!");
        }
    }

    #endregion

    #region Debug

    public void OnGUI()
    {
        GUILayout.Button("Ball position: " + _transform.position);
        GUILayout.Button("direction: " + dir);
    }
    #endregion

    #region Private Members

    [SerializeField]
    private float _ballSpeed = 20f;

    [SerializeField]
    private bool _inPlay = false;

    private Transform _transform;
    private Vector3 _tempPos;
    private Vector3 _direction;
    private Vector3 dir;

    #endregion
}