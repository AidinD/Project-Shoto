﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private Enemy[] enemies;
    private Vector3 screenBounds;

    private void Start()
    {
        screenBounds = GameSceneManager.GetScreenBounds();
        StartCoroutine(Spawn(spawnRate));
    }

    private IEnumerator Spawn(float spawnRate)
    {
        float spawnPosition = Random.Range(-screenBounds.x, screenBounds.x);
        yield return new WaitForSeconds(spawnRate);
        var enemyToSpawn = Random.Range(0, enemies.Length);
        var enemy = PoolManager.Instance.RequestFromPool(enemies[enemyToSpawn].UnitType.UnitName);
        enemy.transform.position = new Vector2(spawnPosition, screenBounds.y);
        enemy.transform.rotation = Quaternion.identity;
        StartCoroutine(Spawn(spawnRate));
    }
}
