using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    private float fireRate = .75f;


    private void Start()
    {
        StartCoroutine(PlayerShoot());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fireRate -= .2f;
        }
    }

    private IEnumerator PlayerShoot()
    {
        while (true)
        {
            var bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.transform.DOMoveZ(bullet.transform.position.z + 10.0f, 5.0f).SetEase(Ease.Linear).SetSpeedBased()
                .OnComplete(() => { Destroy(bullet); });
            yield return new WaitForSeconds(fireRate);
        }
    }
}