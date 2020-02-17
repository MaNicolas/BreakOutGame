using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    #region System

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _tempPos = _transform.position;
        _tempPos.y += _bulletSpeed * Time.deltaTime;
        _transform.position = _tempPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Bricks>().TakeDamage();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Private Members

    private Transform _transform;
    private Vector3 _tempPos;
    [SerializeField]
    private float _bulletSpeed;

    #endregion
}