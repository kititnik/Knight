using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    private List<IDamageable> _enemyHealths;


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
        _maxAttack = playerConfiguration.maxSwordAttack;
        _attackDelay = playerConfiguration.swordAttackDelay;
        _resetAttackDelay = playerConfiguration.resetSwordAttackDelay;
        _swordDamage = playerConfiguration.swordDamage;

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float damage = 0;
        if(Input.GetButtonDown("Fire1")) damage = SwordAttack();
        if(damage > 0)
        {
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
    }

    private void ResetAttack() => _currentAttack = 1;

    private void SetCanAttack() => _canAttack = true;
    
    public float SwordAttack()
    {
        if (!_canAttack) return 0;
        if (_currentAttack > _maxAttack) ResetAttack();
        _animator.Play("HeroKnight_Attack" + _currentAttack);
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
        if(enemyHealth == null || _enemyHealths.Contains(enemyHealth)) return;
        _enemyHealths.Add(enemyHealth);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<IDamageable>() == null) return;
        _enemyHealths.Remove(other.GetComponent<IDamageable>());
    }
}
