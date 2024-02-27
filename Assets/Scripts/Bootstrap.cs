using ConfigurationScripts;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Inventory _inventory;
    private Timer _attackDelayTimer;
    private Timer _resetAttackTimer;
    private UIHandler _UI;
    [SerializeField] private PlayerConfiguration _playerConfiguration;
    [SerializeField] private GameObject actionButton;

    private void Awake()
    {
        _attackDelayTimer = new Timer(this);
        _resetAttackTimer = new Timer(this);
        _playerCombat = new PlayerCombat(_playerConfiguration, playerObject.GetComponent<Animator>(), _attackDelayTimer, _resetAttackTimer);
        _playerMovement = new PlayerMovement( _playerConfiguration, playerObject.GetComponent<SpriteRenderer>(),
            playerObject.GetComponent<Rigidbody2D>(), playerObject.GetComponent<Animator>());
        _inventory = new Inventory();
        _UI = new UIHandler(actionButton);
        playerObject.GetComponent<Player>().Initialize(_playerMovement, _playerCombat, _inventory, _UI);
    }
}
