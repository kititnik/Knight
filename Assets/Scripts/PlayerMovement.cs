using ConfigurationScripts;
using UnityEngine;

public class PlayerMovement
{
    private readonly SpriteRenderer _spriteRenderer;
    private readonly Rigidbody2D _rigidbody2D;
    private readonly Animator _animator;
    private float _playerMovementSpeed;

    public PlayerMovement(PlayerConfiguration playerConfiguration, SpriteRenderer spriteRenderer, Rigidbody2D rigidbody2D, Animator animator)
    {
        _spriteRenderer = spriteRenderer;
        _rigidbody2D = rigidbody2D;
        _animator = animator;
        _playerMovementSpeed = playerConfiguration.playerMovementSpeed;
    }

    private void Jump(float jumpForce)
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
    }

    public void Move(float inputX)
    {
        if (inputX < 0) _spriteRenderer.flipX = true;
        else if(inputX > 0) _spriteRenderer.flipX = false;
        var position = _rigidbody2D.position;
        _rigidbody2D.MovePosition(position + new Vector2(inputX, 0) * (_playerMovementSpeed * Time.fixedDeltaTime));
        _animator.SetFloat("Speed", Mathf.Abs(inputX));
    }
}
