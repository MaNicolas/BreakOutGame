using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBallSpeed : Capsule
{
    #region Methods

    protected override void Effect()
    {
        _ballMovement = FindObjectOfType<BallMovement>();
        _ballMovement.ChangeBallSpeed(_value);
    }

    #endregion

    #region Private Members

    [SerializeField]
    [Range(1f, 20f)]
    private float _value = 10f;

    private BallMovement _ballMovement;

    #endregion
}