using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    
    public void Initialize(PlayerMovement playerMovement, PlayerCombat playerCombat)
    {
        _playerMovement = playerMovement;
        _playerCombat = playerCombat;
    }

    private void Update()
    {
        _playerMovement.Move(Input.GetAxisRaw("Horizontal"));
        if(Input.GetButtonDown("Fire1")) Debug.Log(_playerCombat.SwordAttack());
    }
}
