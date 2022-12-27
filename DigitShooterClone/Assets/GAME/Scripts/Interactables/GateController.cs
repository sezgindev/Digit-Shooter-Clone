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
    private readonly Color _redColor = new Color(231, 25, 21, 92);
    private readonly Color _greenColor = new Color(0, 212, 71, 92);

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
            _skillAmount += 1;
            other.gameObject.transform.DOKill();
            Destroy(other.gameObject);
            SetTextAmount();
        }
    }

    private void SetTextAmount()
    {
        _gateText.SetText("+" + _skillAmount + "\n" + _skillType);

        if (_skillAmount > 0)
        {
            //  _cubeRenderer.material.SetColor("_Color", _greenColor);
        }
        else
        {
            //  _cubeRenderer.material.SetColor("_Color", _redColor);
        }
    }
}