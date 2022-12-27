using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDigit : MonoBehaviour
{
    private const int _digitLayer = 10;
    [SerializeField] private int _currentNumber = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _digitLayer)
        {
            IncreaseNumber();
        }
    }

    private void IncreaseNumber()
    {
        _currentNumber += 1;
        ChangeNumberModel(_currentNumber);
    }

    private void ChangeNumberModel(int newNumber)
    {
        //do something
    }
}