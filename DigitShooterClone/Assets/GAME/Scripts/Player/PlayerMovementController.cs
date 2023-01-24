using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float _speed = 1.0f;
    private SwerveInputSystem _swerveInputSystem;
    private float _maxSwerveAmount = .5f;

    private void Awake()
    {
        _swerveInputSystem = FindObjectOfType<SwerveInputSystem>();
    }

    void Update()
    {
        if (GameManager.GameState == GameManager.GameStates.Run)
        {
            float swerveAmount = Time.deltaTime * 1.0f * _swerveInputSystem.MoveFactorX;
            transform.Translate(swerveAmount, 0, (_speed * Time.deltaTime), Space.World);

            Vector3 transformPosition = transform.position;
            transformPosition.x = Mathf.Clamp(transformPosition.x, -_maxSwerveAmount,
                _maxSwerveAmount);
            transform.position = transformPosition;
        }
    }
}