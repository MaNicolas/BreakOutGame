using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePlayer : Capsule
{
    #region Methods

    protected override void Effect()
    {
        _player = FindObjectOfType<PaddleMouvement>().transform;
        _ballScale = FindObjectOfType<BallMovement>().transform;

        Vector3 playerScale = _player.localScale;
        playerScale.x += _value;
        _player.transform.localScale = playerScale;
    }

    #endregion

    #region Private Members

    private Transform _player;
    private Transform _ballScale;

    [SerializeField]
    [Range(0.1f, 1f)]
    private float _value = .5f;

    #endregion
}