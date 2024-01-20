using UnityEngine;

public class PlayerMovement
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public PlayerMovement(SpriteRenderer spriteRenderer, Rigidbody2D rigidbody2D, Animator animator)
    {
        _spriteRenderer = spriteRenderer;
        _rigidbody2D = rigidbody2D;
        _animator = animator;
    }

    private void Jump(float jumpForce)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
    }

    public void Move(float inputX, float movementSpeed)
    {
        if (inputX < 0) _spriteRenderer.flipX = true;
        else if(inputX > 0) _spriteRenderer.flipX = false;
        //_rigidbody2D.velocity = new Vector2(inputX * movementSpeed, _rigidbody2D.velocity.y);
        _rigidbody2D.MovePosition(_rigidbody2D.position + new Vector2(inputX, _rigidbody2D.position.y) * movementSpeed * Time.fixedDeltaTime);
        _animator.SetFloat("Speed", Mathf.Abs(inputX));
    }
}
