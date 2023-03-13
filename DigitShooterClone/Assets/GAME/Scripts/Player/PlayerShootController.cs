using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private float _fireRate = .75f;
    private float _minFireRate = .075f;
    private float _attackRange = 10;

    private void OnEnable()
    {
        EventManager.OnGetSkill += SkillChange;
    }

    private void OnDisable()
    {
        EventManager.OnGetSkill -= SkillChange;
    }

    private void Start()
    {
        StartCoroutine(PlayerShoot());
    }


    private IEnumerator PlayerShoot()
    {
        while (true)
        {
            var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.transform.DORotate(new Vector3(0, 180, 0), 0);
            bullet.transform.DOMoveZ(bullet.transform.position.z + _attackRange, 5.0f).SetEase(Ease.Linear)
                .SetSpeedBased()
                .OnComplete(() => { Destroy(bullet); });
            yield return new WaitForSeconds(_fireRate);
        }
    }

    private void SkillChange(GateController.SkillTypes skillType, float skillAmount)
    {
        if (skillType == GateController.SkillTypes.Range)
            ChangeAttackRange(skillAmount);
        if (skillType == GateController.SkillTypes.FireRate)
            ChangeFireRate(skillAmount);
    }

    private void ChangeAttackRange(float skillAmount)
    {
        _attackRange += skillAmount / 5;
        _attackRange = Mathf.Clamp(_attackRange, 10, int.MaxValue);
    }

    private void ChangeFireRate(float skillAmount)
    {
        _fireRate -= skillAmount / 50;
        _fireRate = Mathf.Clamp(_fireRate, _minFireRate, int.MaxValue);
    }
}