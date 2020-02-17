using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : Capsule
{
    #region System

    protected override void Effect()
    {
        _player = FindObjectOfType<PaddleMouvement>();
        _player.ChangePlayerSpeed(-_value);
    }

    #endregion

    #region Private Members

    private PaddleMouvement _player;
    [SerializeField]
    [Range(1, 50)]
    private float _value = 20f;

    #endregion
}