using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelDirector1 : Singleton<LevelDirector>
{
    public Action gameStartAction;
    public Action gameOverAction;

    protected override void Awake()
    {

    }

    private void Start()
    {
        if (gameStartAction != null)
        {
            gameStartAction();
        }
        if (UIManager.Instance != null)
        {
            UIManager.Instance.FadeOn(false, 1f);
        }
    }

    private void Update()
    {

    }
}

