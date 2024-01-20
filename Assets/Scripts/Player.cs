using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _movementSpeed;
    private PlayerMovement _playerMovement;
    
    public void Inititialize(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    private void Update()
    {
        _playerMovement.Move(Input.GetAxisRaw("Horizontal"), _movementSpeed);
    }
}
