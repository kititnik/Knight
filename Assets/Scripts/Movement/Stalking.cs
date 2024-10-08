using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Stalking : MonoBehaviour
{
    [SerializeField] protected Transform stalkingTarget;
    [SerializeField] protected float speed;
    [SerializeField] protected float allowedDistance;
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;
    protected bool _facingRight;

    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Flip()
    {
        _facingRight = !_facingRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        var colliders = GetComponents<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.offset = new Vector2(collider.offset.x*-1, collider.offset.y);
        }
    }

    protected virtual void Move()
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