using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CollectableDigit : MonoBehaviour
{
    private const int _bulletDigitLayer = 8;
    private const int _playerLayer = 6;
    [SerializeField] private float _currentNumber = 10;
    [SerializeField] private List<GameObject> digits;
    [SerializeField] private List<GameObject> _currentDigits;
    private readonly Color _redColor = new Color(0.91f, 0.1f, 0.08f, 0.36f);
    private readonly Color _greenColor = new Color(0f, 0.83f, 0.28f, 0.36f);


    private void Awake()
    {
        CheckColor();
    }

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

    private void ChangeNumberModel(float newNumber)
    {
        foreach (var digit in _currentDigits)
        {
            Destroy(digit);
        }

        int digitCount = newNumber.ToString().Length;
        List<GameObject> spawnableDigits = new List<GameObject>();
        _currentDigits = new List<GameObject>();
        for (int i = 0; i < digitCount; i++)
        {
            int a = (int)newNumber.ToString()[i] - '0';
            spawnableDigits.Add(digits[a]);
            var digit = Instantiate(spawnableDigits[i], spawnableDigits[i].transform.position,
                Quaternion.Euler(0, 180, 0),
                transform);
            _currentDigits.Add(digit);
        }

        DigitRePositioning();
        CheckColor();
    }

    private void DigitRePositioning()
    {
        //+0.2
        var xOffset = 0.0f;
        for (int i = 0; i < _currentDigits.Count; i++)
        {
            var newPos = _currentDigits[i].transform.position;
            newPos.x += xOffset;
            _currentDigits[i].transform.position = newPos;
            xOffset += 0.2f;
        }
    }

    private void CheckColor()
    {
        if (_currentNumber > 0)
        {
            foreach (var digit in _currentDigits)
            {
                Renderer digitRenderer = digit.GetComponent<Renderer>();
                digitRenderer.material.SetColor("_Color", _greenColor);
            }
        }
        else
        {
            foreach (var digit in _currentDigits)
            {
                Renderer digitRenderer = digit.GetComponent<Renderer>();
                digitRenderer.material.SetColor("_Color", _redColor);
            }
        }
    }
}