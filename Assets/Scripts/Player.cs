using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var WalkingDirection = Vector2.zero;

        WalkingDirection += Vector2.up * Input.GetAxis("Vertical");
        WalkingDirection += Vector2.right * Input.GetAxis("Horizontal");
        WalkingDirection = WalkingDirection.normalized * speed;

        var rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = WalkingDirection;

        transform.right = WalkingDirection;
    }
}
