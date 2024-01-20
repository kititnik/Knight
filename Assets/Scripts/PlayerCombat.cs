using ConfigurationScripts;
using UnityEngine;

public class PlayerCombat
{
    private readonly Animator _animator;
    private readonly Timer _attackDelayTimer;
    private readonly Timer _resetAttackTimer;
    private int _currentAttack;
    private readonly int _maxAttack;
    private bool _canAttack;
    private readonly float _attackDelay;
    private readonly float _resetAttackDelay;
    private readonly float _swordDamage;

    public PlayerCombat(PlayerConfiguration playerConfiguration, Animator animator, Timer attackDelayTimer, Timer resetAttackTimer)
    {
        _animator = animator;
        _attackDelayTimer = attackDelayTimer;
        _resetAttackTimer = resetAttackTimer;

        _attackDelayTimer.TimeIsOver += SetCanAttack; 
        _resetAttackTimer.TimeIsOver += ResetAttack;
        _resetAttackTimer.StartTimer(_resetAttackDelay);

        _canAttack = true;
        _currentAttack = 1;
        _maxAttack = playerConfiguration.maxSwordAttack;
        _attackDelay = playerConfiguration.swordAttackDelay;
        _resetAttackDelay = playerConfiguration.resetSwordAttackDelay;
        _swordDamage = playerConfiguration.swordDamage;
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
}
