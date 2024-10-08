using UnityEngine;
using ConfigurationScripts;
using System.Collections.Generic;
using System;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private EnemyConfiguration attackConfiguration;
    private Timer _attackDelayTimer;
    private Timer _resetAttackTimer;
    private int _currentAttack;
    private int _maxAttack;
    private bool _canAttack;
    private float _attackDelay;
    private float _resetAttackDelay;
    private float _swordDamage;
    [SerializeField] private List<IDamageable> _enemyHealths;
    [SerializeField] private List<string> alliesTags;

    private void Awake()
    {
        _enemyHealths = new List<IDamageable>();

        _attackDelayTimer = new Timer(this);
        _resetAttackTimer = new Timer(this);

        _attackDelayTimer.TimeIsOver += SetCanAttack; 
        _resetAttackTimer.TimeIsOver += ResetAttack;
        _resetAttackTimer.StartTimer(_resetAttackDelay);

        _canAttack = true;
        _currentAttack = 1;
        _maxAttack = attackConfiguration.maxSwordAttack;
        _attackDelay = attackConfiguration.meleeAttackDelay;
        _resetAttackDelay = attackConfiguration.resetSwordAttackDelay;
        _swordDamage = attackConfiguration.swordDamage;
    }

    private void ResetAttack() => _currentAttack = 1;

    private void SetCanAttack() => _canAttack = true;

    public void Update()
    {
        float damage = Attack();
        if(damage <= 0) return;
        try
        {
            foreach(IDamageable enemyHealth in _enemyHealths)
            {
                enemyHealth.GetDamage(damage);
            }
        }
        catch(InvalidOperationException) {}
        catch(MissingReferenceException) {}
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
        var enemyHealth = other.GetComponent<IDamageable>();
        if(enemyHealth == null) return;
        if(_enemyHealths.Contains(enemyHealth)) return;
        if(alliesTags.Contains(other.tag)) return;
        _enemyHealths.Add(enemyHealth);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<IDamageable>() == null) return;
        _enemyHealths.Remove(other.GetComponent<IDamageable>());
    }
}