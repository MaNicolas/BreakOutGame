using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    #region Main Methods

    protected void Falling()
    {
        _tempPos = _transform.position;
        _tempPos.y -= _speedCapsule * Time.deltaTime;
        _transform.position = _tempPos;
    }

    //Virtual method for every single capsule to overwrite
    protected virtual void Effect()
    {

    }

    #endregion

    #region System

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        Falling();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Effect();
            _soundManager.PlaySound(_CapsuleSound);
            Destroy(gameObject);
        }
    }

    #endregion

    #region Private Members

    protected Transform _transform;
    [SerializeField]
    [Range(1f,10f)]
    protected float _speedCapsule;

    protected Vector3 _tempPos;

    protected SoundManager _soundManager;
    [SerializeField]
    protected AudioClip _CapsuleSound;

    #endregion
}