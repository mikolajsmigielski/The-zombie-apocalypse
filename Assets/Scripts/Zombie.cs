using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Zombie : MonoBehaviour
{
    Rigidbody2D Rigidbody;
    Vector2 TargetPosition;

    [SerializeField]
    float Speed = 2f;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeTargetPositionCoroutine());
    }
    IEnumerator ChangeTargetPositionCoroutine()
    {
        while (true)
        {
            TargetPosition = (Vector2)transform.position + Random.insideUnitCircle * 10f;

            yield return new WaitForSeconds(Random.Range(5, 10));
        }
    }
    void Update()
    {
        var direction = (Vector3)TargetPosition - transform.position;
        var targetVelocity = direction.normalized * Speed / 2f;


        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, targetVelocity, Time.deltaTime / 2f);

            transform.right = direction;
    }
}
