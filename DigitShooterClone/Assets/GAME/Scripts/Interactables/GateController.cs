using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private SkillTypes _skillType;
    [SerializeField] private float _skillAmount = 1;
    [SerializeField] private TextMeshPro _gateText;
    private const int _playerLayer = 6;
    private const int _bulletDigitLayer = 8;
    private Renderer _cubeRenderer;
    private readonly Color _redColor = new Color(0.91f, 0.1f, 0.08f, 0.36f);
    private readonly Color _greenColor = new Color(0f, 0.83f, 0.28f, 0.36f);


    public enum SkillTypes
    {
        FireRate,
        Range
    }

    private void Awake()
    {
        _cubeRenderer = gameObject.GetComponent<Renderer>();
        SetTextAmount();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            EventManager.OnGetSkill?.Invoke(_skillType, _skillAmount);
        }

        if (other.gameObject.layer == _bulletDigitLayer)
        {
            DigitHit(other.gameObject);
            SetTextAmount();
        }
    }

    private void DigitHit(GameObject digit)
    {
        transform.DOKill();
        transform.DOPunchScale(Vector3.one*.004f, .2f);
        _skillAmount += 1;
        digit.layer = 0;
        digit.transform.DOKill();
        Destroy(digit);
    }

    private void SetTextAmount()
    {
        string mathSign = "+";

        if (_skillAmount > 0)
            mathSign = "+";
        else
        {
            mathSign = "";
        }

        _gateText.SetText(mathSign + _skillAmount + "\n" + _skillType);

        if (_skillAmount > 0)
        {
            _cubeRenderer.material.SetColor("_Color", _greenColor);
        }
        else
        {
            _cubeRenderer.material.SetColor("_Color", _redColor);
        }
    }
}