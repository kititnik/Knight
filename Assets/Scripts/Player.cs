using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Inventory _inventory;
    private UIHandler _UI;
    
    public void Initialize(PlayerMovement playerMovement, PlayerCombat playerCombat, Inventory inventory, UIHandler UI)
    {
        _playerMovement = playerMovement;
        _playerCombat = playerCombat;
        _inventory = inventory;
        _UI = UI;
    }

    private void Update()
    {
        _playerMovement.Move(Input.GetAxisRaw("Horizontal"));
        if(Input.GetButtonDown("Fire1")) Debug.Log(_playerCombat.SwordAttack());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.GetComponent<Item>() != null) 
        {
            var itemComponent = col.gameObject.GetComponent<Item>();
            Debug.Log(_inventory.AddItem(itemComponent));
            itemComponent.OnPickUp();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Action"))
        {
            _UI.OnEnterActionZone();
            Debug.Log("Action Zone");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Action"))
        {
            _UI.OnExitActionZone();
        }
    }
}
