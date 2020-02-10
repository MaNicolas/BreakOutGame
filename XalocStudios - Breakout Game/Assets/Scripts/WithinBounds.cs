using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithinBounds : MonoBehaviour
{
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _spriteSizeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        _spriteSizeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        _screenLimitY = (Camera.main.orthographicSize * Camera.main.aspect) - _spriteSizeY / 2;

        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("TopWall"))
        {
            _transform.position = new Vector2(0, Camera.main.orthographicSize - _spriteSizeY / 2);
            _collider.size = new Vector2(Camera.main.orthographicSize * 2 * Camera.main.aspect, _collider.size.y);
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

    private float _spriteSizeX;
    private float _spriteSizeY;
    private float _screenLimitY;
    private BoxCollider2D _collider;
}