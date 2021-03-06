﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusEnemy : Enemy
{
    private float frequency = 0f;
    private float offset = 0f;
    private float amplitude = 0f;

    protected void Start()
    {
        frequency = Random.Range(0.2f, 1f);
        offset = Random.Range(-3f, 3f);
        amplitude = Random.Range(-2f, 2f);
    }

    protected override void Move()
    {
        var translationVector = new Vector2(amplitude * Mathf.Sin(offset + frequency * Mathf.PI * Time.time), -1);
        transform.Translate(translationVector * unit.MovementSpeed * Time.deltaTime);
    }
}
