using ConfigurationScripts;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration playerConfiguration;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _playerMovementSpeed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovementSpeed = playerConfiguration.playerMovementSpeed;
    }

    private void FixedUpdate()
    {
        Move(Input.GetAxisRaw("Horizontal"));
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
