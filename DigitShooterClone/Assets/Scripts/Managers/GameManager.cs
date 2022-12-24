using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameStates GameState;

    public enum GameStates
    {
        Idle,
        Run,
        Wait,
        Dead,
    }

    private void Start()
    {
        GameState = GameStates.Idle;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameState = GameStates.Run;
        }
    }
}