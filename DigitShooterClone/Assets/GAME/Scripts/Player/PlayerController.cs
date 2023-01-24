using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseDigitController
{
    private float _currentDigit = 1;


    private void OnEnable()
    {
        EventManager.OnGetDigitNumber += DigitIncrease;
    }

    private void OnDisable()
    {
        EventManager.OnGetDigitNumber -= DigitIncrease;
    }


    private void Awake()
    {
        ChangeNumberModel(_currentDigit);
    }

    private void DigitIncrease(float increaseAmount)
    {
        _currentNumber += increaseAmount;
        ChangeNumberModel(_currentNumber);
    }
}