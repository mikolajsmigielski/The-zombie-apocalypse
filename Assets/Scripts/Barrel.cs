﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Entity))]
public class Barrel : MonoBehaviour
{
    [SerializeField]
    float ExplosionRadius = 4f;

    [SerializeField]
    float ExplosionDamage = 15f;

    void Start()
    {
        GetComponent<Entity>().OnKilled += () => Explose();
    }
    void Explose()
    {
        EntityDoDamage();
        Destroy(gameObject);
    }
    void EntityDoDamage()
    {
        Physics2D.OverlapCircleAll(transform.position, ExplosionRadius)
            .Select(obj => obj.GetComponent<Entity>())
            .Where(obj => obj != null)
            .Where(obj => obj.transform.name != transform.name)
            .ToList()
            .ForEach(obj => obj.Health -= ExplosionDamage);
    }
}
