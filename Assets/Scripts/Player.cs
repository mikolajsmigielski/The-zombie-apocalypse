using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Crosshair crosshair;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float runSpeed = 4f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        crosshair = FindObjectOfType<Crosshair>();
    }
    
    void Start()
    {
        GetComponent<Entity>().OnKilled += () => Application.Quit();
    }

    
    void Update()
    {
        MovmentUpdate();
        RotationUpdate();
    }
    void MovmentUpdate()
    {
        var WalkingDirection = Vector2.zero;

        WalkingDirection += Vector2.up * Input.GetAxis("Vertical");
        WalkingDirection += Vector2.right * Input.GetAxis("Horizontal");
        WalkingDirection = WalkingDirection.normalized;
        WalkingDirection *= Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;


        rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, WalkingDirection, Time.deltaTime * 4f);
    }
    void RotationUpdate()
    {
        var delta = crosshair.transform.position - transform.position;
        var targetRotation = (Vector2)delta;
        transform.right = Vector2.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
    }
}
