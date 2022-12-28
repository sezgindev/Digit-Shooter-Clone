using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private GameObject _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMovementController>().gameObject;
    }

    private void LateUpdate()
    {
        var pos = _player.transform.position + _offset;
        pos.x = 0;
        transform.position = pos;
    }
}