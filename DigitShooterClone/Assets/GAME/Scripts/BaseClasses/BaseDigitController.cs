using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDigitController : MonoBehaviour
{
    public float _currentNumber = 10;
    public List<GameObject> digits;
    public List<GameObject> _currentDigits;
    private readonly Color _redColor = new Color(0.91f, 0.1f, 0.08f, 0.36f);
    private readonly Color _greenColor = new Color(0f, 0.83f, 0.28f, 0.36f);

    protected void ChangeNumberModel(float newNumber)
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


    protected void DigitRePositioning()
    {
        if (_currentDigits.Count == 1)
        {
            _currentDigits[0].transform.localPosition = new Vector3(0, 0, 0);
        }

        else if (_currentDigits.Count == 2)
        {
            _currentDigits[0].transform.localPosition = new Vector3(-.04f, 0, 0);
            _currentDigits[1].transform.localPosition = new Vector3(.04f, 0, 0);
        }

        if (_currentDigits.Count == 3)
        {
            _currentDigits[0].transform.localPosition = new Vector3(-0.09f, 0, 0);
            _currentDigits[1].transform.localPosition = new Vector3(0f, 0, 0);
            _currentDigits[2].transform.localPosition = new Vector3(0.11f, 0, 0);
        }
    }

    protected void CheckColor()
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