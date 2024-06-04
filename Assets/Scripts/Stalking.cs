using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Stalking : MonoBehaviour
{
    [SerializeField] private Transform stalkingTarget;
    [SerializeField] private float speed;
    [SerializeField] private float allowedDistance;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _facingRight;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        var colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.offset = new Vector2(collider.offset.x*-1, collider.offset.y);
        }
    }

    private void Move()
    {
        if (stalkingTarget == null) return;
        float distance = transform.position.x - stalkingTarget.position.x;
        if(Math.Abs(distance) <= allowedDistance) return;
        Vector2 direction;
        if(distance < 0) direction = Vector2.right;
        else direction = Vector2.left;
        if (distance > 0 && !_facingRight) Flip();
        else if(distance < 0 && _facingRight) Flip();
        _rigidbody2D.MovePosition((Vector2)transform.position + direction * (speed * Time.fixedDeltaTime));
    }
}