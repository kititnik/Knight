using ConfigurationScripts;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private Timer _attackDelayTimer;
    private Timer _resetAttackTimer;
    [SerializeField] private PlayerConfiguration _playerConfiguration;

    private void Awake()
    {
        _attackDelayTimer = new Timer(this);
        _resetAttackTimer = new Timer(this);
        _playerCombat = new PlayerCombat(_playerConfiguration, playerObject.GetComponent<Animator>(), _attackDelayTimer, _resetAttackTimer);
        _playerMovement = new PlayerMovement( _playerConfiguration, playerObject.GetComponent<SpriteRenderer>(),
            playerObject.GetComponent<Rigidbody2D>(), playerObject.GetComponent<Animator>());
        playerObject.GetComponent<Player>().Initialize(_playerMovement, _playerCombat);
    }
}
