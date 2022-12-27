using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Mathf.Lerp(_moveFactorX, Input.mousePosition.x - _lastFrameFingerPositionX,
                Time.deltaTime * 10);
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }

        if (!Input.GetMouseButton(0))
        {
            _moveFactorX = Mathf.Lerp(_moveFactorX, 0, Time.deltaTime * 10);
        }
    }
}