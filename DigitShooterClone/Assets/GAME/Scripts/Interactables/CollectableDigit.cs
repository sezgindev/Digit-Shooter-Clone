using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectableDigit : MonoBehaviour
{
    private const int _bulletDigitLayer = 8;
    private const int _playerLayer = 6;

    [SerializeField] private int _currentNumber = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _bulletDigitLayer)
        {
            other.gameObject.transform.DOKill();
            Destroy(other.gameObject);
            IncreaseNumber();
        }

        if (other.gameObject.layer == _playerLayer)
        {
            EventManager.OnGetDigitNumber?.Invoke(_currentNumber);
            Destroy(gameObject);
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