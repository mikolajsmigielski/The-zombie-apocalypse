using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{
    public bool Active { get; private set; }
    void Start()
    {
        
    }

    
    void Update()
    {
        GetComponent<Renderer>().material.color = Active ? Color.red : Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Active = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Active = false;
    }
}
