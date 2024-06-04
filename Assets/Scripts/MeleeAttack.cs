using UnityEngine;
using ConfigurationScripts;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private EnemyConfiguration enemyConfiguration;
    private Timer _attackDelayTimer;
    private Timer _resetAttackTimer;
    private int _currentAttack;
    private int _maxAttack;
    private bool _canAttack;
    private float _attackDelay;
    private float _resetAttackDelay;
    private float _swordDamage;
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
        _maxAttack = enemyConfiguration.maxSwordAttack;
        _attackDelay = enemyConfiguration.meleeAttackDelay;
        _resetAttackDelay = enemyConfiguration.resetSwordAttackDelay;
        _swordDamage = enemyConfiguration.swordDamage;
    }

    private void ResetAttack() => _currentAttack = 1;

    private void SetCanAttack() => _canAttack = true;

    public void Update()
    {
        if(_enemyHealth != null) 
        {
            float damage = Attack();
            if(damage > 0) _enemyHealth.GetDamage(damage);
        }
    }

    public float Attack()
    {
        if (!_canAttack) return 0;
        if (_currentAttack > _maxAttack) ResetAttack();
        float damage = _swordDamage;
        if (_currentAttack > 1) damage += damage * (_currentAttack / 10.0f);
        _currentAttack++;
        _canAttack = false;
        _attackDelayTimer.StartTimer(_attackDelay);
        _resetAttackTimer.RestartTimer(_resetAttackDelay);
        return damage;
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