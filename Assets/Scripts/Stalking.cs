using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Stalking : MonoBehaviour
{
    [SerializeField] private Transform stalkingTarget;
    [SerializeField] private float speed;
    [SerializeField] private float allowedDistance;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (stalkingTarget == null) return;
        float distance = transform.position.x - stalkingTarget.position.x;
        if(Math.Abs(distance) <= allowedDistance) return;
        Vector2 direction;
        if(distance < 0) direction = Vector2.right;
        else direction = Vector2.left;
        _rigidbody2D.MovePosition((Vector2)transform.position + direction * (speed * Time.fixedDeltaTime));
    }
}