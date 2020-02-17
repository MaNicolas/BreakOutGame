using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSkillCapsule : Capsule
{
    #region Methods

    protected override void Effect()
    {
        _player = FindObjectOfType<ShootingSkill>();
        _player.m_canShoot = true;
    }

    #endregion

    #region Private Members

    private ShootingSkill _player;

    #endregion
}