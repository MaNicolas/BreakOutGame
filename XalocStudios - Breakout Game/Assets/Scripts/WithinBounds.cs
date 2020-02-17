using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinBounds : MonoBehaviour
{
    #region System

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponent<BoxCollider2D>();
        
        _spriteSizeY = GetComponentInChildren<SpriteRenderer>().sprite.bounds.size.y;
    }

    private void Update()
    {
        if (gameObject.CompareTag("TopWall"))
        {
            _transform.position = new Vector2(0, Camera.main.orthographicSize - _spriteSizeY / 2);
            _collider.size = new Vector2(Camera.main.orthographicSize * Camera.main.aspect * 2, _collider.size.y);
        }
        else if (gameObject.CompareTag("LeftWall"))
        {
            _transform.position = new Vector2(-(Camera.main.orthographicSize * Camera.main.aspect) + _spriteSizeY / 2, 0);
            _collider.size = new Vector2(Camera.main.orthographicSize * 2, _collider.size.y);
        }
        else if (gameObject.CompareTag("RightWall"))
        {
            _transform.position = new Vector2((Camera.main.orthographicSize * Camera.main.aspect) - _spriteSizeY / 2, 0);
            _collider.size = new Vector2(Camera.main.orthographicSize * 2, _collider.size.y);
        }
    }

    #endregion

    #region Private Members

    private Transform _transform;
    private float _spriteSizeY;
    private BoxCollider2D _collider;

    #endregion
}