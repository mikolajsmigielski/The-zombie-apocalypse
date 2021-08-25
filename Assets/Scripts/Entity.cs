﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    float InitialHealth = 3f;

    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {

            health = value;

            if (health <= 0)
                health = 0;

            if (OnHealthChange != null)
                OnHealthChange.Invoke(health);

            if (health == 0)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();
                Destroy(gameObject);
            }

        }
    }
    public event Action<float> OnHealthChange;
    public event Action OnKilled;
    void Start()
    {
        Health = InitialHealth;
    }
}
