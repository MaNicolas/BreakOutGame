using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSkill : MonoBehaviour
{
    #region Public Members

    public bool m_canShoot;

    #endregion

    #region Main Methods

    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    #endregion

    #region System

    void Update()
    {
        //Shooting logic
        if (m_canShoot)
        {
            _coolDownTimer -= Time.deltaTime;
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (_coolDownTimer <= 0 && _hasFired == false)
                {
                    _hasFired = true;
                    _coolDownTimer = _timeBetweenShots;
                    Instantiate(_bullet, _instantiateLocation.position, Quaternion.identity);
                    _soundManager.PlaySound(_missileSound);
                }
            }
            else _hasFired = false;
        }
    }

    #endregion    

    #region Private Members

    private bool _hasFired;
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _timeBetweenShots;
    private float _coolDownTimer;

    private SoundManager _soundManager;
    [SerializeField]
    private AudioClip _missileSound;
    [SerializeField]
    private Transform _instantiateLocation;

    #endregion
}