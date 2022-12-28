using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _currentDigit = 1;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Awake()
    {
        ChangeNumberModel();
    }

    private void ChangeNumberModel()
    {
        //do something
    }

    private void ChangeCurrentDigit(float numberAmount)
    {
        _currentDigit += numberAmount;
        ChangeNumberModel();
    }
}