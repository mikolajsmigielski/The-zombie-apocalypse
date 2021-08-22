using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float runSpeed = 4f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
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

        
        rigidbody.velocity = WalkingDirection;
    }
    void RotationUpdate()
    {
        var targetRotation = rigidbody.velocity;
        transform.right = Vector2.Lerp(transform.right, targetRotation, Time.deltaTime * 10f);
    }
}
