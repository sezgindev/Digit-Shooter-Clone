using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float _speed = 2.0f;

    void Update()
    {
        if (GameManager.GameState == GameManager.GameStates.Run)
        {
            transform.Translate(0, 0, (_speed * Time.deltaTime), Space.Self);
        }
    }
}