﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponController))]
public class PlayerController : MonoBehaviour, IMovable {

    [SerializeField] private float movementSpeed = 5f;

    private Vector3 screenBounds;
    private WeaponController weaponController;

    private void Awake() {
        weaponController = GetComponent<WeaponController>();
    }

    private void Start() {
        screenBounds = GameSceneManager.GetScreenBounds();
    }

    private void Update() {
        MovePlayer();

        if (Input.GetButton("Jump") || Input.GetButton("Fire1")) {
            weaponController.Shoot();
        }
    }

    private void MovePlayer() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical) * movementSpeed * Time.deltaTime;
        Teleport();
    }

    public void Teleport() {
        if (Mathf.Abs(transform.position.x) > screenBounds.x) {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }

        if (Mathf.Abs(transform.position.y) > screenBounds.y) {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
}
