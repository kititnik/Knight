using ConfigurationScripts;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerConfiguration playerConfiguration;
    private Animator _animator;
    private Timer _attackDelayTimer;
    private Timer _resetAttackTimer;
    private int _currentAttack;
    private int _maxAttack;
    private bool _canAttack;
    private float _attackDelay;
    private float _resetAttackDelay;
    private float _swordDamage;
    private float _currentDamage;
    private Health _enemyHealth;

    private void Awake()
    {
        _attackDelayTimer = new Timer(this);
        _resetAttackTimer = new Timer(this);

        _attackDelayTimer.TimeIsOver += SetCanAttack; 
        _resetAttackTimer.TimeIsOver += ResetAttack;
        _resetAttackTimer.StartTimer(_resetAttackDelay);

        _canAttack = true;
        _currentAttack = 1;
        _maxAttack = playerConfiguration.maxSwordAttack;
        _attackDelay = playerConfiguration.swordAttackDelay;
        _resetAttackDelay = playerConfiguration.resetSwordAttackDelay;
        _swordDamage = playerConfiguration.swordDamage;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")) SwordAttack();
    }

    private void ResetAttack() => _currentAttack = 1;

    private void SetCanAttack() => _canAttack = true;
    
    public void SwordAttack()
    {
        if (!_canAttack) return;
        if (_currentAttack > _maxAttack) ResetAttack();
        _animator.Play("HeroKnight_Attack" + _currentAttack);
        _currentDamage = _swordDamage;
        if (_currentAttack > 1) _currentDamage += _currentDamage * (_currentAttack / 10.0f);
        if(_enemyHealth != null) _enemyHealth.GetDamage(_currentDamage);
        _currentAttack++;
        _canAttack = false;
        _attackDelayTimer.StartTimer(_attackDelay);
        _resetAttackTimer.RestartTimer(_resetAttackDelay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _enemyHealth = other.GetComponent<Health>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemyHealth = null;
    }
}
