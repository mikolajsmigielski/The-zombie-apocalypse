﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{
    [SerializeField]
    bool AutoInteract = false;
    public bool Active { get; private set; }

    public event Action OnActivated;
    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateColor();
        UpdateInteraction();
    }
    void UpdateColor()
    {
        Color targetColor = Color.white;
        if (Active)
            targetColor *= (Mathf.Sin(Time.timeSinceLevelLoad * 5f) + 9f) / 10f;
        GetComponent<Renderer>().material.color = targetColor;
    }
    void UpdateInteraction()
    {
        if (!Active)
            return;
        if (Input.GetKeyDown(KeyCode.Space) || AutoInteract)
            if (OnActivated != null)
                OnActivated.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckIfPlayer(collision);
        Active = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CheckIfPlayer(collision);
        Active = false;
    }
    bool CheckIfPlayer(Collider2D collider)
    {
        return (collider.gameObject.GetComponent<Player>() != null);
    }
}
