﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    GameObject BulletPrefab;
    [SerializeField]
    float BulletSpeed = 5f;
    [SerializeField]
    Vector2 ShootPoint;

    private int bullets;
    public int Bullets
    {
        get
        {
            return bullets;
        }
        private set
        {
            bullets = value;
            if (OnBulletsChanged != null)
                OnBulletsChanged.Invoke(bullets);
        }
    }

    public event Action<int> OnBulletsChanged;

    
    void Start()
    {
        Bullets = 5;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootBullet();
    }
    void ShootBullet()
    {
        if (Bullets == 0) return;
        Bullets--;
        var bullet = Instantiate(BulletPrefab);
        bullet.transform.position = transform.position + transform.rotation * (Vector3)ShootPoint;
        bullet.transform.rotation = transform.rotation;

        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * BulletSpeed;
    }
}
